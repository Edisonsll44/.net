<template>
  <v-dialog
    v-model="modalV"
    width="500"
    scrollable
  >
    <v-card v-if="item">
      <v-card-title class="headline">
        {{ $t('fulluse.detail_pay') }}
      </v-card-title>

      <v-card-text>
        <template v-for="(i,index) in config">
          <v-list-item two-line  :key="index" v-if="filtrado(i)">
            <v-list-item-content>
              <v-list-item-title>{{ $t('database.' + i.db) }}</v-list-item-title>
              <v-list-item-subtitle :class="{'currency':i.db==='valor'}">{{ filtrado(i) }}</v-list-item-subtitle>
            </v-list-item-content>
          </v-list-item>
        </template>
        <v-list-item two-line v-if=" typeof item.estadoId==='object'" :color="$t('colors.'+item.estadoId.nombre)">
          <v-list-item-content >
            <v-list-item-title>{{ $t('database.estado') }}</v-list-item-title>
            <v-list-item-subtitle>{{ item.estadoId.nombre }}</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
        <v-list-item two-line v-else :color="$t('colors.'+item.estado)">
          <v-list-item-content >
            <v-list-item-title>{{ $t('database.estado') }}</v-list-item-title>
            <v-list-item-subtitle>{{ item.estado }}</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
        <v-img
          v-if="item.imagen"
          :src="item.imagen"
          contain
          class="white"/>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn
          color="green darken-1"
          text
          @click="modalV = false"
        >
          {{ $t('fulluse.close') }}
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
export default {
  name: 'modal-detail',
  data: () => ({
    modalV: false,
    config: [
      {
        db: 'nombres'
      },
      {
        db: 'fechaPago',
        filter: 'dateLarge'
      },
      {
        db: 'referencia'
      },
      {
        db: 'banco'
      },
      {
        db: 'tipoCuenta'
      },
      {
        db: 'cuentaDeposito'
      },
      {
        db: 'identificacion'
      },
      {
        db: 'tipoIdentificacion'
      },
      {
        db: 'correo'
      },
      {
        db: 'valor',
        filter: 'currency'
      }
    ]
  }),
  methods: {
    filtrado(value) {
      if (value.filter) {
        return this.$options.filters[value.filter](this.item[value.db])
      }
      return this.item[value.db]
    }
  },
  watch: {
    modalV(val) {
      this.$emit('input', val)
    },
    value(val) {
      this.modalV = val
      this.$emit('input', val)
    }
  },
  props: {
    item: {
      type: Object
    },
    value: {
      type: Boolean
    }
  }
}
</script>

<style scoped>

</style>
