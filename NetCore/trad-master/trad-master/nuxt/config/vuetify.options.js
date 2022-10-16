import colors from 'vuetify/lib/util/colors'
import es from 'vuetify/es5/locale/es'
import en from 'vuetify/es5/locale/en'

let darkMode = false
if (typeof Storage !== 'undefined') { // eslint-disable-line
  darkMode = localStorage.getItem('luxiDarkMode') || false
}

/** !IMPORTANT
** If you change the palette bellow,
** don't forget to update /saas-theme/components/Testimonials/Testimonials.vue on const palette as well.
** Make sure the const palette has same value as this const palette bellow
**/

const palette = {
  deepBlue: {
    primary: '#294797', // primary main
    primarylight: colors.indigo.lighten5, // primary light
    primarydark: colors.indigo.darken3, // primary dark
    secondary: '#B57E11', // secondary main
    secondarylight: colors.lightBlue.lighten5, // secondary light
    secondarydark: colors.lightBlue.darken3, // secondary dark
    anchor: colors.indigo.base // link
  },
}

export const theme = {
  ...palette.deepBlue
}

export default {
  rtl: false,
  theme: {
    dark: darkMode === 'true',
    themes: {
      light: {
        ...theme
      },
      dark: {
        ...theme
      }
    },
    options: {
      customProperties: true
    }
  },
  lang: {
    locales: { es, en },
    current: 'es',
  },
}
