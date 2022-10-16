<template>
  <v-navigation-drawer
    color="secondarydark"
    id="appDrawer"
    permanent
    :mini-variant="mini"
    :touchless='true'
    fixed
    dark
    app
    v-model="mini"
  >
    <v-toolbar color="secondarydark" class="elevation-0">
      <img :src="logo" height="36" alt="Logo Main">
      <v-btn
        icon
        @click.stop="mini = !mini"
      >
        <v-icon>mdi-chevron-left</v-icon>
      </v-btn>
    </v-toolbar>
    <vue-perfect-scrollbar class="drawer-menu--scroll" :settings="scrollSettings">
      <v-list class="pa-0">
        <v-list-item-group v-model="actual">
          <template v-for="(item, i) in menus">
            <v-list-item
              :key="i"
              v-on:click="goItem(item)"
              :title="item.title"
            >
              <v-list-item-icon>
                <v-icon v-text="item.icon" color="white"></v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>{{ item.title }}</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
            <v-divider />
          </template>
        </v-list-item-group>
      </v-list>
    </vue-perfect-scrollbar>
  </v-navigation-drawer>
</template>
<script>


export default {
  name: 'app-drawer',
  props: {
    expanded: {
      type: Boolean,
      default: true
    }
  },
  data() {
    return {
      mini: true,
      scrollSettings: {
        maxScrollbarLength: 160
      },
      drawer: true,
      logo: require('static/images/logo-ico.svg')
    }
  },
  methods: {
    goItem(item) {
      this.mini = true
      if (item.href) {
        this.$router.push(this.localeLocation(item.href))
      } else {
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
      }
    },
    logOut() {
      return this.$store.dispatch('servicios/login/logOut').then(() => {
        this.$router.push(this.localeLocation('/login'))
      }).catch(() => {
        this.$router.push(this.localeLocation('/login'))
      })
    }

  },
  computed: {
    actual: {
      get() {
        return this.$store.getters['local/GET_MENU'].findIndex(i => this.localePath(i.href) === this.localePath(this.$route))
      },
      set() {
        this.mini = true
      }
    },
    menus() {
      return this.$store.getters['local/GET_MENU']
    }
  }
}
</script>


<style lang="scss">
#appDrawer {
  div {
    overflow: hidden;
  }
}

.drawer-menu--scroll {
  height: calc(100vh - 48px);
  overflow: auto;
}

</style>
