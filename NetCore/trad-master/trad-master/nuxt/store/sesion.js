export const state = () => ({
  register: false,
  notificaciones: []
})
export const mutations = {
  SET_REGISTER(state) {
    state.register = true
  },
  SET_NOTIFICACION(state, notificacion) {
    notificacion.new = true
    state.notificaciones.unshift(notificacion)
  },
  SET_READ_NOTIFICACION(state, index) {
    state.notificaciones[index].new = false
    // state.notificaciones.forEach(i=>{
    //   i.new = false
    // })
  },
  CLS_NOTIFICATION(state) {
    state.notificaciones = []
  }
}
export const getters = {
  GET_REGISTER(state) {
    return state.register
  },
  GET_NOTIFICACIONES(state) {
    return state.notificaciones
  }
}
