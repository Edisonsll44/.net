<template>
  <div>
    <validation-observer
      ref="contacto"
      v-slot="{ handleSubmit }"
    >
      <h3 class="title primary--text mb-4">{{ $t('common.form_contac') }}</h3>
      <v-form
        ref="form"
        @submit.prevent="handleSubmit(validar)"
      >
        <v-row class="spacing3">
          <ValidationProvider
            v-slot="{ errors }"
            :name="$t('common.name')"
            :rules="{required:true,alpha_spaces:true}"
            tag="div"
            class="col-12 col-lg-6 px-3"
          >
            <v-text-field
              v-model="formulario.nombre"
              :label="$t('common.name')"
              :error-messages="errors"
              color="secondary"
              class="require"
              outlined
              dense
            />
          </ValidationProvider>
          <ValidationProvider
            v-slot="{ errors }"
            :name="$t('common.last_name')"
            :rules="{required:true,alpha_spaces:true}"
            tag="div"
            class="col-12 col-lg-6 px-3"
          >
            <v-text-field
              v-model="formulario.apellido"
              :label="$t('common.last_name')"
              :error-messages="errors"
              color="secondary"
              class="require"
              outlined
              dense
            />
          </ValidationProvider>
          <ValidationProvider
            v-slot="{ errors }"
            :name="$t('common.phone')"
            :rules="{required:true}"
            tag="div"
            class="col-12 col-lg-6 px-3"
          >
            <v-text-field
              v-model="formulario.telefono"
              :label="$t('common.phone')"
              :error-messages="errors"
              color="secondary"
              class="require"
              outlined
              dense
            />
          </ValidationProvider>
          <ValidationProvider
            v-slot="{ errors }"
            :name="$t('common.email')"
            :rules="{required:true,email:true}"
            tag="div"
            class="col-12 col-lg-6 px-3"
          >
            <v-text-field
              v-model="formulario.email"
              :label="$t('common.email')"
              :error-messages="errors"
              color="secondary"
              class="require"
              outlined
              dense
            />
          </ValidationProvider>
        </v-row>
        <div class="btn-area text-center">
          <v-btn
            large
            color="secondary"
            type="submit"
            :loading="procesando"
          >
            {{ $t('common.send') }}
          </v-btn>
        </div>
      </v-form>
    </validation-observer>
  </div>
</template>

<script>
import _ from 'lodash'

export default {
  name: 'contact-form',
  data: () => ({
    procesando: false,
    formulario: {
      nombre: null,
      apellido: null,
      telefono: null,
      email: null
    }
  }),
  methods: {
    validar() {
      this.procesando = true
      this.sendMail()
    },
    sendMail: _.debounce(function() {
      this.$store
        .dispatch('servicios/landing/contacto', this.formulario)
        .then(result => {
          this.$swal({
            title: this.$t('common.form_post_send'),
            html: `<b>${result.dt1}</b>`
          })
          this.limpiar()
        })
        .catch(() => {
          this.limpiar()
        })
    }, 200),
    limpiar() {
      this.formulario.nombres = null
      this.formulario.apellidos = null
      this.formulario.celular = null
      this.formulario.correo = null
      this.$refs.contacto.reset()
      this.procesando = false
    }
  }
}
</script>

<style scoped>
</style>
