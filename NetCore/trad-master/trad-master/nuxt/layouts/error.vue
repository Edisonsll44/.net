<template>
  <v-app>
    <div class="dedicated-page">
      <main-header />
      <Error
        :error-code="this.error.statusCode"
        :text="$t('common.404')"
      />
      <main-footer />
    </div>
  </v-app>
</template>

<style lang="scss" scoped>
.dedicated-page {
  background: $palette-primary-dark;
}
</style>

<script>
import brand from '~/static/text/brand'
import Header from '~/components/guest/Header'
import Footer from '~/components/guest/Footer'
import Error from '../components/guest/Error'

export default {
  components: {
    'main-header': Header,
    'main-footer': Footer,
    Error
  },
  layout: 'empty',
  props: {
    error: {
      type: Object,
      default: null
    }
  },
  head() {
    const title =
      this.error.statusCode === 404
        ? brand.saas.name + ' - ' + this.pageNotFound
        : brand.saas.name + ' - ' + this.otherError
    return {
      title
    }
  },
  data() {
    return {
      pageNotFound: 'Not Found',
      otherError: 'An error occurred'
    }
  }
}
</script>
