<template>
  <v-card
    elevation="2"
    outlined
    tile
  >
    <v-card-text>
      <v-row align="center">
        <div class="col-12 col-lg-4 text-center">
          <div class="pa-15">
            <avatar-user
              size="100"
            />
          </div>
          <verification-steps />
        </div>
        <div class="col-12 col-lg-8">
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
                  :name="$t('common.tipo_doc') | lowercase"
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
                  :name="$t('common.no_doc') | lowercase"
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
                  :name="$t('common.name') | lowercase"
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
                  :name="$t('common.last_name') | lowercase"
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
                  :name="$t('common.email') | lowercase"
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
                  :name="$t('common.country') | lowercase"
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
                  :name="$t('common.phone') | lowercase"
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
                  :name="$t('common.dir') | lowercase"
                  :rules="{required:true}"
                  tag="div"
                  class="col-12 col-lg-6 px-3"
                >
                  <v-text-field
                    v-model="formulario.dir"
                    :label="$t('common.dir')"
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
                  color="secondary"
                  type="submit"
                  :loading="procesando"
                >
                  {{ $t('common.save') }}
                </v-btn>
              </div>
            </v-form>
          </validation-observer>
        </div>
      </v-row>
    </v-card-text>
  </v-card>
</template>

<script>
import comboBox from '@/components/combo-box'
import avatarUser from '@/components/auth/avatar-user'
import verificationSteps from '@/components/auth/verification-steps'

export default {
  name: 'profile',
  layout: 'auth',
  components: {
    comboBox,
    avatarUser,
    verificationSteps
  },
  data: () => ({
    formulario: {
      tipoDoc: null,
      noDoc: null,
      nombres: null,
      apellidos: null,
      email: null,
      pais: null,
      phone: null,
      pws: null,
      repws: null,
      code: null,
      terminos: null
    },
    procesando: false
  }),
  computed: {
    infoUser() {
      return this.$store.getters['local/GET_USER']
    }
  },
  methods: {
    consultaTipoDoc() {
      return this.$store.dispatch('servicios/catalogos/tipoDoc')
    },
    consultarPaises() {
      return this.$store.dispatch('servicios/catalogos/paises')
    },
    consultaPerfil() {
      this.$store.dispatch('servicios/usuario/infoPerfil').then((perfil)=>{
        this.formulario.phone = perfil.celular
        this.formulario.pais = perfil.paisId
        this.formulario.tipoDoc = perfil.TipoIdentificacionId
        this.formulario.noDoc = perfil.documento
        this.formulario.email = perfil.correo
        this.formulario.nombres = perfil.nombres
        this.formulario.apellidos = perfil.apellidos
        this.formulario.dir = perfil.direccion
      })
    },
    actualizarPerfil() {
      this.$store.dispatch('servicios/usuario/actualizarPerfil',this.formulario).then((res)=>{
        this.$swal({
          icon: 'success',
          title: this.$t('common.update_profile'),
          showConfirmButton: false,
          timer: 2500
        })
        this.$store.commit('local/SET_USER',res)
        this.procesando = false
      }).catch(()=>{
        this.procesando = false
      })
    },
    validar() {
      this.procesando = true;
      this.actualizarPerfil()
    }
  },
  mounted() {
    this.consultaPerfil()
  },
  head() {
    return {
      title: this.$t('menu.perfil')
    }
  }
}
</script>

<style scoped>

</style>
