<template>
  <AuthFrame
    :title="$t('common.login_title')"
    :subtitle="$t('common.login_subtitle')"
  >
    <div>
      <div class="head">
        <title-secondary :align="isMobile ? 'center' : 'left'">
          {{ $t('common.login') }}
        </title-secondary>
        <v-btn
          :href="routerLink.saas.register"
          class="button-link"
          text
          small
        >
          <v-icon class="icon signArrow">
            mdi-arrow-right
          </v-icon>
          {{ $t('common.login_create') }}
        </v-btn>
      </div>
      <div class="separator">
        <p>
          {{ $t('common.login_or') }}
        </p>
      </div>
      <v-alert
        color="error"
        border="left"
        icon="error"
        transition="scale-transition"
        outlined
        v-model="mensaje"
      >
        {{ $t('common.error_login') }}
      </v-alert>
      <validation-observer
        ref="login"
        v-slot="{ handleSubmit }"
      >
        <v-form
          class="mt-10"
          ref="form"
          :disabled="procesando"
          @submit.prevent="handleSubmit(validar)"
        >
          <v-row class="spacing3">
            <ValidationProvider
              v-slot="{ errors }"
              :name="$t('common.email')"
              :rules="{required:true,email:true}"
              tag="div"
              class="col-12 col-lg-12 px-3"
            >
              <v-text-field
                v-model="formulario.usuario"
                :label="$t('common.email')"
                :error-messages="errors"
                color="secondary"
                class="input"
                filled
                required
              />
            </ValidationProvider>
            <ValidationProvider
              v-slot="{ errors }"
              :name="$t('common.login_password')"
              :rules="{required:true}"
              tag="div"
              class="col-12 col-lg-12 px-3"
            >
              <v-text-field
                v-model="formulario.pws"
                :label="$t('common.login_password')"
                :error-messages="errors"
                color="secondary"
                type="password"
                class="input"
                name="email"
                filled
                required
              />
            </ValidationProvider>
            <div class="col-12 text-right">
              <v-btn
                :href="routerLink.saas.reset"
                class="button-link"
                text
                small
              >
                {{ $t('common.forgot_pasword') }}
              </v-btn>
            </div>
          </v-row>
          <div class="btn-area">
            <v-btn
              large
              block
              color="secondary"
              type="submit"
              :loading="procesando"
            >
              {{ $t('common.continue') }}
            </v-btn>
          </div>
        </v-form>
      </validation-observer>
      <v-dialog
        v-model="otp"
        persistent
        max-width="390"
      >
        <v-card>
          <v-card-title class="headline">
            {{ $t('common.otp_title') }}
          </v-card-title>
          <v-card-text>
            Se ha enviado un codigo a tu celular para verificar tu identidad.
          </v-card-text>
          <v-container>
            <validation-observer
              ref="otp"
              v-slot="{ handleSubmit }"
            >
              <v-form @submit.prevent="handleSubmit(validarOtp)" id="otp-form">
                <v-container>
                  <v-row>
                    <ValidationProvider
                      v-slot="{ errors }"
                      :name="$t('common.code')"
                      :rules="{required:true}"
                      tag="div"
                      class="col-12"
                    >
                      <v-text-field
                        v-model="formulario.otp"
                        :label="$t('common.code')"
                        color="secondary"
                        :error-messages="errors"
                        class="input"
                        counter="5"
                        :hint="$t('common.code_feed')"
                        filled
                        required
                      />
                    </ValidationProvider>
                  </v-row>
                </v-container>
              </v-form>
            </validation-observer>
          </v-container>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn
              color="orange darken-1"
              text
              @click="validar"
            >
              {{ $t('common.resend') }}
            </v-btn>
            <v-btn
              color="green darken-1"
              text
              form="otp-form"
              type="submit"
            >
              {{ $t('common.validate') }}
            </v-btn>
          </v-card-actions>
          <v-overlay
            :absolute="true"
            :value="procesando"
          >
            <v-progress-circular
              :size="50"
              color="secondary"
              indeterminate
            ></v-progress-circular>
          </v-overlay>
        </v-card>
      </v-dialog>
    </div>
  </AuthFrame>
</template>

<style lang="scss" scoped>
@import 'form-style';
</style>

<script>
import routerLink from 'static/text/link'
import TitleSecondary from '../Title/TitleSecondary'
import SocialAuth from './SocialAuth'
import AuthFrame from './AuthFrame'
import _ from 'lodash'

export default {
  components: {
    SocialAuth,
    TitleSecondary,
    AuthFrame
  },
  data: () => ({
    routerLink: routerLink,
    procesando: false,
    mensaje: false,
    otp: false,
    formulario: {
      usuario: null,
      pws: null,
      otp: null
    }
  }),
  methods: {
    validar() {
      this.procesando = true
      this.enviarOTP()
    },
    validarOtp() {
      this.procesando = true
      this.login()
    },
    limpiar() {
      this.formulario.usuario = null
      this.formulario.pws = null
      this.formulario.otp = null
      this.$refs.login.reset()
      this.procesando = false
    },
    enviarOTP: _.debounce(function() {
      this.$store
        .dispatch('servicios/login/validarOTP', this.formulario)
        .then(response => {
          this.mensaje = false
          this.otp = true
          this.procesando = false
        })
        .catch(error => {
          this.procesando = false
          this.mensaje = true
          this.otp = false
          if (error.response.status === 502) {
            this.$swal({
              title: 'Error!',
              html: `<b>${error.response.data}</b>`,
              showLoaderOnConfirm: true,
              showCancelButton: true,
              confirmButtonAriaLabel: this.$t('fulluse.no'),
              cancelButtonText: this.$t('fulluse.no'),
              confirmButtonText: this.$t('fulluse.yes'),
              cancelButtonAriaLabel: this.$t('fulluse.yes'),
              preConfirm: aux => {
                return this.sendMail()
                  .then(() => {
                    this.limpiar()
                    return aux
                  })
                  .catch(() => {
                    return aux
                  })
              }
            })
          } else {
            this.limpiar()
          }
        })
    }, 200),
    login() {
      this.$store
        .dispatch('servicios/login/login', this.formulario)
        .then(() => {
          this.procesando = false
          this.$router.push(this.localePath('/user'))
        })
        .catch(() => {
          this.procesando = false
        })
    },
    sendMail() {
      return this.$store
        .dispatch('servicios/login/sendMailBienvenida', this.formulario)
        .then(() => {
          this.$router.push(this.localePath('/login'))
        })
        .catch(() => {
          this.$router.push(this.localePath('/login'))
        })
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
