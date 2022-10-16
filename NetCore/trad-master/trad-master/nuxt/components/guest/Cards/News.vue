<template>
  <v-card>
    <div class="d-flex flex-no-wrap justify-space-between">
      <div>
        <v-card-text class="">
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquid aperiam assumenda consequuntur cumque debitis deleniti doloribus expedita molestias nemo nihil numquam optio, provident quaerat, quidem quos repellendus tempora voluptatum. Fugiat.
        </v-card-text>
        <v-card-title
          class="text-h5"
          v-text="'Jhon Nash'"
        ></v-card-title>
        <v-card-subtitle v-text="'Profesional Name'"></v-card-subtitle>
      </div>

      <v-avatar
        class="ma-3"
        size="125"
        tile
      >
        <v-img src="https://cdn.vuetifyjs.com/images/cards/halcyon.png"></v-img>
      </v-avatar>
    </div>
  </v-card>
</template>

<style lang="scss" scoped>
@import 'cards-style';
</style>

<script>
export default {
  props: {
    text: {
      type: String,
      required: true
    },
    img: {
      type: String,
      required: true
    },
    type: {
      type: String,
      required: true
    }
  }
}
</script>
