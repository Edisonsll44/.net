<template>
<div class="root">
  <v-container :class="{ fixed: isDesktop }">
    <v-row class="spacing6">
      <v-col md="6" cols="12" class="px-6">
        <div class="slider-wrap">
          <hidden point="smDown">
            <div class="decoration">
              <svg width="900px" height="618px" viewBox="0 0 900 618" version="1.1">
                <defs>
                  <linearGradient x1="78.2441494%" y1="65.8737759%" x2="10.5892887%" y2="33.8596367%" id="linearGradient-1">
                    <stop :stop-color="$vuetify.theme.themes.light.primarydark" offset="0%" />
                    <stop :stop-color="$vuetify.theme.themes.light.primary" offset="100%" />
                  </linearGradient>
                </defs>
                <g stroke="none" stroke-width="0" fill="none" fill-rule="evenodd">
                  <path d="M442.972909,617.331576 C569.290851,617.331576 618.618612,525.937324 804.142458,549.304771 C989.666303,572.672218 872.7227,109.743835 732.652282,54.307977 C592.581863,-1.12788075 538.308155,61.549598 304.148084,8.36113994 C69.9880137,-44.8273182 0,167.6782 0,308.489881 C0,450.379879 177.014996,617.331576 442.972909,617.331576 Z" id="Oval" fill="url(#linearGradient-1)" />
                </g>
              </svg>
            </div>
          </hidden>
          <h3
            :class="[isMobile ? 'text-center' : 'text-left']"
            class="testi-title use-text-title2">
            {{ $t('saasLanding.header_academy') }}
          </h3>
          <p class="testi-subtitle">{{ $t('saasLanding.header_academy_sub') }}</p>
        </div>
      </v-col>
      <v-col md="12" cols="12" class="over-decoration">
        <v-row align="center">
          <card-tips
            v-for="(item,index) in lista"
            :key="index"
            :tips="item"
          />
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</div>
</template>

<style lang="scss" scoped>
@import 'testi-style';
</style>

<script>
import Hidden from '../Hidden'
import CardTips from '../Landing/card-tips'

export default {
  components: {
    Hidden,
    CardTips,
    Slick: () => import('vue-slick')
  },
  data() {
    return {
      lista: [
        {
          icon:'school',
          color:'blue darken-2',
        },
        {
          icon:'sentiment_very_satisfied',
          color:'blue lighten-1',
        },
        {
          icon:'supervisor_account',
          color:'orange lighten-1',
        },
        {
          icon:'call_made',
          color:'green darken-2',
        },
      ],
      loaded: false,
      currentSlide: 0,
      slickOptions: {
        dots: false,
        infinite: true,
        speed: 500,
        autoplay: true,
        autoplaySpeed: 3000,
        slidesToShow: 1,
        fade: true,
        arrows: false,
        pauseOnHover: false
      }
    }
  },
  mounted() {
    this.loaded = true
  },
  methods: {
    handleAfterChange(event, slick, currentSlide) {
      this.currentSlide = currentSlide
    },
    gotoSlide(index) {
      this.$refs.slider.goTo(index)
    }
  },
  computed: {
    isDesktop() {
      const lgUp = this.$store.state.breakpoints.lgUp
      return lgUp.indexOf(this.$mq) > -1
    },
    isMobile() {
      const smDown = this.$store.state.breakpoints.smDown
      return smDown.indexOf(this.$mq) > -1
    }
  }
}
</script>
