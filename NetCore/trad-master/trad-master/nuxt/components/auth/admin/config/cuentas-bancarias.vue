<template>
  <admin-catalogos
    :campos="campos"
    :servicio-consulta="consulta"
    :servicio-agregar="creacion"
    nombre-catalogo="account"
  />
</template>

<script>
import adminCatalogos from '../admin-catalogos'

export default {
  name: 'cuentasBancarias',
  components: {
    adminCatalogos
  },
  data: () => ({
    campos: [
      {
        dbin: 'cuenta',
        rules: { required: true,alpha_num:true },
        edit: true
      },
      {
        dbin: 'banco',
        rules: { required: true,object: true },
        combo: 'servicios/catalogos/bancos',
        edit: true
      },
      {
        dbin: 'TipoCuenta',
        rules: { required: true,object: true },
        combo: 'servicios/catalogos/tipoCuenta',
        edit: true
      },
      {
        dbin: 'nombres',
        rules: { required: true,object: true },
        edit: true
      },
      {
        dbin: 'tipoIdentificacion',
        combo: 'servicios/catalogos/tipoDoc',
        rules: { required: true,object: true },
        edit: true
      },
      {
        dbin: 'identificacion',
        rules: { required: true },
        edit: true
      },
      {
        dbin: 'email',
        rules: { required: true, email:true },
        edit: true
      },
    ],
    consulta: 'servicios/catalogos/cuentas',
    creacion: 'servicios/catalogos/crearCuentas',
  })
}
</script>

<style scoped>

</style>
