import Vue from 'vue'

Vue.use(require('vue-pusher'), {
  api_key: 'ddb1612baf5be01b1d16',
  options: {
    cluster: 'us2',
    encrypted: true,
  }
});
