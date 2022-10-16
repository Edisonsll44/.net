<template>
  <div class="text-left pt-10">
    <h2 class="primary--text mb-5 linea">{{ $t('fulluse.verification_progres') }}</h2>
    <v-container fluid>
      <v-row dense>
        <v-col v-for="(item, index) in items" :key="index">
          <v-card
            class="mx-auto"
            outlined
            :color="infoUser[item.flag] ? 'light-blue darken-1' : ''"
          >
            <v-list-item three-line>
              <v-list-item-content>
                <div class="overline text-right" v-if="infoUser[item.flag]">
                  <i class="fa fa-check-circle white--text"></i>
                </div>
                <v-list-item-title class="headline text-center">
                  <v-icon
                    large
                    :color="infoUser[item.flag] ? 'white' : ''"
                  >
                    {{ item.icon }}
                  </v-icon>
                </v-list-item-title>
                <v-list-item-subtitle class="text-center" :class="infoUser[item.flag] ? 'white--text' : ''">
                  {{ item.title }}
                </v-list-item-subtitle>
              </v-list-item-content>
            </v-list-item>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
export default {
  name: 'verification-steps',
  computed: {
    infoUser() {
      return this.$store.getters['local/GET_USER']
    }
  },
  data() {
    return {
      items: [
        {
          icon:'mdi-email-alert-outline',
          flag: 'bdt3',
          title: this.$t('fulluse.email_confirmation'),
        },
        {
          icon:'mdi-cellphone-basic',
          flag: 'bdt4',
          title: this.$t('fulluse.phone_confirmation'),
        },
        {
          icon:'mdi-account-check',
          flag: 'bdt5',
          title: this.$t('fulluse.ide_confirmation'),
        }
      ]
    }
  }
}
</script>

<style scoped>
.overline.text-right{
  position: absolute;
  right: 1em;
  top: 2px;
}
</style>
