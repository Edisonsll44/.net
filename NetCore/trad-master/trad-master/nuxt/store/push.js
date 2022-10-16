export const getters = {
  USER(state, getters, rootState) {
    return {
      canal: "canal-usuario-"+rootState.local.user.id,
      pagoCreado: "pago-creado-usuario",
      pagoActualizado: "pago-actualizado-usuario",
    }
  },
  ADMIN(state, getters, rootState) {
    return {
      canal: "canal-pago",
      pagoCreado: "pago-creado",
      pagoActualizado: "pago-actualizado",
    }
  }
}
