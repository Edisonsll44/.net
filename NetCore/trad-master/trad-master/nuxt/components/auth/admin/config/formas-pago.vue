<template>
  <admin-catalogos
    :campos='campos'
    :servicio-consulta='consulta'
    :servicio-agregar='creacion'
    nombre-catalogo='type-pay'
  >
    <template v-slot:alertEdit>
      <v-alert
        outlined
        type="success"
        text
      >
        El campo {{$t('database.componente')}} es elemento desarrollado en el sistema, debe estar previamente compilado para que pueda ser seleccionado
      </v-alert>
    </template>
    <template v-slot:alertNuev>
      <v-alert
        outlined
        type="info"
        text
      >
        El campo {{$t('database.componente')}} es elemento desarrollado en el sistema, debe estar previamente compilado para que pueda ser seleccionado
      </v-alert>
    </template>
  </admin-catalogos>
</template>

<script>
import adminCatalogos from '../admin-catalogos'

const ComponentContext = require.context('@/components/auth/user/forma-pago/', true, /\.vue$/i, 'lazy')
export default {
  name: 'forma-pago',
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
        rules: { required: true, alpha_num: true },
        edit: true
      },
      {
        dbin: 'componente',
        rules: { required: false },
        combo: Array.from(ComponentContext.keys(), i => ({
          id: i.split('/').pop().split('.')[0],
          nombre: i.split('/').pop().split('.')[0]
        })),
        edit: true
      }
    ],
    consulta: 'servicios/catalogos/formaPago',
    creacion: 'servicios/catalogos/crearFormaPago'
  })
}
</script>

<style scoped>

</style>
