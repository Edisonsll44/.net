<template>
  <v-card
    :class="type"
    class="pricing"
  >
    <div class="title-card">
      <p>{{ title }}</p>
      <h4 class="display-1">
        <template v-if="price > 0">
          <span>$</span>{{ calculatePrice }}
        </template>
        <h2 v-else>
          <i class="fas fa-award"></i>
        </h2>
      </h4>
    </div>
    <ul>
      <li v-for="(item, index) in featureList" :key="index">
        {{ item }}
      </li>
    </ul>
    <div class="btn-area">
      <p class="desc">{{ desc }}</p>
      <v-btn
        :color="type === 'basic' ? 'secondary' : 'primary'"
        class="button"
        large
        @click="generarUrl()"
      >
        {{ $t('saasLanding.header_register') }}
      </v-btn>
    </div>
  </v-card>
</template>

<style lang="scss" scoped>
@import 'cards-style';
</style>

<script>
export default {
  props: {
    title: {
      type: String,
      required: true
    },
    price: {
      type: Number,
      required: true
    },
    featureList: {
      type: Array,
      required: true
    },
    desc: {
      type: String,
      required: true
    },
    type: {
      type: String,
      default: ''
    }
  },
  computed: {
    calculatePrice() {
      return this.price > 0 ? this.price : 'Gratis'
    }
  },
  methods: {
    generarUrl() {
      if (this.title != 'Académico')
        this.$store
          .dispatch('servicios/landing/funcionalidad', this.title)
          .then(response => {
            window.open(response.v1, '_blank')
          })
          .catch(() => {})
    }
  }
}
</script>
