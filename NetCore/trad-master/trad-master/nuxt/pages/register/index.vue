<template>
  <div>
    <register-form />
  </div>
</template>

<script>
import brand from 'static/text/brand'
import RegisterForm from '@/components/guest/Forms/Register'

export default {
  components: {
    RegisterForm
  },
  middleware: 'guest',
  head() {
    return {
      title: this.$t('menu.register')
    }
  }
}
</script>
