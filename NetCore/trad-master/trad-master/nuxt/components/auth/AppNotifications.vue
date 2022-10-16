<template>
  <v-menu :close-on-content-click='true' open-on-hover :allow-overflow='false' :offset-x='true' :offset-y='true' tile
          max-height='300' bottom>
    <template v-slot:activator='{ on }'>
      <v-btn icon v-on='on' v-if="notificaciones.length">
        <v-badge
          :content="notificaciones.filter(i => i.new).length"
          :value="notificaciones.filter(i => i.new).length"
          color="green"
          overlap
        >
          <v-icon>notifications</v-icon>
        </v-badge>
      </v-btn>
    </template>
    <v-list nav dense>
      <v-list-item-group active-class="false">
        <v-list-item v-for='(item, index) in notificaciones' :key='index' v-on:mouseleave="readNotification(index)">
          <v-list-item-icon>
            <v-icon>far {{ item.new ? 'fa-envelope' : 'fa-envelope-open' }}</v-icon>
          </v-list-item-icon>
          <v-list-item-content @click="getRoute(item)">
            <v-list-item-title v-text='item.texto'></v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item v-if="notificaciones.length===0">
          <v-list-item-content>
            <v-list-item-subtitle>{{ $t('fulluse.no_notifications') }}</v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
      </v-list-item-group>
    </v-list>
  </v-menu>
</template>

<script>
export default {
  name: 'AppNotifications',
  computed: {
    notificaciones() {
      return this.$store.getters['sesion/GET_NOTIFICACIONES']
    },
  },
  destroyed() {
    this.unSubscribePushRol()
  },
  mounted() {
    this.subscribePushRol()
  },
  methods: {
    subscribePushRol() {
      const flag = this.$store.getters['local/GET_USER']
      this.subscribePushUser()
      if (flag) {
        this.subscribePushAdm()
      }
    },
    unSubscribePushRol() {
      const flag = this.$store.getters['local/GET_USER']
      this.unsubscribePushUser()
      if (flag) {
        this.unsubscribePushAdm()
      }
    },
    subscribePushUser() {
      const channel = this.$pusher.subscribe(this.$store.getters['push/USER'].canal)
      channel.bind(this.$store.getters['push/USER'].pagoActualizado, (item) => {
        this.$bus.$emit(this.$store.getters['push/USER'].pagoActualizado, item)
        item.route = { path: this.localePath(`/user/pay`), query: { id: item.id } }
        item.texto = this.$t('push.you_pay') + this.$options.filters.currency(item.valor) + this.$t('push.pay_detail') + item.estado
        this.$store.commit('sesion/SET_NOTIFICACION', item)
        this.notificacionToast(item)
        this.$store.commit('local/SET_SALDO', item)
      })
    },
    subscribePushAdm() {
      const channel = this.$pusher.subscribe(this.$store.getters['push/ADMIN'].canal)
      channel.bind(this.$store.getters['push/ADMIN'].pagoCreado, (item) => {
        this.$bus.$emit(this.$store.getters['push/ADMIN'].pagoCreado, item)
        item.route = { path: this.localePath(`/user/pay/validate`) }
        item.texto = item.nombres + this.$t('push.new_pay') + this.$options.filters.currency(item.valor)
        this.$store.commit('sesion/SET_NOTIFICACION', item)
        this.notificacionToast(item)
      })
    },
    notificacionToast (item){
      setTimeout(()=>{
        const vm = this
        this.$swal({
          title: item.texto,
          toast: true,
          position: 'top-end',
          showConfirmButton: false,
          timer: 10000,
          timerProgressBar: true,
          didOpen: (toast) => {
            toast.addEventListener('click', () => {
              vm.getRoute(item)
            })
          }
        })
      },2000)
    },
    readNotification(index) {
      this.$store.commit('sesion/SET_READ_NOTIFICACION', index)
    },
    getRoute(item) {
      if (item.route) {
        this.$router.push(item.route)
      }
    },
    unsubscribePushUser() {
      this.$pusher.unsubscribe(this.$store.getters['push/USER'].canal)
    },
    unsubscribePushAdm() {
      this.$pusher.unsubscribe(this.$store.getters['push/ADMIN'].canal)
    }
  }
}
</script>

<style scoped>

</style>
