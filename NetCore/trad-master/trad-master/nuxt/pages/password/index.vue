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
          {{ $t('common.enter_email') }}
        </p>
      </div>
      <div>
        <validation-observer
          ref="reset"
          v-slot="{ handleSubmit }"
        >
          <v-form
            ref="form"
            @submit.prevent="handleSubmit(validar)"
          >
            <v-row>
              <ValidationProvider
                v-slot="{ errors }"
                :name="$t('common.email')"
                :rules="{required:true,email:true}"
                tag="div"
                class="col-12 px-3"
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
  name: 'reset-password',
  components: {
    AuthFrame,
    TitleSecondary
  },
  data: () => ({
    routerLink: routerLink,
    procesando: false,
    formulario: {
      email: null
    }
  }),
  methods: {
    validar() {
      this.procesando = true
      this.cambioContrasena()
    },
    limpiar() {
      this.procesando = false
      this.formulario.email = null
    },
    cambioContrasena() {
      this.formulario.token = this.$route.params.token
      this.$store.dispatch('servicios/login/olvidoPws', this.formulario).then(() => {
        this.limpiar()
        this.$swal({
          icon: 'success',
          title: this.$t('common.after_reset'),
          showConfirmButton: false,
          timer: 2500
        })
        setTimeout(()=>{
          this.$router.push(this.localePath('/login'))
        },3000)
      }).catch(() => {
        this.limpiar()
      })
    }
  },
  computed: {
    isMobile() {
      const smDown = this.$store.state.breakpoints.smDown
      return smDown.indexOf(this.$mq) > -1
    }
  },
  head() {
    return {
      title: this.$t('menu.forgot')
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
