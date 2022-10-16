<template>
  <AuthFrame :title="$t('common.register_title')"
             :subtitle="$t('common.validate_continua')">
    <div>
      <div class="head">
        <title-secondary :align="isMobile ? 'center' : 'left'">
          {{ $t('common.validate') }}
        </title-secondary>
        <v-btn
          :href="routerLink.saas.login"
          class="button-link"
          text
          small
        >
          <v-icon class="icon signArrow">
            mdi-arrow-right
          </v-icon>
          {{ $t('common.login_validate') }}
        </v-btn>
      </div>
      <div class="separator">
        <p>
          {{ $t('common.register_or') }}
        </p>
      </div>
      <div class="spacing3">
        <v-alert
          border="top"
          colored-border
          type="info"
          elevation="2"
        >
          {{ $t('common.validate_true') }}
        </v-alert>
      </div>
    </div>
  </AuthFrame>
</template>

<script>
import brand from 'static/text/brand'
import routerLink from 'static/text/link'
import AuthFrame from '@/components/guest/Forms/AuthFrame'
import TitleSecondary from '@/components/guest/Title/TitleSecondary'

export default {
  name: 'validation',
  components: {
    AuthFrame,
    TitleSecondary
  },
  data: () => ({
    routerLink: routerLink
  }),
  async validate({ params, store }) {
    return await store
      .dispatch('servicios/login/validarCuenta', params.token)
      .then(response => {
        console.log(response)
        return true
      })
      .catch(() => {
        return false
      })
  },
  computed: {
    isMobile() {
      const smDown = this.$store.state.breakpoints.smDown
      return smDown.indexOf(this.$mq) > -1
    }
  },
  head() {
    return {
      title: this.$t('menu.validate')
    }
  }
}
</script>

<style lang="scss" scoped>
@import './components/guest/Forms/form-style';

.spacing3 {
  min-height: 45vh;
}
</style>
