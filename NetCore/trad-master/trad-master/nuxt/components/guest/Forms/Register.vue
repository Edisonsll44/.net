<template>
  <AuthFrame
    :title="$t('common.register_title')"
    :subtitle="$t('common.register_subtitle')"
  >
    <div>
      <div class="head">
        <title-secondary :align="isMobile ? 'center' : 'left'">
          {{ $t('common.register') }}
        </title-secondary>
        <v-btn
          :href="routerLink.saas.login"
          class="button-link"
          text
          small
        >
          <v-icon class="icon signArrow">
            mdi-arrow-right
          </v-icon>
          {{ $t('common.register_already') }}
        </v-btn>
      </div>
      <div class="separator">
        <p>
          {{ $t('common.register_or') }}
        </p>
      </div>
      <validation-observer
        ref="registro"
        v-slot="{ handleSubmit }"
      >
        <v-form
          ref="form"
          @submit.prevent="handleSubmit(validar)"
        >
          <v-row class="spacing3">
            <ValidationProvider
              v-slot="{ errors }"
              :name="$t('common.tipo_doc')"
              :rules="{required:true}"
              tag="div"
              class="col-12 col-lg-6 px-3"
            >
              <combo-box
                v-model="formulario.tipoDoc"
                class="require"
                :opciones="consultaTipoDoc"
                :label="$t('common.tipo_doc')"
                :errors="errors"
              />
            </ValidationProvider>
            <ValidationProvider
              v-slot="{ errors }"
              :name="$t('common.no_doc')"
              :rules="{required:true,dni:formulario.tipoDoc}"
              tag="div"
              class="col-12 col-lg-6 px-3"
            >
              <v-text-field
                v-model="formulario.noDoc"
                :label="$t('common.no_doc')"
                :error-messages="errors"
                color="secondary"
                class="require"
                outlined
                dense
              />
            </ValidationProvider>
            <ValidationProvider
              v-slot="{ errors }"
              :name="$t('common.name')"
              :rules="{required:true,alpha_spaces:true}"
              tag="div"
              class="col-12 col-lg-6 px-3"
            >
              <v-text-field
                v-model="formulario.nombres"
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
              :rules="{required:true,alpha_spaces: true}"
              tag="div"
              class="col-12 col-lg-6 px-3"
            >
              <v-text-field
                v-model="formulario.apellidos"
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
              :name="$t('common.email')"
              :rules="{required:true,email:true}"
              tag="div"
              class="col-12 col-lg-12 px-3"
            >
              <v-text-field
                v-model="formulario.email"
                :label="$t('common.email')"
                type="email"
                :error-messages="errors"
                color="secondary"
                class="require"
                outlined
                dense
              />
            </ValidationProvider>
            <ValidationProvider
              v-slot="{ errors }"
              :name="$t('common.country')"
              :rules="{required:true}"
              tag="div"
              class="col-12 col-lg-6 px-3"
            >
              <combo-box
                v-model="formulario.pais"
                class="require"
                :opciones="consultarPaises"
                :label="$t('common.country')"
                :errors="errors"
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
                v-model="formulario.phone"
                :label="$t('common.phone')"
                type="phone"
                :error-messages="errors"
                color="secondary"
                class="require"
                outlined
                dense
              />
            </ValidationProvider>
            <ValidationProvider
              v-slot="{ errors }"
              :name="$t('common.login_password')"
              :rules="{required:true,max:15,min:7}"
              vid="password"
              tag="div"
              class="col-12 col-lg-6 px-3"
            >
              <v-text-field
                v-model="formulario.pws"
                :label="$t('common.login_password')"
                type="password"
                :error-messages="errors"
                color="secondary"
                class="require"
                outlined
                dense
              />
            </ValidationProvider>
            <ValidationProvider
              v-slot="{ errors }"
              :name="$t('common.register_confirm')"
              :rules="{required:true,confirmed:'password'}"
              tag="div"
              class="col-12 col-lg-6 px-3"
            >
              <v-text-field
                v-model="formulario.repws"
                :label="$t('common.register_confirm')"
                type="password"
                :error-messages="errors"
                color="secondary"
                class="require"
                outlined
                dense
              />
            </ValidationProvider>
            <ValidationProvider
              v-slot="{ errors }"
              :name="$t('common.ref_code')"
              :rules="{alpha_num:true}"
              tag="div"
              class="col-12 col-lg-12 px-3"
            >
              <v-text-field
                v-model="formulario.code"
                :label="$t('common.ref_code')"
                :error-messages="errors"
                color="secondary"
                outlined
                dense
              />
            </ValidationProvider>
          </v-row>
          <div class="btn-area">
            <div class="form-helper">
              <ValidationProvider
                v-slot="{ errors }"
                :name="$t('common.form_terms')"
                :rules="{required:true}"
                tag="div"
                class="form-control-label"
              >
                <v-checkbox
                  v-model="formulario.terminos"
                  :label="$t('common.form_terms')"
                  color="secondary"
                  :value="true"
                  :error-messages="errors"
                  required
                />
                <span>
                  <v-dialog
                    v-model="dialog"
                    width="500"
                  >
                    <template v-slot:activator="{ on, attrs }">
                      <a href="#" class="link" v-bind="attrs" v-on="on">
                        {{ $t('common.form_privacy') }}
                      </a>
                    </template>
                    <v-card>
                      <v-card-title class="headline primary lighten-2 mb-5">
                        {{ $t('common.form_privacy') }}
                      </v-card-title>
                      <v-card-text>
                        Los términos y condiciones ("Términos") son un conjunto de términos legales definidos por el propietario de una página web. ... Por lo tanto, es muy importante y muy recomendable que las páginas web tengan términos claros y completos que se ajusten y adapten al sitio web específico y a tus actividades.
                      </v-card-text>
                      <v-divider></v-divider>
                      <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn
                          color="primary"
                          text
                          @click="dialog = false"
                        >
                          {{ $t('fulluse.close') }}
                        </v-btn>
                      </v-card-actions>
                    </v-card>
                  </v-dialog>
              </span>
              </ValidationProvider>
            </div>
            <v-btn
              large
              color="secondary"
              type="submit"
              :loading="procesando"
            >
              {{ $t('common.continue') }}
            </v-btn>
          </div>
        </v-form>
      </validation-observer>
      <v-overlay
        :z-index="10"
        :value="isRegistered"
      >
        <div class="pa-lg-10 pa-1">
          <v-alert
            color="primary"
            icon="mdi-mail"
            border="left"
            prominent
          >
            <v-row class="pa-4">
              <v-col>
                {{ $t('common.after_register') }}
              </v-col>
            </v-row>
            <v-row align="center" class="pb-5">
              <v-col class="text-center">
                <v-btn
                  large
                  color="white"
                  to="/login"
                >
                  {{ $t('saasLanding.header_login') }}
                </v-btn>
              </v-col>
            </v-row>
          </v-alert>
        </div>
      </v-overlay>
    </div>
  </AuthFrame>
</template>

<style lang="scss" scoped>
@import 'form-style';
</style>

<script>
import routerLink from 'static/text/link'
import TitleSecondary from '../Title/TitleSecondary'
import AuthFrame from './AuthFrame'
import comboBox from '@/components/combo-box'
import _ from 'lodash'

export default {
  components: {
    TitleSecondary,
    AuthFrame,
    comboBox
  },
  data() {
    return {
      dialog: false,
      formulario: {
        tipoDoc: null,
        noDoc: null,
        nombres: null,
        apellidos: null,
        email: null,
        pais: null,
        tel: null,
        pws: null,
        repws: null,
        code: null,
        terminos: null
      },
      procesando: false,
      routerLink: routerLink
    }
  },
  methods: {
    validar() {
      this.procesando = true
      this.createUser()
    },
    createUser: _.debounce(function() {
      this.$store.dispatch('servicios/login/registro', this.formulario).then(() => {
        this.procesando = false
        this.$store.commit('sesion/SET_REGISTER')
        setTimeout(() => {
          this.$router.push(this.localePath('/login'))
        }, 5000)
      }).catch(() => {
        this.procesando = false
      })
    }, 200),
    consultaTipoDoc() {
      return this.$store.dispatch('servicios/catalogos/tipoDoc')
    },
    consultarPaises() {
      return this.$store.dispatch('servicios/catalogos/paises')
    }
  },
  computed: {
    isRegistered() {
      return this.$store.getters['sesion/GET_REGISTER']
    },
    isMobile() {
      const smDown = this.$store.state.breakpoints.smDown
      return smDown.indexOf(this.$mq) > -1
    }
  }
}
</script>
