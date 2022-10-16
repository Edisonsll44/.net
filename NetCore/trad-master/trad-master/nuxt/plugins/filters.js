import Vue from 'vue'

import moment from 'moment'

// Vue.filter('minusculas', value => FUNCIONES.minusculas(value))
// Vue.filter('moneda', value => FUNCIONES.puntoMilesMoneda(parseFloat(value)))
// Vue.filter('miles', value => FUNCIONES.puntoMilesDecimal(value))

Vue.filter('dateHuman', (value) => {
  const date = moment.utc(value).local()
  if (date.isValid()) {
    return date.fromNow()
  } else {
    return value
  }
})

Vue.filter('dateD', (value) => {
  const date = moment.utc(value).local()
  if (date.isValid()) {
    return date.format('LL')
  } else {
    return value
  }
})

Vue.filter('datefromISO', (value) => {
  const date = moment.utc(value).local()
  if (date.isValid()) {
    return date.format('DD/MM/YYYY')
  } else {
    return value
  }
})

Vue.filter('capitalize',(value)=>{
  if (typeof value !== 'string') return ''
  value = value.toLowerCase()
  return value.charAt(0).toUpperCase() + value.slice(1)
})

Vue.filter('dateLarge', (value) => {
  const date = moment.utc(value).local()
  if (date.isValid()) {
    return date.format('LLLL')
  } else {
    return value
  }
})

Vue.filter('currency', (value) => {
  if (typeof value === 'number') {
    return value.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
  } else {
    return value
  }
})

Vue.filter('lowercase', (value) => {
  return value.toLowerCase()
})
