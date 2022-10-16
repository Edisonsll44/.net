<template>
  <admin-catalogos
    :campos="campos"
    :servicio-consulta="consulta"
    nombre-catalogo="type-accounts"
  />
</template>

<script>
import adminCatalogos from '../admin-catalogos'

export default {
  name: 'tipoCuentas',
  components: {
    adminCatalogos
  },
  data: () => ({
    campos: [
      {
        dbin: 'id',
        rules: { required: true },
        edit: false
      },
      {
        dbin: 'nombre',
        rules: { required: true },
        edit: true
      },
      {
        dbin: 'codigo',
        rules: { required: true, alpha_num:true },
        edit: true
      }
    ],
    consulta: 'servicios/catalogos/tipoCuenta',
  })
}
</script>

<style scoped>

</style>
