import esG from 'vee-validate/dist/locale/es.json'
import enG from 'vee-validate/dist/locale/en.json'

const es = {
  'dni': 'El campo {_field_} debe ser válido.',
  'date_between': 'El campo {_field_} debe estar entre {min} y {max}.',
  'date_format': 'El campo {_field_} debe tener formato {format} válido.',
  'decimal':'El campo {_field_} debe tener máximo {decimals} decimales.',
  'year_between':'El campo {_field_} de estar entre {min} y {max}.',
  'object':'El campo {_field_} debe ser seleccionado.',
  'inlist':'El campo {_field_} no es válido.',
}
const en = {
  'dni': 'The {_field_} field must be valid.'
}




export default {
  'es':{
    messages: {...esG.messages,...es},
  },
  'en':{
    messages: {...enG.messages,...en},
  }
}
