<template>
  <div class="root">
    <div class="decoration">
      <v-carousel
        v-model="model"
        cycle
        height="100%"
        hide-delimiter-background
        delimiter-icon="mdi-minus"
      >
        <v-carousel-item
          v-for="(img, i) in carusel"
          :key="i"
          :src="img"
          class="img-bck"
        >
          <v-container
            fill-height
            fluid
            p-4
            m-2
          >
            <v-row no-gutters justify="center">
              <v-col md="7" sm="12">
                <div class="text-left">
                  <h1 class="text-white">{{ $t('saasLanding.carousel_title_' + i) }}</h1>
                  <br>
                  <p class="text-white">{{ $t('saasLanding.carousel_subtitle_' + i) }}</p>
                </div>
                <div class="title">
                  <v-btn
                    :href="link.saas.register"
                    color="secondary"
                    large
                  >
                    {{ $t('saasLanding.getstarted') }}
                  </v-btn>
                </div>
              </v-col>
            </v-row>
          </v-container>
        </v-carousel-item>
      </v-carousel>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import '../Banner/banner-style';
.root{
  height: 106vh;
}
h1{
  font-size: 3em;
  line-height: 1.2em;
}
</style>

<script>
import youtube from '@/youtube'
import imgAPI from 'static/images/imgAPI'
import link from 'static/text/link'
import Hidden from '../Hidden'

export default {
  components: {
    Hidden
  },
  data: () => ({
    videoId: 'KxZAdEGpYAw',
    hide: false,
    link: link,
    dialog: false,
    player: null,
    playerVars: {
      autoplay: 0,
      controls: 1,
      rel: 0,
      showinfo: 1,
      mute: 0,
      origin: 'https://localhost:8008'
    },
    yt: youtube,
    model: 0,
    colors: [
      'primary'
    ],
    carusel: imgAPI.carousel

  }),
  methods: {
    handleVideoOpen() {
      if (!this.yt.use) {
        return false
      }
      this.dialog = true
      setTimeout(() => {
        this.player = this.$refs.youtube.player
        this.player.playVideo()
      }, 100)
    },
    handleVideoClose() {
      this.dialog = false
      this.player.pauseVideo()
    }
  },
  computed: {
    isDesktop() {
      const lgUp = this.$store.state.breakpoints.lgUp
      return lgUp.indexOf(this.$mq) > -1
    }
  }
}
</script>
