<template>
  <div class="mx-auto text-center">
    <v-avatar color="secondary" :size="size" class="border-avatar">
      <img
        v-if="getTipo"
        :src="getContanido"
        alt="User Avatar"
      >
      <span class="white--text" v-else>{{ getContanido }}</span>
    </v-avatar>
  </div>
</template>

<script>
export default {
  name: 'avatar-user',
  computed: {
    getTipo() {
      return this.$store.getters['local/GET_USER_AVATAR'].img
    },
    getContanido() {
      return this.$store.getters['local/GET_USER_AVATAR'].value
    }
  },
  props: {
    size: {
      type: String,
      default: '30',
      required: false
    }
  }
}
</script>

<style scoped>

</style>
