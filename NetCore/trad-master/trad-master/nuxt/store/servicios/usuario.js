export const actions = {
  infoPerfil({ commit }) {
    return this.$axios.$post(`RgstUsr/VmLsUsr`,{})
  },
  actualizarPerfil({ commit },formulario) {
    const data = {
      TipoIdentificacionId: formulario.tipoDoc.id,
      documento: formulario.noDoc,
      nombres: formulario.nombres,
      apellidos: formulario.apellidos,
      correo: formulario.email,
      celular: formulario.phone,
      clave: formulario.pws,
      paisId: formulario.pais.id,
      direccion: formulario.dir,
      imagenPerfil: ""
    }
    return this.$axios.$put(`RgstUsr/VmUpUsr`,data)
  },
  listarUsuarios({ commit }) {
    return this.$axios.$post(`Usr/VmLsUsr`,{})
  },
  rolUsuarios({ commit },formulario) {
    const data = {
      id: formulario.id,
      rolId: formulario.rolId.id
    }
    return this.$axios.$post(`Usr/VmCrRl`,data)
  },
}
