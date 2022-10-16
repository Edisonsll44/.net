<template>
  <v-snackbar
    :timeout="3000"
    v-model="snackbar"
    class="notification animated fadeInUp"
  >
    <div class="action text-left">
      <i class="fas fa-exclamation-triangle"></i>
      {{ error.data.detail ? error.data.detail : 'Error no controlado' }}
    </div>
    <template v-slot:action="{ attrs }">
      <v-btn
        v-if="error.data.detail"
        color="secondary"
        class="button"
        v-bind="attrs"
        @click="snackbar = false"
      >
        {{ $t('common.accept') }}
      </v-btn>
      <v-btn
        v-else
        color="red"
        class="button"
        v-bind="attrs"
        @click="downloadString(error,'application/json')"
      >
        Descargar
      </v-btn>
    </template>
  </v-snackbar>
</template>

<style lang="scss" scoped>
@import 'notification-style';
</style>

<script>
import { v4 as uuidv4 } from 'uuid'
export default {
  methods: {
    downloadString(text, fileType) {
      const datos = text.config.data
      text.frontend = { path: location, date: this.$moment().format('LLLL'), data:JSON.parse(datos) }
      let blob = new Blob([JSON.stringify(text, null, 2)], { type: fileType })
      let a = document.createElement('a')
      a.download = 'Error-'+uuidv4()+'.json'
      a.href = URL.createObjectURL(blob)
      a.dataset.downloadurl = [fileType, a.download, a.href].join(':')
      a.style.display = 'none'
      document.body.appendChild(a)
      a.click()
      document.body.removeChild(a)
      setTimeout(function() {
        URL.revokeObjectURL(a.href)
      }, 1500)
      this.snackbar = false
    }
  },
  computed: {
    error() {
      return this.$store.getters['ram/GET_ERROR']
    },
    snackbar: {
      get() {
        return this.$store.getters['ram/GET_ERROR_STATUS']
      },
      set(value) {
        this.$store.commit('ram/SET_ERROR_STATUS', value)
      }
    }
  }
}
</script>
