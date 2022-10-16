// ~/plugins/i18n.js
import Vue from 'vue'

export default function({ app }) {
  // beforeLanguageSwitch called right before setting a new locale
  Vue.prototype.$veeLocale=app.i18n.locale
  Vue.prototype.$moment.locale(app.i18n.locale)
  app.vuetify.framework.lang.current = app.i18n.locale
  // this.$vuetify.lang.current = 'sv'
  // if (app.i18n.locale === 'ar') {
  //   app.head.htmlAttrs.dir = 'rtl'
  // } else {
  //   app.head.htmlAttrs.dir = 'ltr'
  // }
  // app.i18n.beforeLanguageSwitch = (oldLocale, newLocale) => {
  //   if (newLocale === 'ar') {
  //     app.vuetify.framework.rtl = true
  //     app.head.htmlAttrs.dir = 'rtl'
  //   } else {
  //     app.vuetify.framework.rtl = false
  //     app.head.htmlAttrs.dir = 'ltr'
  //   }
  // }
}
