export const actions = {
  tipoDoc({ commit }) {
    return this.$axios.$post(`TpDcmnt/VmLst`, {})
  },
  roles({ commit }) {
    return this.$axios.$post(`Rl/VmLst`, {})
  },
  paises({ commit }) {
    return this.$axios.$get(`Ps/VmLstPs`, {})
  },
  estadoPago({ commit }) {
    return this.$axios.$post(`Std/VmLstDt`, {})
  },
  formaPago({ commit }) {
    return this.$axios.$post(`FrmPg/VmLst`, {})
  },
  crearFormaPago({ commit }, formulario) {
    const data = {
      codigo: formulario.codigo,
      componente: formulario.componente.id,
      nombre: formulario.nombre
    }
    return this.$axios.$post(`FrmPg/VmCrt`, data)
  },
  tipoCuenta({ commit }) {
    return this.$axios.$post(`TpCnt/VmLst`, {})
  },
  bancos({ commit }) {
    return this.$axios.$post(`Bnc/VmLst`, {})
  },
  crearBancos({ commit }, formulario) {
    return this.$axios.$post(`Bnc/VmCrt`, formulario)
  },
  cuentas({ commit }) {
    return this.$axios.$post(`Cnt/VmLst`, {})
  },
  crearCuentas({ commit }, formulario) {
    const data = {
      banco: formulario.banco.nombre,
      TipoCuenta: formulario.TipoCuenta.nombre,
      nombres: formulario.nombres,
      cuenta: formulario.cuenta,
      identificacion: formulario.identificacion,
      tipoIdentificacion: formulario.tipoIdentificacion.nombre,
      email: formulario.email,
      bancoId: formulario.banco.id,
      tipoCuentaId: formulario.TipoCuenta.id
    }
    return this.$axios.$post(`Cnt/VmCrt`, data)
  }
}
