<template>
  <div class="animated fadeIn">
    <validation-observer
      ref="deposito"
      v-slot="{ handleSubmit }"
    >
      <v-form
        ref="form-dep"
        @submit.prevent="handleSubmit(validar)"
      >
        <h3 class="primary--text mb-3">{{ $t('common.dep_title') }}</h3>
        <v-row class="pa-2 pa-lg-3">
          <ValidationProvider
            v-slot="{ errors }"
            :name="$t('common.date') | lowercase"
            :rules="{required:true,date_format:formatInDate,date_between:[maximaFecha,minimaFecha]}"
            tag="div"
            class="col-6 pa-0"
          >
            <v-text-field
              v-model="formulario.fecha"
              v-mask="'##/##/####'"
              :label="$t('common.date')"
              :error-messages="errors"
              type="tel"
              color="secondary"
              class="require"
              outlined
              dense
              :disabled="actual<paso"
            />
          </ValidationProvider>
          <ValidationProvider
            v-slot="{ errors }"
            :name="$t('common.hour') | lowercase"
            :rules="{date_format:formatInHour}"
            tag="div"
            class="col-6 pl-2 pa-0"
          >
            <v-text-field
              v-model="formulario.hora"
              v-mask="'##h##'"
              :label="$t('common.hour')"
              :error-messages="errors"
              type="tel"
              color="secondary"
              class=""
              outlined
              dense
              :disabled="actual<paso"
            />
          </ValidationProvider>
          <ValidationProvider
            v-slot="{ errors }"
            :name="$t('fulluse.cuenta') | lowercase"
            :rules="{required:true,inlist:{list:cuentas,label:'cuenta'}}"
            tag="div"
            class="col-12 pa-0"
          >
            <v-text-field
              v-model="formulario.cuenta"
              :label="$t('fulluse.cuenta')"
              :error-messages="errors"
              color="secondary"
              :loading="cargandoCuentas"
              class="require"
              outlined
              dense
              :disabled="actual<paso"
            />
          </ValidationProvider>
          <ValidationProvider
            v-slot="{ errors }"
            :name="$t('fulluse.reference') | lowercase"
            :rules="{required:false}"
            tag="div"
            class="col-12 pa-0"
          >
            <v-text-field
              v-model="formulario.referencia"
              :label="$t('fulluse.reference')"
              :error-messages="errors"
              color="secondary"
              class=""
              outlined
              dense
              :disabled="actual<paso"
            />
          </ValidationProvider>
          <ValidationProvider
            v-slot="{ errors }"
            :name="$t('fulluse.value') | lowercase"
            :rules="{required:true,decimal:2,min_value:validacion.min,max_value:validacion.max}"
            tag="div"
            class="col-12 pa-0"
          >
            <v-text-field
              v-model="formulario.cantidad"
              :label="$t('fulluse.value')"
              :error-messages="errors"
              color="secondary"
              class="require"
              type="number"
              :min="validacion.min"
              :max="validacion.max"
              step="0.01"
              outlined
              dense
              :disabled="actual<paso"
            />
          </ValidationProvider>
          <ValidationProvider
            v-slot="{ errors }"
            :name="$t('common.file') | lowercase"
            :rules="{image:true,size:8000}"
            tag="div"
            class="col-12 pa-0"
          >
            <v-file-input
              v-model="formulario.archivo"
              accept="image/*;capture=camera"
              chips
              :error-messages="errors"
              :label="$t('common.file')"
              :placeholder="$t('common.file_val')"
              outlined
              dense
              prepend-icon=""
            >
            </v-file-input>
          </ValidationProvider>
          <div class="col-12 text-center">
            <v-btn
              :loading="procesando || procesandoArchivo"
              type="submit"
              class="light-blue darken-1 white--text"
              elevation="2"
              plain
              tile
              x-large
            >
              {{ actual !== paso ? $t('fulluse.retry') : $t('common.up_pay') }}
            </v-btn>
            <v-btn
              v-if="actual !== paso"
              @click="limpiar"
              class="error white--text"
              elevation="2"
              plain
              tile
              x-large
              :disabled="procesandoArchivo || procesando"
            >
              {{ $t('fulluse.reject') }}
            </v-btn>
          </div>
          <div class="col-12 pt-5 text-center">
            <span class="caption">{{ $t('common.after_pay') }}</span>
          </div>
        </v-row>
      </v-form>
    </validation-observer>
    <div class="pb-5 gray--darken-1 rounded-3">
      <div class="caption pa-5">
        {{ $t('common.message_dep') }}
      </div>
      <div class="text-center">
        <v-btn
          class="light-blue darken-1 white--text"
          elevation="2"
          plain
          tile
          x-large
          @click="enviarMailCuentas()"
          :loading="procesandoMail"
        >
          {{ $t('common.send_email') }}
        </v-btn>
      </div>
    </div>
  </div>

</template>

<script>
import comboBox from '@/components/combo-box'

const formatInDate = 'DD/MM/YYYY'
const formatInHour = 'HH[h]mm'
export default {
  name: 'deposito',
  components: {
    comboBox
  },
  props: {
    forma: {
      type: Object,
      required: true
    }
  },
  computed: {
    minimaFecha() {
      return this.$moment().format(this.formatInDate)
    },
    maximaFecha() {
      return this.$moment()
        .add(-1, 'month')
        .format(this.formatInDate)
    }
  },
  data: () => ({
    formulario: {
      banco: null,
      tipo: null,
      fecha: null,
      hora: null,
      cuenta: null,
      cantidad: null,
      referencia: null,
      archivo: null
    },
    validacion: {
      min: 1,
      max: 99999
    },
    cuentas: [],
    cargandoCuentas: true,
    procesando: false,
    procesandoArchivo: false,
    procesandoMail: false,
    formatInDate: formatInDate,
    formatInHour: formatInHour,
    paso: 0,
    actual: 0,
    respuesta: {}
  }),
  created() {
    this.consultaCuentas()
  },
  methods: {
    alertaExitosa(respuesta) {
      this.$swal({
        icon: 'success',
        title: respuesta.dt1,
        showConfirmButton: false,
        timer: 2500
      })
      this.limpiar()
    },
    crearPago() {
      this.formulario.forma = this.forma
      this.formulario.fechaCompuesta = this.$moment(
        this.formulario.fecha + ' ' + this.formulario.hora,
        this.formatInDate + ' ' + this.formatInHour
      ).toISOString()
      this.$store
        .dispatch('servicios/pagos/crearPago', this.formulario)
        .then(res => {
          this.$emit('registrado')
          this.actual = 1
          this.respuesta = res
          this.siguientePaso()
        })
        .catch(() => {
          this.actual = 0
          this.procesando = false
        })
    },
    siguientePaso() {
      if (this.paso > this.actual) {
        if (this.actual === 0) {
          this.crearPago()
        }
        if (this.actual === 1) {
          this.subirArchivo(this.respuesta)
        }
      } else {
        this.alertaExitosa(this.respuesta)
      }
    },
    subirArchivo(respuesta) {
      this.procesando = false
      this.procesandoArchivo = true
      this.formulario.id = respuesta.id
      this.$store.dispatch('servicios/pagos/subirArchivoPago', this.formulario).then(() => {
        this.$emit('registrado')
        this.actual = 2
        this.procesandoArchivo = false
        this.alertaExitosa(respuesta)
      }).catch(() => {
        this.actual = 1
        this.procesandoArchivo = false
      })
    },
    validar() {
      this.procesando = true
      this.paso = this.formulario.archivo ? 2 : 1
      this.siguientePaso()
    },
    limpiar() {
      this.formulario.banco = null
      this.formulario.tipo = null
      this.formulario.fecha = null
      this.formulario.hora = null
      this.formulario.cuenta = null
      this.formulario.cantidad = null
      this.formulario.referencia = null
      this.formulario.archivo = null
      this.formulario.id = null
      this.$refs.deposito.reset()
      this.procesando = false
      this.procesandoArchivo = false
      this.paso = 0
      this.actual = 0
    },
    consultaCuentas() {
      this.cargandoCuentas = true
      this.$store.dispatch('servicios/catalogos/cuentas').then((cuentas) => {
        this.cuentas = cuentas
        this.cargandoCuentas = false
      })
    },
    enviarMailCuentas() {
      this.procesandoMail = true
      return this.$store
        .dispatch('servicios/pagos/mailCuentas')
        .then(res => {
          this.$swal({
            icon: 'success',
            title: res.dt1,
            showConfirmButton: false,
            timer: 2500
          })
          this.procesandoMail = false
        })
        .catch(() => {
          this.procesando = false
        })
    }
  }
}
</script>

<style scoped>
</style>
