export default function ({ store, redirect, app: { i18n } }) {
  let locale = i18n.locale === i18n.defaultLocale ? '' : '/' + i18n.locale
  if (store.getters['local/GET_STATUS']) {
    return redirect(locale +'/user')
  }
}
