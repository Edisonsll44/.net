<template>
  <div>
    <div class="main-wrap">
      <main-header />
      <div class="container-wrap">
        <section id="home">
          <carousel/>
        </section>
        <section id="feature">
          <banner />
        </section>
        <section :class="!isMobile && 'space-top-short'">
          <aprende />
        </section>
        <section id="testimonials" :class="isMobile ? 'space-top-short' : 'space-top'">
          <testimonials />
        </section>
        <section id="pricing" class="space-top">
          <pricing-plan />
        </section>
      </div>
      <section id="footer">
        <footer-with-deco />
      </section>
      <hidden point="mdDown">
        <page-nav />
      </hidden>
    </div>
  </div>
</template>

<style scoped lang="scss">
@import '~/assets/styles';

@function section-margin($margin) {
  @return $margin * 20;
}
.main-wrap {
  position: relative;
  width: 100%;
  overflow: hidden;
  @include palette-text-primary;
  .theme--dark & {
    background-color: $dark-background-default;
  }
  .theme--light & {
    background-color: $light-background-paper;
  }
}
.space-bottom {
  margin-bottom: section-margin($spacing1);
  @include breakpoints-down(sm) {
    margin-bottom: section-margin(6px);
  }
}
.space-bottom-testi {
  @include breakpoints-up(md) {
    margin-bottom: section-margin($spacing1);
  }
}
.space-bottom-short {
  margin-bottom: section-margin($spacing1 / 2);
}
.space-top {
  margin-top: section-margin($spacing1);
  @include breakpoints-down(sm) {
    margin-top: section-margin(6px);
  }
}
.space-top-short {
  margin-top: section-margin($spacing1 / 2);
}
.container-wrap {
  margin-top: -40px;
  > section {
    position: relative;
  }
}
</style>

<script>
import Header from '~/components/guest/Header'
import Carousel from '~/components/guest/Carousel'
import Hidden from '~/components/guest/Hidden'
import PageNav from '~/components/guest/PageNav'
import Banner from '~/components/guest/Banner'
import CompanyLogo from '~/components/guest/CompanyLogo'
import Aprende from '~/components/guest/Aprende'
import Feature from '~/components/guest/Feature'
import Testimonials from '~/components/guest/Testimonials'
import PricingPlan from '~/components/guest/PricingPlan'
import Faq from '~/components/guest/Faq'
import NewsEvent from '~/components/guest/NewsEvent'
import FooterWithDeco from '~/components/guest/Footer/FooterWithDeco'
import brand from '~/static/text/brand'

export default {
  components: {
    'main-header': Header,
    Banner,
    Carousel,
    CompanyLogo,
    Aprende,
    Feature,
    Testimonials,
    PricingPlan,
    Faq,
    NewsEvent,
    FooterWithDeco,
    PageNav,
    Hidden
  },
  computed: {
    isTablet() {
      return this.$mq === 'mdDown' || this.$mq === 'smDown' || this.$mq === 'xsDown' // eslint-disable-line
    },
    isMobile() {
      return this.$mq === 'smDown' || this.$mq === 'xsDown'
    }
  },
  head() {
    return {
      title: this.$t('menu.index')
    }
  }
}
</script>
