<template>
  <div>
    <contact />
  </div>
</template>

<script>
import Contact from '~/components/guest/Forms/Contact'
import brand from '~/static/text/brand'

export default {
  components: {
    Contact
  },
  head() {
    return {
      title: this.$t('menu.contacto')
    }
  }
}
</script>
