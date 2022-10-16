<template>
  <admin-catalogos
    :campos="campos"
    :servicio-consulta="consulta"
    :servicio-agregar="creacion"
    nombre-catalogo="bank"
  />
</template>

<script>
import adminCatalogos from '../admin-catalogos'

export default {
  name: 'menu',
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
    consulta: 'servicios/catalogos/bancos',
    creacion: 'servicios/catalogos/crearBancos',
  })
}
</script>

<style scoped>

</style>
