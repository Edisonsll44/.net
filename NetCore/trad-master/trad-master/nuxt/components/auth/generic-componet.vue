<template>
  <component :is="componente" :forma="forma" @registrado="$emit('registrado')" />
</template>

<script>
import errorComponet from './error-componet'
import spinnerComponet from './spinner-componet'
const getComponet = slug => ({
  component: import(`@/components/auth/user/forma-pago/${slug}`),
  error: errorComponet,
  loading: spinnerComponet,
})
export default {
  props: {
    name:{
      type: String
    },
    forma: {
      type: Object,
      required: true,
    }
  },
  beforeCreate () {
    this.componente = () => getComponet(this.name)
  }
}
</script>
