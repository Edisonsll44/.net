<template>
  <v-app-bar
    color='secondarydark'
    fixed
    app
    dark
    class='elevation-0'
  >
    <v-spacer></v-spacer>
    <app-notifications />
    <v-btn icon @click='handleFullScreen()'>
      <v-icon>fullscreen</v-icon>
    </v-btn>
    <v-menu :close-on-content-click='false'>
      <template v-slot:activator='{ on }'>
        <v-btn icon large v-on='on' class='mr-lg-4'>
          <avatar-user />
        </v-btn>
      </template>
      <v-list nav class='p-0'>
        <v-list-item-group>
          <template v-for='(item, index) in items'>
            <v-list-item :key='index' class='ma-0' v-if='item.items.length===0' @click='item.click'>
              <v-list-item-icon>
                <v-icon>{{ item.icon }}</v-icon>
              </v-list-item-icon>
              <v-list-item-title v-text='item.title' />
            </v-list-item>
            <v-list-group
              v-else
              :prepend-icon='item.icon'
              :key='index'
            >
              <template v-slot:activator>
                <v-list-item-title>{{ item.title }}</v-list-item-title>
              </template>
              <v-list-item
                class='ma-0 pl-4'
                v-for='subItem in item.items'
                :key='subItem.title+index'
                @click='subItem.click'
              >
                <v-list-item-icon v-if='subItem.icon'>
                  <v-icon>{{ subItem.icon }}</v-icon>
                </v-list-item-icon>
                <v-list-item-title v-text='subItem.title' />
              </v-list-item>
            </v-list-group>
          </template>
        </v-list-item-group>
      </v-list>
    </v-menu>
  </v-app-bar>
</template>
<script>
import avatarUser from '@/components/auth/avatar-user'
import AppNotifications from './AppNotifications'

export default {
  name: 'app-toolbar',
  components: {
    avatarUser,
    AppNotifications
  },
  data: function() {
    return {
      items: [
        {
          icon: 'settings',
          title: this.$t('saasLanding.header_theme'),
          items: [
            {
              icon: 'mdi-lightbulb-on-outline',
              title: this.$t('saasLanding.header_light'),
              click: () => {
                this.setTheme(false)
              }
            },
            {
              icon: 'mdi-lightbulb',
              title: this.$t('saasLanding.header_dark'),
              click: () => {
                this.setTheme(true)
              }
            }
          ]
        },
        {
          icon: 'mdi-alphabet-latin',
          title: this.$t('saasLanding.header_language'),
          items: []
        },
        {
          icon: 'mdi-logout',
          title: this.$t('common.logout_title'),
          items: [],
          click: this.handleLogout
        }
      ]
    }
  },
  mounted() {
    this.setLanguajes()
  },
  methods: {
    setLanguajes() {
      this.items[1].items = []
      const idiomas = this.$i18n.locales
      idiomas.map(i => {
        let aux = {
          title: this.$t('common.' + i.code),
          click: () => {
            this.$i18n.setLocale(i.code)
            this.setLanguajes()
          }
        }
        this.items[1].items.push(aux)
      })
    },
    setTheme(value) {
      localStorage.setItem('luxiDarkMode', value)
      this.$vuetify.theme.dark = value
    },
    handleFullScreen() {
      let doc = window.document
      let docEl = doc.documentElement

      let requestFullScreen = docEl.requestFullscreen || docEl.mozRequestFullScreen || docEl.webkitRequestFullScreen || docEl.msRequestFullscreen
      let cancelFullScreen = doc.exitFullscreen || doc.mozCancelFullScreen || doc.webkitExitFullscreen || doc.msExitFullscreen

      if (!doc.fullscreenElement && !doc.mozFullScreenElement && !doc.webkitFullscreenElement && !doc.msFullscreenElement) {
        requestFullScreen.call(docEl)
      } else {
        cancelFullScreen.call(doc)
      }
    },
    handleLogout() {
      this.$swal({
        title: this.$t('common.logout_title'),
        html: '<b>' + this.$t('common.logout_question') + '</b>',
        showLoaderOnConfirm: true,
        showCancelButton: true,
        confirmButtonAriaLabel: this.$t('fulluse.no'),
        cancelButtonText: this.$t('fulluse.no'),
        confirmButtonText: this.$t('fulluse.yes'),
        cancelButtonAriaLabel: this.$t('fulluse.yes'),
        preConfirm: (aux) => {
          return this.logOut().then(() => {
            return aux
          }).catch(() => {
            return aux
          })
        }
      })
    },
    logOut() {
      return this.$store.dispatch('servicios/login/logOut').then(() => {
        this.$router.push(this.localePath('/login'))
      }).catch(() => {
        this.$router.push(this.localePath('/login'))
      })
    }
  }
}
</script>
