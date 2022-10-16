<template>
  <div class="page-wrap">
    <hidden point="mdUp">
      <div class="logo logo-header">
        <nuxt-link :to="routeLink.saas.home">
          <img :src="logo" alt="logo">
          <span class="use-text-title">
            {{ brand.saas.projectName }}
          </span>
        </nuxt-link>
      </div>
    </hidden>
    <v-container class="inner-wrap max-md">
      <v-btn
        :href="routeLink.saas.home"
        icon
        class="backtohome"
      >
        <i class="ion-ios-home-outline" />
        <i class="ion-ios-arrow-thin-left" />
      </v-btn>
      <div class="decoration">
        <svg class="left-deco">
          <use xlink:href="/images/saas/deco-bg-left.svg#main" />
        </svg>
        <svg class="right-deco">
          <use xlink:href="/images/saas/deco-bg-right.svg#main" />
        </svg>
      </div>
      <v-card class="form-box fragment-fadeUp">
        <div class="full-form-wrap">
          <h3 class="use-text-title title-contact pb-3 text-center">
            {{ $t('common.contact_title2') }}
          </h3>
          <p class="desc use-text-subtitle2 text-center">
            {{ $t('common.contact_subtitle') }}
          </p>
          <div class="form">
            <validation-observer
              ref="registro"
              v-slot="{ handleSubmit }"
            >
              <v-form
                ref="form"
                @submit.prevent="handleSubmit(validate)"
              >
                <v-row class="spacing6">
                  <v-col cols="12" sm="6" class="px-6">
                    <ValidationProvider
                      v-slot="{ errors }"
                      :name="$t('common.name')"
                      :rules="{required:true,alpha_spaces:true}"
                      tag="div"
                    >
                      <v-text-field
                        v-model="formulario.nombre"
                        :error-messages="errors"
                        :label="$t('common.form_name')"
                        color="white"
                        class="input light"
                        filled
                        required
                      />
                    </ValidationProvider>
                  </v-col>
                  <v-col cols="12" sm="6" class="px-6">
                    <ValidationProvider
                      v-slot="{ errors }"
                      :name="$t('common.last_name')"
                      :rules="{required:true,alpha_spaces:true}"
                      tag="div"
                    >
                      <v-text-field
                        v-model="formulario.apellido"
                        :label="$t('common.last_name')"
                        color="white"
                        class="input light"
                        filled
                        required
                        :error-messages="errors"
                      />
                    </ValidationProvider>
                  </v-col>
                  <v-col cols="12" sm="6" class="px-6">
                    <ValidationProvider
                      v-slot="{ errors }"
                      :name="$t('common.email')"
                      :rules="{required:true,email:true}"
                      tag="div"
                    >
                      <v-text-field
                        v-model="formulario.email"
                        :label="$t('common.form_email')"
                        class="input light"
                        color="white"
                        filled
                        required
                        :error-messages="errors"
                      />
                    </ValidationProvider>
                  </v-col>
                  <v-col cols="12" sm="6" class="px-6">
                    <ValidationProvider
                      v-slot="{ errors }"
                      :name="$t('common.phone')"
                      :rules="{required:true}"
                      tag="div"
                    >
                      <v-text-field
                        v-model="formulario.telefono"
                        :label="$t('common.form_phone')"
                        color="white"
                        class="input light"
                        filled
                        :error-messages="errors"
                      />
                    </ValidationProvider>
                  </v-col>
                </v-row>
                <div class="btn-area flex">
                  <v-btn
                    :block="isMobile"
                    color="secondary"
                    @click="validate"
                    large
                    :loading="procesando"
                  >
                    {{ $t('common.form_send') }}
                  </v-btn>
                </div>
              </v-form>
            </validation-observer>
          </div>
        </div>
      </v-card>
    </v-container>
  </div>
</template>

<style lang="scss" scoped>
@import 'form-style';
@import '../Title/title-style';
</style>

<script>
import logo from 'static/images/saas-logo.svg'
import brand from 'static/text/brand'
import link from 'static/text/link'
import Hidden from '../Hidden'
import _ from 'lodash'

export default {
  components: {
    Hidden
  },
  data() {
    return {
      valid: true,
      snackbar: false,
      checkbox: false,
      logo: logo,
      brand: brand,
      routeLink: link,
      procesando: false,
      formulario: {
        nombre: null,
        apellido: null,
        telefono: null,
        email: null
      }
    }
  },
  methods: {
    validate() {
      if (this.$refs.form.validate()) {
        this.snackbar = true
        ;(this.procesando = true), this.sendMail()
      }
    },
    sendMail: _.debounce(function() {
      this.$store
        .dispatch('servicios/landing/contacto', this.formulario)
        .then(result => {
          this.$swal({
           title:this.$t('common.form_post_send'),
            html: `<b>${result.dt1}</b>`
          }),
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
      this.$refs.registros.reset()
      this.procesando = false
    }
  },
  computed: {
    isMobile() {
      const smDown = this.$store.state.breakpoints.smDown
      return smDown.indexOf(this.$mq) > -1
    }
  }
}
</script>
