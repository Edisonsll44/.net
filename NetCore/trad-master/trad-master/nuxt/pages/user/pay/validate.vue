<template>
  <div>
    <v-data-table
      :headers="columnas"
      :items="items"
      :search="search"
      :loading="procesando"
      :item-class="colorFila"
      sort-by="fechaPago"
      :sort-desc="true"
    >
      <template v-slot:top>
        <v-toolbar>
            <v-text-field
              class='ma-5'
              v-model="search"
              append-icon="mdi-magnify"
              :label="$t('fulluse.search')"
              single-line
              hide-details
            ></v-text-field>
        </v-toolbar>
      </template>
      <template v-slot:item.estado="{ item }">
        <pay-detail
          :label="$t('fulluse.status')"
          :estados="estados"
          :item="item"
          v-model="item.estadoId"
          class="eliminar-det"
        />
      </template>
      <template v-slot:item.valor="{ value }">
        <span class="currency">{{ value | currency }}</span>
      </template>
      <template v-slot:item.fechaPago="{ value }">
        {{ value | dateLarge }}
      </template>
      <template v-slot:item.detalle="{ item }">
        <v-btn
          small
          color="primary"
          dark
          class="text-transform-none"
          v-on:click="verDetalle(item)"
        >
          <v-icon left>
            mdi-cash
          </v-icon>
          {{ $t('fulluse.detail') }}
        </v-btn>
      </template>
    </v-data-table>
    <modal-detail
      :item="seleccionado"
      v-model="openModal"
    />
  </div>
</template>

<script>
import payDetail from '@/components/auth/admin/pay-detail'
import modalDetail from '@/components/auth/modal-detail'
import comboBox from '@/components/combo-box'

export default {
  name: 'deposite-validate',
  layout: 'auth',
  ssr: true,
  middleware: 'admin',
  components: {
    payDetail,
    modalDetail,
    comboBox
  },
  data() {
    return {
      procesando: true,
      seleccionado: null,
      search: '',
      filter: {},
      sortDesc: false,
      openModal: false,
      sortBy: 'valor',
      columnas: [
        {
          text: this.$t('database.identificacion'),
          value: 'identificacion',
        },
        {
          text: this.$t('database.nombres'),
          value: 'nombres',
        },
        {
          text: this.$t('database.valor'),
          type: 'number',
          value: 'valor',
          align: 'end',
        },
        {
          text: this.$t('database.fechaPago'),
          value: 'fechaPago',
        },
        {
          text: this.$t('database.estado'),
          value: 'estado',
        },
        {
          text: this.$t('fulluse.detail'),
          value: 'detalle'
        }
      ],
      keys: [
        {
          text: this.$t('database.valor'),
          value: 'valor',
          filter: 'currency',
          class: 'currency'
        },
        {
          text: this.$t('database.fechaPago'),
          value: 'fechaPago',
          filter: 'dateLarge'
        }
      ],
      items: [],
      estados: []
    }
  },
  computed: {
    modo() {
      return this.$vuetify.theme.dark ? 'nocturnal' : null
    },
    numberOfPages() {
      return Math.ceil(this.items.length / this.itemsPerPage)
    },
    filteredKeys() {
      return this.keys.filter(key => key !== 'Name')
    }
  },
  methods: {
    colorFila(item) {
      if(typeof  item.estadoId !== 'string'){
        if(this.$vuetify.theme.dark){
          return this.$t('colors.'+item.estadoId.nombre)+' darken-4'
        }else{
          return this.$t('colors.'+item.estadoId.nombre)+' lighten-5'
        }
      }
      return null;
    },
    verDetalle(item) {
      this.seleccionado = item
      this.openModal = true
    },
    consultarPagos() {
      this.procesando = true
      this.$store.dispatch('servicios/pagos/todosPagos', this.formulario).then((data) => {
        this.items = data
        this.procesando = false
      })
    },
    consultarEstados() {
      this.$store.dispatch('servicios/catalogos/estadoPago').then((data) => {
        this.estados = data
      })
    },
    subscribeEvent() {
      this.$bus.$on(this.$store.getters['push/ADMIN'].pagoCreado, ( item ) => {
        this.items.push(item)
      })
    }
  },
  mounted() {
    this.consultarPagos()
    this.subscribeEvent()
  },
  created() {
    this.consultarEstados()
  },
  head() {
    return {
      title: this.$t('menu.pagos_val')
    }
  }
}
</script>

<style scoped>

</style>
