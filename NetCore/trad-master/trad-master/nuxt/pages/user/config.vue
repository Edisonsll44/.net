<template>
  <div>
    <v-tabs
      fixed-tabs
      color="white"
      background-color="light-green darken-1"
      slider-color="primary"
      v-model="tab"
    >
      <v-tab v-for="item in opciones" :key="'tab-'+item.nombre">
        {{ $t('fulluse.'+item.nombre) }}
      </v-tab>
    </v-tabs>
    <v-tabs-items v-model="tab">
      <v-tab-item
        v-for="(item,index) in opciones"
        :key="item.nombre"
      >
        <component
          v-if="item.componente"
          :key="index"
          :is="item.componente"
        />
      </v-tab-item>
    </v-tabs-items>
  </div>
</template>

<script>
import bancos from '@/components/auth/admin/config/bancos'
import cuentasBancarias from '@/components/auth/admin/config/cuentas-bancarias'
import formasPago from '@/components/auth/admin/config/formas-pago'
import tipoCuentas from '@/components/auth/admin/config/tipo-cuentas'

export default {
  name: 'config',
  layout: 'auth',
  middleware: 'admin',
  components: {
    bancos,
    cuentasBancarias,
    formasPago,
    tipoCuentas
  },
  data: () => ({
    tab: null,
    opciones: [
      {
        nombre: 'banks',
        componente: 'bancos'
      },
      {
        nombre: 'type-pays',
        componente: 'formasPago'
      },
      {
        nombre: 'type-accounts',
        componente: 'tipoCuentas'
      },
      {
        nombre: 'accounts',
        componente: 'cuentasBancarias'
      },
    ]
  }),
  head() {
    return {
      title: this.$t('menu.configuracion')
    }
  }
}
</script>

<style scoped>

</style>
