<template>
  <div class="footer-deco">
    <div class="decoration">
      <svg class="left-deco">
        <use xlink:href="/images/saas/deco-bg-left.svg#main" />
      </svg>
      <svg class="right-deco">
        <use xlink:href="/images/saas/deco-bg-right.svg#main" />
      </svg>
    </div>
    <div class="action">
      <h4 class="use-text-title2">
        {{ $t('saasLanding.contact') }}
      </h4>
    </div>
    <footer-main />
  </div>
</template>

<style lang="scss" scoped>
@import 'footer-style';
</style>

<script>
import Footer from './Footer'

export default {
  components: {
    'footer-main': Footer
  }
}
</script>
