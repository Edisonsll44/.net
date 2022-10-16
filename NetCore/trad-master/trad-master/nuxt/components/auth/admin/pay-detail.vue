<template>
  <v-col
    class="d-flex"
    cols="12"
  >
    <combo-box
      :opciones="estados"
      v-model="item.estadoId"
    />
  </v-col>
</template>

<script>
import comboBox from '@/components/combo-box'

export default {
  name: 'pay-detail',
  components: {
    comboBox
  },
  data: () => ({
    aux: null,
  }),
  props: {
    item: {
      type: Object
    },
    estados: {
      type: Array
    },
    value: {
      type: [Object, String]
    }
  },
  watch: {
    'item.estadoId': function(nu, an) {
      if (typeof an !== 'string' && nu !== an && nu !== this.aux) {
        this.validarCambio(nu,an)
      }
    }
  },
  methods: {
    validarCambio(nuevo, anterior) {
      this.aux = anterior
      this.$swal({
        title: this.$t('fulluse.status_pay'),
        html: '<b>' + this.$t('fulluse.status_pay_datail') + '</b>',
        showLoaderOnConfirm: true,
        showCancelButton: true,
        confirmButtonText: this.$t('fulluse.acept'),
        confirmButtonAriaLabel: this.$t('fulluse.reject'),
        cancelButtonText: this.$t('fulluse.reject'),
        cancelButtonAriaLabel: this.$t('fulluse.acept'),
        preConfirm: (aux) => {
          return this.actualizarEstado().then(() => {
            this.$emit('input',nuevo)
            return aux
          }).catch(() => {
            this.item.estadoId = this.aux
            this.$emit('input',this.aux)
            return aux
          })
        }
      }).then((result) => {
        if (result.isDismissed) {
          this.item.estadoId = this.value
          this.$emit('input',this.aux)
        }
      })
    },
    actualizarEstado() {
      return this.$store.dispatch('servicios/pagos/actualizarPago', this.item)
    }
  }
}
</script>

<style scoped>

</style>
