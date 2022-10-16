<template>
  <v-data-table
    :headers='headers'
    :items='items'
    :search='search'
    :loading='procesandoC'
    :loading-text="$t('fulluse.process')"
  >
    <template v-slot:top>
      <v-toolbar
        flat
      >
        <v-card-title>
          <v-text-field
            v-model='search'
            append-icon='mdi-magnify'
            :label="$t('fulluse.search')"
            single-line
            hide-details
          ></v-text-field>
        </v-card-title>
        <v-spacer></v-spacer>
        <v-dialog
          v-model='modal'
          max-width='500px'
        >
          <template v-slot:activator='{ on, attrs }' v-if='servicioAgregar'>
            <v-btn
              color='primary'
              dark
              class='mb-2'
              v-bind='attrs'
              v-on='on'
            >
              {{ $t('fulluse.new') }}
            </v-btn>
          </template>
          <v-card>
            <validation-observer
              ref='formCatalog'
              v-slot='{ handleSubmit }'
            >
              <v-form
                @submit.prevent='handleSubmit(save)'
              >
                <v-card-title>
                  <span class='headline'>{{ formTitle }}</span>
                </v-card-title>
                <v-card-text>
                  <slot name='alertNuev' v-if='editedIndex===-1' />
                  <slot name='alertEdit' v-else />
                  <v-container>
                    <v-row>
                      <template v-for='campo in campos'>
                        <ValidationProvider
                          v-if='campo.edit'
                          :key='campo.dbin'
                          v-slot='{ errors }'
                          :name="$t('database.'+campo.dbin) | lowercase"
                          :rules='campo.rules'
                          tag='div'
                          class='col-12 col-lg-12 px-3 pa-lg-0'
                        >
                          <combo-box
                            v-if='campo.combo'
                            v-model='formulario[campo.dbin]'
                            :class='{require:campo.rules.required}'
                            :opciones='catalogos[campo.dbin]'
                            :label="$t('database.'+campo.dbin) | capitalize"
                            :errors='errors'
                            limpiar
                          />
                          <v-text-field
                            v-else
                            v-model='formulario[campo.dbin]'
                            :label="$t('database.'+campo.dbin) | capitalize"
                            :error-messages='errors'
                            color='secondary'
                            :class='{require:campo.rules.required}'
                            outlined
                            dense
                          />
                        </ValidationProvider>
                        <div class='col-12 col-lg-12 px-3 pa-lg-0'
                             v-if='!campo.edit && editedIndex!==-1 && !campo.nedit'>
                          <v-text-field
                            :key='campo.dbin'
                            :value='formulario[campo.dbin]'
                            :label="$t('database.'+campo.dbin) | capitalize"
                            outlined
                            disabled
                            dense
                          />
                        </div>
                      </template>
                    </v-row>
                  </v-container>
                </v-card-text>
                <v-card-actions>
                  <v-spacer></v-spacer>
                  <v-btn
                    color='red darken-1'
                    text
                    @click='close'
                    :disabled='procesandoU'
                  >
                    {{ $t('fulluse.reject') }}
                  </v-btn>
                  <v-btn
                    color='green darken-1'
                    text
                    type='submit'
                    :loading='procesandoU'
                    :disabled='procesandoU'
                  >
                    {{ $t('common.save') }}
                  </v-btn>
                </v-card-actions>
              </v-form>
            </validation-observer>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:item.actions='{ item }'>
      <v-icon
        v-if='servicioEditar'
        small
        :class="{'mr-2' : servicioEliminar}"
        @click='editItem(item)'
      >
        mdi-pencil
      </v-icon>
      <v-icon
        v-if='servicioEliminar'
        small
        @click='deleteItem(item)'
      >
        mdi-delete
      </v-icon>
    </template>
    <template v-slot:no-data>
      {{ $t('fulluse.no_data') }}
    </template>
  </v-data-table>
</template>

<script>
import comboBox from '@/components/combo-box'

export default {
  name: 'adminCatalogos',
  components: {
    comboBox
  },
  props: {
    campos: {
      type: Array,
      required: true
    },
    servicioConsulta: {
      type: String,
      required: true
    },
    servicioAgregar: {
      type: String,
      required: false
    },
    servicioEliminar: {
      type: String,
      required: false
    },
    servicioEditar: {
      type: String,
      required: false
    },
    nombreCatalogo: {
      type: String,
      required: true
    }
  },
  data: () => ({
    search: '',
    borrar: [],
    items: [],
    modal: false,
    modalDelete: false,
    headers: [],
    editedIndex: -1,
    formulario: {},
    procesandoC: true,
    procesandoU: false,
    catalogos: {}
  }),

  computed: {
    formTitle() {
      const n = this.$t('fulluse.new') + ' ' + this.$t('fulluse.' + this.nombreCatalogo)
      const e = this.$t('fulluse.edit') + ' ' + this.$t('fulluse.' + this.nombreCatalogo)
      return this.editedIndex === -1 ? n : e
    }
  },
  watch: {
    modal(val) {
      val || this.close()
    },
    modalDelete(val) {
      val || this.closeDelete()
    }
  },

  created() {
    this.crearTabla()
    this.consultaCatalogo()
  },

  methods: {
    crearTabla() {
      this.campos.map(i => {
        if (i.combo) {
          this.loadCombos(i)
        }
        if (!i.nshow) {
          this.headers.push({
            text: this.$t('database.' + i.dbin),
            sortable: true,
            value: i.dbin
          })
        }
      })
      if (this.servicioEditar || this.servicioEliminar) {
        this.headers.push({ text: this.$t('fulluse.actions'), value: 'actions', sortable: false })
      }
    },

    parseRules(rules) {
      const keys = Object.keys(rules)
      let nRules = {}
      keys.map(i => {
        if (typeof rules[i] === 'string' && rules[i].charAt(0) === '$') {
          nRules[i] = this.formulario[rules[i]]
        } else {
          nRules[i] = rules[i]
        }
      })
      return nRules
    },

    consultaCatalogo() {
      this.procesandoC = true
      this.$store.dispatch(this.servicioConsulta).then((items) => {
        this.items = items
        this.procesandoC = false
      }).catch(() => {
        this.procesandoC = false
      })
    },
    editItem(item) {
      this.editedIndex = this.items.indexOf(item)
      this.formulario = Object.assign({}, item)
      this.modal = true
      // this.$refs.formCatalog.reset()
    },

    deleteItem(item) {
      this.editedIndex = this.items.indexOf(item)
      this.formulario = Object.assign({}, item)
      this.$swal({
        title: this.$t('fulluse.del'),
        html: '<b>' + this.$t('fulluse.del_confir') + '</b>',
        showLoaderOnConfirm: true,
        showCancelButton: true,
        confirmButtonAriaLabel: this.$t('fulluse.yes'),
        cancelButtonText: this.$t('fulluse.no'),
        confirmButtonText: this.$t('fulluse.yes'),
        cancelButtonAriaLabel: this.$t('fulluse.no'),
        preConfirm: (aux) => {
          return this.callDelete(this.formulario).then(() => {
            this.items.splice(this.editedIndex, 1)
            return aux
          }).catch(() => {
            return aux
          })
        }
      })
    },

    close() {
      this.$refs.formCatalog.reset()
      this.modal = false
      this.$nextTick(() => {
        this.formulario = Object.assign({}, {})
        this.editedIndex = -1
      })
    },

    closeDelete() {
      this.modalDelete = false
      this.$nextTick(() => {
        this.formulario = Object.assign({}, {})
        this.editedIndex = -1
      })
    },

    loadCombos(item) {
      if (typeof item.combo === 'string') {
        this.$store.dispatch(item.combo).then((response) => {
          this.catalogos[item.dbin] = response
        }).catch(() => {
          this.catalogos[item.dbin] = []
        })
      } else {
        this.catalogos[item.dbin] = item.combo
      }
    },

    callSave() {
      this.$store.dispatch(this.servicioAgregar, this.formulario).then(() => {
        this.consultaCatalogo()
        this.$swal({
          icon: 'success',
          title: this.$t('fulluse.' + this.nombreCatalogo) + ' ' + this.$t('fulluse.add_suc'),
          showConfirmButton: false,
          timer: 2500
        })
        this.procesandoU = false
        this.close()
      }).catch(() => {
        this.procesandoU = false
      })
    },

    callEdit() {
      this.$store.dispatch(this.servicioEditar, this.formulario).then(() => {
        this.$swal({
          icon: 'success',
          title: this.$t('fulluse.' + this.nombreCatalogo) + ' ' + this.$t('fulluse.edit_suc'),
          showConfirmButton: false,
          timer: 2500
        })
        Object.assign(this.items[this.editedIndex], this.formulario)
        this.procesandoU = false
        this.close()
        this.consultaCatalogo()
      }).catch(() => {
        this.procesandoU = false
      })
    },

    callDelete() {
      return this.$store.dispatch(this.servicioEliminar, this.formulario)
    },

    save() {
      this.procesandoU = true
      if (this.editedIndex > -1) {
        this.callEdit()
      } else {
        this.callSave()
      }
    }
  }
}
</script>

<style scoped>

</style>
