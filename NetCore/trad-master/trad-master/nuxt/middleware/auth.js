export default function({ store, redirect, app: { i18n } }) {
  let locale = i18n.locale === i18n.defaultLocale ? '' : '/' + i18n.locale
  if (!store.getters['local/GET_STATUS']) {
    store.commit('ram/SET_ERROR', { data: { detail: i18n.t('fulluse.need_auth') } })
    return redirect(locale + '/login')
  }
}
