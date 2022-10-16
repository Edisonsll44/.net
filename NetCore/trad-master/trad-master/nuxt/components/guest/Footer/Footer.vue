<template>
  <footer class="footer" :class="{ invert: invert }" id="contact">
    <v-container class="max-lg">
      <v-row class="spacing4">
        <v-col
          md="3"
          cols="12"
          class="pa-4"
        >
          <div class="pa-1 text-center">
            <v-btn
              outlined
              color="white"
            >
              contacto@soulsplit.com
            </v-btn>

          </div>
          <div class="socmed">
            <v-btn
              text
              icon
              href="http://facebook.com"
              target="_blank"
              dark
              class="button"
            >
              <span class="ion-social-facebook icon" />
            </v-btn>
            <v-btn
              text
              icon
              href="http://twitter.com"
              target="_blank"
              dark
              class="button"
            >
              <span class="ion-social-twitter icon" />
            </v-btn>
            <v-btn
              text
              icon
              href="http://instagram.com"
              target="_blank"
              dark
              class="button"
            >
              <span class="ion-social-instagram icon" />
            </v-btn>
            <v-btn
              text
              icon
              href="http://linkedin.com"
              target="_blank"
              dark
              class="button"
            >
              <span class="ion-social-linkedin icon" />
            </v-btn>
          </div>
          <v-select
            :items="langList"
            :value="lang"
            v-model="lang"
            label=""
            outlined
            class="select-lang"
            prepend-inner-icon="mdi-web"
            @change="switchLang(lang)"
          />
        </v-col>
        <v-col
          class="px-6 py-0"
          md="9"
          cols="12"
        >
          <v-card
            class="mx-auto"
          >
            <v-card-text>
              <contact-form/>
            </v-card-text>
          </v-card>
        </v-col>

      </v-row>
      <p class="body-2 text-center" v-if="isMobile">
        &copy;&nbsp;
        {{ brand.saas.footerText }}
      </p>
    </v-container>
  </footer>
</template>

<style scoped lang="scss">
@import 'footer-style';
</style>

<script>
import logo from 'static/images/saas-logo.svg'
import brand from 'static/text/brand'
import contactForm from '@/components/guest/contact-form'

export default {
  components: {
    contactForm
  },
  data: () => ({
    logo: logo,
    brand: brand,
    lang: 'en',
    footers: [
      {
        title: 'Company',
        description: ['Team', 'History', 'Contact us', 'Locations'],
        link: ['#team', '#history', '#contact-us', '#locations']
      },
      {
        title: 'Resources',
        description: [
          'Resource',
          'Resource name',
          'Another resource',
          'Final resource'
        ],
        link: [
          '#resource',
          '#resource-name',
          '#another-resource',
          '#final-resource'
        ]
      },
      {
        title: 'Legal',
        description: ['Privacy policy', 'Terms of use'],
        link: ['#privacy-policy', '#terms-of-use']
      }
    ]
  }),
  props: {
    invert: {
      type: Boolean,
      default: false
    }
  },
  computed: {
    isDesktop() {
      const mdUp = this.$store.state.breakpoints.mdUp
      return mdUp.indexOf(this.$mq) > -1
    },
    isMobile() {
      const smDown = this.$store.state.breakpoints.smDown
      return smDown.indexOf(this.$mq) > -1
    },
    langList: function() {
      const list = []
      this.$i18n.locales.map(item => {
        list.push({ text: this.$t('common.' + item.code), value: item.code })
      })
      return list
    }
  },
  mounted() {
    this.lang = this.$i18n.locale
  },
  methods: {
    switchLang: function(val) {
      this.$i18n.setLocale(val)
    }
  }
}
</script>
