<template>
  <div>
    <login-form />
  </div>
</template>

<script>
import brand from '~/static/text/brand'
import LoginForm from '~/components/guest/Forms/Login'

export default {
  components: {
    LoginForm
  },
  middleware: 'guest',
  head() {
    return {
      title: this.$t('menu.login')
    }
  }
}
</script>
