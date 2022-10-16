<template>
  <div class="col-12 col-lg-3 col-md-6">
    <v-card
      class="mx-2 all-h"
      elevation="24"
    >
      <v-card-text>
        <v-row align="center">
          <v-col class="text-center">
            <v-icon
              large
              :color="tips.color"
            >
              {{ tips.icon }}
            </v-icon>
          </v-col>
        </v-row>
      </v-card-text>
      <v-list-item two-line>
        <v-list-item-content>
          <v-list-item-title class="title text-center">
            {{ $t('saasLanding.tip_title_' + $vnode.key) }}
          </v-list-item-title>
        </v-list-item-content>
      </v-list-item>
      <v-card-text class="text-justify">
        {{ $t('saasLanding.tip_detail_' + $vnode.key) }}
      </v-card-text>
    </v-card>
  </div>
</template>

<script>
export default {
  name: 'card-tips',
  props: {
    tips: {
      type: Object,
      required: true
    }
  }
}
</script>

<style scoped>
.all-h {
  min-height: 19em;
}
</style>
