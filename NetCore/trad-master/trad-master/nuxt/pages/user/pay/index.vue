<template>
  <v-container fluid>
    <v-row>
      <div class="col-lg-6 col-12 ma-0 pa-0 pr-lg-2" ref="compInput">
        <v-tabs
          fixed-tabs
          color="white"
          background-color="light-green darken-1"
          slider-color="primary"
          v-model="tab"
        >
          <v-tab v-for="item in opciones" :key="'tab-'+item.nombre" :disabled="!item.componente">
            {{ item.nombre }}
          </v-tab>
        </v-tabs>
        <v-tabs-items v-model="tab">
          <v-tab-item
            v-for="item in opciones"
            :key="item.nombre"
          >
            <v-card flat class="rounded-0">
              <v-card-text>
                <genericComponet
                  :forma="item"
                  :key="item.id"
                  :name="item.componente"
                  @registrado="consultarPagos"
                />
              </v-card-text>
            </v-card>
          </v-tab-item>
        </v-tabs-items>
      </div>
      <div class="col-lg-6 col-12 ma-0 pa-0">
        <v-card flat class="rounded-0">
          <v-card-text>
            <h3 class="primary--text mb-3">{{ $t('common.pay_list') }}</h3>
            <vue-perfect-scrollbar class="alto" :settings="scrollSettings" :style="{height:alto-40}">
              <template v-for="(item,index) in items">
                <pay-detail-user
                  :key="index"
                  :item="item"
                  :show-array="labels"
                  v-model="seleccionado"
                  @input="abrirModal(item)"
                />
              </template>
              <v-alert
                v-if="items.length===0"
                dense
                outlined
                type="info"
              >
                {{ $t('fulluse.no_pays') }}
              </v-alert>
            </vue-perfect-scrollbar>
          </v-card-text>
        </v-card>
      </div>
    </v-row>
    <modal-detail
      :item="seleccionado"
      v-model="openModal"
    />
  </v-container>
</template>

<script>
import payDetailUser from '@/components/auth/pay-detail-user'
import modalDetail from '@/components/auth/modal-detail'
import genericComponet from '@/components/auth/generic-componet'

export default {
  name: 'pago',
  layout: 'auth',
  data: () => ({
    loadComponent: true,
    openModal: false,
    seleccionado: null,
    items: [],
    tab: null,
    formulario: {
      fecha: null,
      hora: null,
      archivo: null
    },
    alto: 503,
    opciones: [],
    scrollSettings: {
      maxScrollbarLength: 503
    },
    labels: [
      {
        value: 'fechaPago',
        filter: 'dateLarge'
      },
      {
        value: 'formaPago'
      }
    ]
  }),
  components: {
    payDetailUser,
    modalDetail,
    genericComponet
  },
  methods: {
    getFormaPago() {
      this.loadComponent = true
      this.$store.dispatch('servicios/catalogos/formaPago').then((formas) => {
        this.opciones = formas
        this.loadComponent = false
      })
    },
    consultarPagos() {
      this.$store.dispatch('servicios/pagos/todosPagosUsuario').then((pagos) => {
        this.items = pagos
      })
    },
    subscribeEvent() {
      this.$bus.$on(this.$store.getters['push/USER'].pagoActualizado, (item) => {
        const index = this.items.findIndex(i => i.id === item.id)
        this.$set(this.items, index, item)
      })
    },
    abrirModal(item) {
      this.$router.push({ name: this.$route.name, query: { id: item.id } })
      this.openModal = true
    }
  },
  mounted() {
    this.consultarPagos()
    this.subscribeEvent()
  },
  created() {
    this.getFormaPago()
  },
  head() {
    return {
      title: this.$t('menu.pagos')
    }
  }
}
</script>

<style scoped>
.alto {
  overflow: auto;
  height: 506px;
}
</style>
