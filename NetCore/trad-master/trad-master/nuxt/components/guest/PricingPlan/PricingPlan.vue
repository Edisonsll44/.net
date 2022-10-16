<template>
  <div class="root">
    <div class="decoration">
      <svg fill="#cccccc">
        <use xlink:href="/images/saas/deco-med-bg.svg#main" />
      </svg>
    </div>
    <v-container :class="{ fixed: isDesktop }">
      <div class="item">
        <title-main align="center">
          <strong>
            {{ $t('saasLanding.pricing_title') }}
          </strong>
        </title-main>
      </div>
      <p class="subtitle use-text-subtitle2 text-center">
        {{ $t('saasLanding.pricing_subtitle') }}
      </p>
      <div class="pricing-wrap">
        <u-animate-container>
          <u-animate
            :offset="-10"
            name="fadeInUpShort"
            delay="0.2s"
            duration="0.4s"
            class="item"
          >
            <pricing-card
              :price="250"
              :feature-list="$t('saasLanding.plan_title_feature_0')"
              :title="$t('saasLanding.plan_title_0')"
              desc="Interdum et malesuada fames ac ante ipsum primis in faucibus. "
              type="value"
            />
          </u-animate>
          <u-animate
            :offset="-10"
            name="fadeInUpShort"
            delay="0.4s"
            duration="0.4s"
            class="item"
          >
            <pricing-card
              :price="0"
              :feature-list="$t('saasLanding.plan_title_feature_1')"
              :title="$t('saasLanding.plan_title_1')"
              desc="Interdum et malesuada fames ac ante ipsum primis in faucibus. "
              type="basic"
            />
          </u-animate>
          <u-animate
            :offset="-10"
            name="fadeInUpShort"
            delay="0.6s"
            duration="0.4s"
            class="item"
          >
            <pricing-card
              :price="0"
              :feature-list="$t('saasLanding.plan_title_feature_2')"
              :title="$t('saasLanding.plan_title_2')"
              desc="Interdum et malesuada fames ac ante ipsum primis in faucibus. "
              type="basic"
            />
          </u-animate>
        </u-animate-container>
      </div>
    </v-container>
  </div>
</template>

<style lang="scss" scoped>
@import 'pricing-plan-style';
</style>

<script>
import Title from '../Title'
import PricingCard from '../Cards/Pricing'

export default {
  components: {
    'title-main': Title,
    PricingCard
  },
  computed: {
    isDesktop() {
      const lgUp = this.$store.state.breakpoints.lgUp
      return lgUp.indexOf(this.$mq) > -1
    }
  }
}
</script>
