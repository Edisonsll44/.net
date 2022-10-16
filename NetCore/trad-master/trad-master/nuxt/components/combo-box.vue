<template>
  <v-select
    :items.sync="items"
    :label="label"
    color="secondary"
    v-model="valor"
    :menu-props="{ button: true, offsetY: true }"
    dense
    outlined
    :loading="spiner"
    :item-text="show"
    :error-messages="errors"
    return-object
    :clearable="limpiar"
    @click:clear="$emit('input',{id:null})"
  >
    <template slot="selection" slot-scope="data">
      {{ data.item[show] | capitalize }}
    </template>
    <template slot="item" slot-scope="data">
      {{ data.item[show] | capitalize }}
    </template>
  </v-select>
</template>

<script>
export default {
  name: 'combo-box',
  data: () => ({
    items: [],
    spiner: false,
    valor: null
  }),
  props: {
    ide: {
      type: String,
      default: 'id'
    },
    errors: {
      type: Array
    },
    label: {
      type: String,
      required: false,
      default: null
    },
    opciones: {
      type: [Array, Function],
      required: false,
      default: () => ([])
    },
    show: {
      type: String,
      required: false,
      default: 'nombre'
    },
    value: {
      type: [String, Number, Object],
      required: false
    },
    limpiar: {
      type: Boolean,
      required: false,
      default: false,
    }
  },
  watch: {
    opciones() {
      this.definir()
    },
    valor(val) {
      if(val){
        this.$emit('input', val)
      }
    },
    value(a,n) {
      if(a!==n){
        this.setear()
      }
    }
  },
  methods: {
    setear: function(){
      if (typeof this.value === 'string' || typeof this.value === 'number' && this.value) {
        this.valor = this.items.find(i => i[this.ide] === this.value)
      }else if(typeof this.value=== 'object' && this.value){
        this.valor = this.items.find(i => i[this.ide] === this.value[this.ide])
      }else{
        this.valor = this.value
      }
    },
    definir: async function() {
      if (typeof this.opciones === 'object') {
        this.items = this.opciones
      } else if (typeof this.opciones === 'function') {
        this.spiner = true
        await this.opciones().then((response) => {
          this.items = response
          this.spiner = false
          return response
        }).catch(() => {
          this.lista = []
          this.spiner = false
        })
      }
      this.setear()
    }
  },
  mounted() {
    this.definir()
  }
}
</script>

<style scoped>

</style>
