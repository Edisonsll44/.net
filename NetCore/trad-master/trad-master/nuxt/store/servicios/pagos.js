export const actions = {
  todosPagos({ commit }, formulario) {
    const data = {}
    return this.$axios.$post(`Pg/VmLst`, data)
  },
  todosPagosUsuario({ commit }, formulario) {
    const data = {}
    return this.$axios.$post(`Pg/VmLstPs`, data)
  },
  actualizarPago({ commit }, item) {
    const data = {
      idPago: item.id,
      idEstado: item.estadoId.id
    }
    return this.$axios.$post(`Pg/VmUpPg`, data)
  },
  crearPago({ commit }, formulario) {
    const data = {
      formaPagoId: formulario.forma.id,
      referencia: formulario.referencia,
      fechaPago: formulario.fechaCompuesta,
      valor: formulario.cantidad,
      cuentaDeposito: formulario.cuenta
    }
    return this.$axios.$post(`Pg/VmCrt`, data)
  },
  subirArchivoPago({ commit }, formulario) {
    let form_data = new FormData()
    form_data.append('s', formulario.archivo)
    return this.$axios.$post(`Pg/VmUplF`, form_data, {
      params: { id: formulario.id }
    })
  },
  mailCuentas({ commit }) {
    return this.$axios.$post(`Cnt/VmSndMl`)
  }
}
