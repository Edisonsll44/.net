<template>
  <div id="appRoot">
    <template>
      <v-app id="inspire" class="app">
        <app-drawer class="app--drawer"></app-drawer>
        <app-toolbar class="app--toolbar"></app-toolbar>
        <v-main class="tttt">
          <div class="page-wrapper pa-lg-10 pa-1">
            <AppTitle/>
            <nuxt/>
          </div>
          <v-footer height="auto" class="pa-3 app--footer primary white--text">
            <span class="caption">&copy; {{ new Date().getFullYear() }}</span>
            <v-spacer></v-spacer>
            <span class="caption mr-1"> Made with love </span>
            <v-icon color="pink" small>favorite</v-icon>
          </v-footer>
        </v-main>
        <notification/>
      </v-app>
    </template>
  </div>
</template>

<script>
import AppDrawer from '@/components/auth/AppDrawer'
import AppToolbar from '@/components/auth/AppToolbar'
import AppTitle from '@/components/auth/AppTitle'
import notification from '@/components/guest/Notification'

export default {
  components: {
    AppDrawer,
    AppToolbar,
    AppTitle,
    notification
  },
  middleware: 'auth',
  data: () => ({
    expanded: true,
    rightDrawer: false,
  }),
  mounted() {
    const preloader = document.getElementById('preloader')
    if (preloader !== null || undefined) {
      preloader.remove()
    }
  }
}
</script>

<style lang="scss" scoped>

.tttt{
  margin-top: 60px;
  margin-left: 66px;
}
.page-wrapper{
  min-height: calc(100vh - 64px - 50px - 81px);
  margin-bottom: 50px;
}

.app--footer{
  position: absolute;
  bottom: 0;
  width: 100%;
}

</style>
