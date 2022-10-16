<template>
  <h2 class="mb-2">
    <i class="fa fa-arrow-circle-left" @click="$router.go(-1)" />
    {{ $t('menu.' + actual.title) }}
  </h2>
</template>

<script>
import brand from 'static/text/brand'

export default {
  name: 'AppTitle',
  computed: {
    actual() {
      const actual = this.localeRoute(this.$route)
      let aux = { title: brand.saas.name }
      this.$store.getters['local/GET_MENU'].map(i => {
        if (actual.path === this.localePath(i.href)) {
          aux = i
        }
      })
      return aux
    }
  }
}
</script>

<style scoped>
h2 {
  border-bottom: 3px double white;
}

.fa {
  cursor: pointer;
}
</style>
