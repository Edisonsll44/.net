<template>
  <AuthFrame :title="$t('common.register_title')"
             :subtitle="$t('common.validate_continua')">
    <div>
      <div class="head">
        <title-secondary :align="isMobile ? 'center' : 'left'">
          {{ $t('common.reset_pasword') }}
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
          {{ $t('common.login_validate') }}
        </v-btn>
      </div>
      <div class="separator">
        <p>
          {{ $t('common.reset_message') }}
        </p>
      </div>
      <div >
        <validation-observer
          ref="reset"
          v-slot="{ handleSubmit }"
        >
          <v-form
            ref="form"
            @submit.prevent="handleSubmit(validar)"
          >
            <v-row >
              <ValidationProvider
                v-slot="{ errors }"
                :name="$t('common.login_password')"
                :rules="{required:true,max:15,min:7}"
                vid="password"
                tag="div"
                class="col-12 px-3"
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
                class="col-12 px-3"
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
            </v-row>
            <div class="btn-area">
              <v-btn
                large
                block
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
    </div>
  </AuthFrame>
</template>

<script>
import brand from 'static/text/brand'
import routerLink from 'static/text/link'
import AuthFrame from '@/components/guest/Forms/AuthFrame'
import TitleSecondary from '@/components/guest/Title/TitleSecondary'

export default {
  name: 'validation',
  components: {
    AuthFrame,
    TitleSecondary
  },
  data: () => ({
    routerLink: routerLink,
    procesando: false,
    formulario: {
      token: null,
      pws: null
    }
  }),
  methods: {
    validar() {
      this.procesando = true
      this.cambioContrasena()
    },
    cambioContrasena() {
      this.formulario.token = this.$route.params.token
      this.$store
        .dispatch('servicios/login/olvidoCambioPws', this.formulario)
        .then(result => {
          this.procesando = false
          this.$swal({
            title: 'Cambio Exitoso!',
            html: `<b>${result.dt1}</b>`,
            preConfirm: aux => {
              this.$router.push(this.localePath('/login'))
            }
          })
        })
        .catch(() => {
          this.procesando = false
        })
    }
  },
  async validate({ params, store }) {
    return await store
      .dispatch('servicios/login/olvidoValidarToken', params.token)
      .then(() => {
        return true
      })
      .catch(() => {
        return true
      })
  },
  computed: {
    isMobile() {
      const smDown = this.$store.state.breakpoints.smDown
      return smDown.indexOf(this.$mq) > -1
    }
  },
  head() {
    return {
      title: this.$t('menu.change')
    }
  }
}
</script>

<style lang="scss" scoped>
@import './components/guest/Forms/form-style';

.spacing3 {
  min-height: 45vh;
}
</style>
