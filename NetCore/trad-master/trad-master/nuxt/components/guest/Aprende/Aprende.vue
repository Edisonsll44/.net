<template>
  <div class="counter-wrap">
    <v-container>
      <v-row
        justify="center"
        align="center"
        class="counter-inner spacing9"
      >
        <v-col md="8" class="pa-6">
          <h1 class="text-primary">{{ $t('saasLanding.header_aprende') }}</h1>
          <p class="text-primary">{{ $t('saasLanding.header_aprende_sub') }}</p>
        </v-col>
        <v-col md="4" class="pa-6">
          <v-btn
            :href="link.saas.register"
            color="primary"
            large
          >
            {{ $t('saasLanding.getstarted') }}
          </v-btn>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<style lang="scss" scoped>
@import 'aprende-style';
</style>

<script>
import link from 'static/text/link'
export default {
  data() {
    return {
      link: link,
    }
  }
}
</script>
