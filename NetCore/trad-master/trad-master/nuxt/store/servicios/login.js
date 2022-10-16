import CryptoJS from 'crypto-js'

export const actions = {
  registro({ commit }, formulario) {
    const data = {
      nombres: formulario.nombres,
      apellidos: formulario.apellidos,
      celular: formulario.phone,
      correo: formulario.email,
      documento: formulario.noDoc,
      tipoidentificacionid: formulario.tipoDoc.id,
      clave: formulario.pws,
      referencia: formulario.code,
      paisId: formulario.pais.id,
      token: 'recaptcha'
    }
    return this.$axios.$post(`RgstUsr/VmRgstUsr`, data)
  },
  olvidoPws({ state }, formulario) {
    const data = {
      email: formulario.email
    }
    return this.$axios.$post(`Usr/VmCmbClv`, data)
  },
  olvidoValidarToken({ state }, token) {
    const data = {
      token: token
    }
    return this.$axios.$post(`Usr/VmVldTk`, data)
  },
  olvidoCambioPws({ state }, formulario) {
    const data = {
      token: formulario.token,
      clave: formulario.pws
    }
    return this.$axios.$post(`Usr/VmUpClv`, data)
  },
  validarCuenta({ state }, token) {
    const data = {
      token: token
    }
    return this.$axios.$post(`Attctn/VmActUsr`, data)
  },
  validarOTP({ state }, formulario) {
    const data = {
      email: formulario.usuario,
      clave: CryptoJS.MD5(formulario.pws)
        .toString()
        .toUpperCase()
    }
    return this.$axios.$post(`Attctn/VmSndTp`, data)
  },
  login({ commit }, formulario) {
    const data = {
      email: formulario.usuario,
      clave: CryptoJS.MD5(formulario.pws)
        .toString()
        .toUpperCase(),
      codigo: formulario.otp
    }
    return this.$axios.$post(`Attctn/VmLggn`, data).then(
      user => {
        commit('local/SET_USER', user, { root: true })
        return Promise.resolve(user)
      },
      error => {
        commit('local/CLS_USER', null, { root: true })
        return Promise.reject(error)
      }
    )
  },
  logOut({ commit, rootState }) {
    const data = {
      token: rootState.local.user.dt1
    }
    commit('local/CLS_USER', null, { root: true })
    commit('sesion/CLS_NOTIFICATION', null, { root: true })
    return this.$axios.$post(`Attctn/VmLgOut`, data)
  },
  sendMailBienvenida({ commit }, formulario) {
    const data = {
      correo: formulario.usuario
    }
    return this.$axios.$post(`RgstUsr/VmSnMl`, data)
  }
}
