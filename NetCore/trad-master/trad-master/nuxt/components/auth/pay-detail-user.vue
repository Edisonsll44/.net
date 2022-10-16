<template>
  <v-card class="ma-1 animated infinity" elevation="4" :class="{'shake':mover}">
    <v-card-text>
      <v-row align="center" class="ma-0 pa-0">
        <div class="col-12 col-lg-7">
          <div>
            <div v-for="(key, index) in showArray"
                 :key="index">
              <span><b>{{ $t('database.' + key.value) }}: </b>{{ serializar(key) }}</span>
            </div>
          </div>
        </div>
        <div class="col-6 col-lg-3 text-center">
          <v-btn
            small
            color="primary"
            dark
            class="text-transform-none"
            v-on:click="enviarData"
          >
            <v-icon left>
              mdi-cash
            </v-icon>
            {{ $t('fulluse.detail') }}
          </v-btn>
        </div>
        <div class="col-6 col-lg-2 text-right" :class="$t('colors.'+item.estado)+'--text'">
          <h3 class="currency">{{ item.valor | currency }}</h3>
          <span class="caption">{{ item.estado | capitalize }}</span>
        </div>
      </v-row>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  name: 'pay-detail-user',
  props: {
    item: {
      type: Object
    },
    showArray: {
      type: Array
    }
  },
  watch: {
    'item.new'(val){
      this.mover = val
      setTimeout(()=>{
        this.mover = !this.mover
      },2000)
      if(val){
        this.enviarData()
      }
    }
  },
  data: () => ({
    mover: false,
  }),
  methods: {
    serializar(key) {
      if (key.filter) {
        return this.$options.filters[key.filter](this.item[key.value])
      } else {
        return this.item[key.value]
      }
    },
    enviarData() {
      this.$emit('input', this.item)
    },
  }
}
</script>

<style scoped>

</style>
