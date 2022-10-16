import Vue from 'vue'
import validationsLang from '~/static/lang/validations-lang'
import { ValidationProvider, ValidationObserver, extend, localize } from 'vee-validate'

import * as rules from 'vee-validate/dist/rules'
import moment from 'moment'


Object.keys(rules).forEach((i) => {
  // eslint-disable-next-line import/namespace
  extend(i, rules[i])
})

extend('dni', {
  params: ['obj'],
  validate: (value, { obj }) => {
    try{
      if (obj) {
        let a = new Function('value', atob(obj.algoritmo))
        return a(value)
      } else {
        console.log(`Se validó  ${obj.nombre} porque no hay un algoritmo definido`)
        return true
      }
    } catch (e) {
      console.log(`Existe un error en el algoritmo de ${obj.nombre}`)
      return false
    }
  }
})
extend('object', {
  validate: (value) => {
    try {
      return !!value.id
    } catch (e) {
      return false
    }
  }
})
extend('inlist', {
  params: ['list','label'],
  validate: (value, {list,label}) => {
    const index = list.findIndex(i=>i[label]===value)
    return index >= 0
  }
})
extend('date_format', {
  params: ['format'],
  validate: (value, { format }) => {
    const utc = moment(value, format, true)
    return utc.isValid()
  }
})
extend('date_between', {
  params: ['min', 'max'],
  validate: (value, { min, max }) => {
    const format = 'DD/MM/YYYY'
    return moment(value, format).isBetween(moment(min, format), moment(max, format).add(1, 'hours'))
  }
})
extend('decimal', {
  params: ['decimals'],
  validate: (value, { decimals }) => {
    if (!isNaN(value)) {
      try {
        if (Math.floor(value) !== value) {
          return value.toString().split('.')[1].length <= decimals
        }
      } catch (e) {
        return true
      }
    } else {
      return false
    }
  }
})
extend('year_between', {
  params: ['min', 'max'],
  validate: (value, { min, max }) => {
    const format = 'YYYY'
    return moment(value, format).isBetween(moment(min, format), moment(max, format).add(1, 'day'))
  },
  message: 'El campo {_field_} de estar entre {min} y {max}'
})


localize(validationsLang)

let LOCALE = 'es'

Object.defineProperty(Vue.prototype, '$veeLocale', {
  get() {
    return LOCALE
  },
  set(val) {
    LOCALE = val
    localize(val)
  }
})

Vue.component('ValidationProvider', ValidationProvider)
Vue.component('ValidationObserver', ValidationObserver)
