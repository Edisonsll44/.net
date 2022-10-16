export default function({ $axios, store, app, redirect  }) {
  $axios.setHeader('Accept-Language', app.i18n.localeProperties.iso)
  $axios.onRequest(config => {
    config.url = '/api/' + config.url
    if (store.getters['local/GET_STATUS']) {
      $axios.setToken(store.getters['local/GET_TOKEN'], 'Bearer')
    }
  })

  $axios.onError(error => {
    try{
      if(error.response.data.detail==='Usuario no encontrado' || error.response.data.detail==='Token Inválido'){
        error.response.data.detail=app.i18n.t('common.logout_force')
        redirect('/login')
        store.commit('local/CLS_USER')
      }
    }catch (e) {}
    store.commit('ram/SET_ERROR',error.response)
  })
}
