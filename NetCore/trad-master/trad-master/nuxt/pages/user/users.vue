<template>
  <admin-catalogos
    :campos='campos'
    :servicio-consulta='consulta'
    :servicio-editar='editar'
    nombre-catalogo='user'
  />
</template>

<script>
import adminCatalogos from '@/components/auth/admin/admin-catalogos'

export default {
  name: 'users',
  layout: 'auth',
  middleware: 'admin',
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
        dbin: 'nombres',
        rules: { required: true },
        edit: false
      },
      {
        dbin: 'apellidos',
        rules: { required: true, alpha_num: true },
        edit: false
      },
      {
        dbin: 'identificacion',
        rules: { required: true, alpha_num: true },
        edit: false
      },
      {
        dbin: 'rol',
        rules: { required: true, alpha_num: true },
        edit: false,
        nedit: true
      },
      {
        dbin: 'rolId',
        rules: { required: true, object: true },
        combo: 'servicios/catalogos/roles',
        edit: true,
        nshow: true
      }
    ],
    consulta: 'servicios/usuario/listarUsuarios',
    editar: 'servicios/usuario/rolUsuarios'
  }),
  head() {
    return {
      title: this.$t('menu.usuarios')
    }
  }
}
</script>

<style scoped>

</style>
