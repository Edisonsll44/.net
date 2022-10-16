<template>
  <v-card
    elevation="2"
    outlined
    tile
  >
    <v-card-text>
      <v-row align="center">
        <div class="col-12 col-lg-4 text-center">
          <div class="pa-15">
            <avatar-user
              size="100"
            />
          </div>
          <div class="pt-5">
            <h2 class="primary--text mb-5 linea">{{ infoUser.dt2 }}</h2>
            <span class="text-caption">{{ $t('common.ref_code') }}</span>
            <h3 class="secondary--text pb-2">{{ infoUser.dt3 }}</h3>
            <v-btn
              color="secondarydark"
              class="white--text"
              :to="localePath('/user/profile')"
              depressed
              tile
              elevation="2"
              large
            >
              <v-icon
                left
                dark
              >
                mdi-account
              </v-icon>
              {{ $t('fulluse.my_profile') }}
            </v-btn>
          </div>
          <v-row class="pt-5">
            <div class="col">
              <i class="fa fa-arrow-circle-up"></i>
              <h3>{{ $t('common.saldo') }}</h3>
              <h3 class="secondary--text currency">{{ infoUser.ndt2 | currency }}</h3>
            </div>
            <div class="col">
              <i class="fa fa-arrow-circle-down"></i>
              <h3>{{ $t('common.ref') }}</h3>
              <h3 class="secondary--text">{{ infoUser.ndt1 }}</h3>
            </div>
          </v-row>
          <verification-steps />
        </div>
        <div class="col-12 col-lg-8">
          <v-container fluid>
            <v-row dense>
              <div class="col-12 col-md-6" v-for="item in menus" :key="item.title">
                <v-card
                  :color="current===item.href ? 'secondary' : null"
                  class="mx-auto rounded-0"
                  @click="goItem(item)"
                  v-ripple
                  hover
                >
                  <v-list-item three-line>
                    <v-list-item-content>
                      <v-list-item-title class="headline text-center pb-2">
                        <v-icon class="fa-4x">{{item.icon}}</v-icon>
                      </v-list-item-title>
                      <v-list-item-subtitle class="text-center title">{{ $t('menu.'+item.title)}}</v-list-item-subtitle>
                    </v-list-item-content>
                  </v-list-item>
                </v-card>
              </div>
            </v-row>
          </v-container>
        </div>
      </v-row>
    </v-card-text>
  </v-card>
</template>

<script>
import avatarUser from '@/components/auth/avatar-user'
import verificationSteps from '@/components/auth/verification-steps'

export default {
  name: 'usuario',
  layout: 'auth',
  components: {
    avatarUser,
    verificationSteps
  },
  data: () => ({
    avatar: null,
    saving: false,
    saved: false
  }),
  computed: {
    current() {
      return this.$route.path
    },
    infoUser() {
      return this.$store.getters['local/GET_USER']
    },
    menus(){
      return this.$store.getters['local/GET_MENU']
    }
  },
  methods: {
    uploadImage() {
      this.saving = true
      setTimeout(() => this.savedAvatar(), 1000)
    },
    savedAvatar() {
      this.saving = false
      this.saved = true
    },
    goItem (item) {
      if(item.href){
        this.$router.push(this.localeLocation(item.href))
      }else{
        this.$swal({
          title: this.$t('common.logout_title'),
          html: '<b>'+this.$t('common.logout_question')+'</b>',
          showLoaderOnConfirm: true,
          showCancelButton: true,
          confirmButtonAriaLabel: this.$t('fulluse.no'),
          cancelButtonText: this.$t('fulluse.no'),
          confirmButtonText: this.$t('fulluse.yes'),
          cancelButtonAriaLabel: this.$t('fulluse.yes'),
          preConfirm: (aux) => {
            return this.logOut().then(()=>{
              return aux;
            }).catch(()=>{
              return aux;
            })
          }
        })
      }
    },
    logOut () {
      return this.$store.dispatch('servicios/login/logOut').then(()=>{
        this.$router.push(this.localeLocation('/login'))
      }).catch(()=>{
        this.$router.push(this.localeLocation('/login'))
      })
    }
  },
  head() {
    return {
      title: this.$t('menu.usuario')
    }
  }
}
</script>

<style scoped>

</style>
