export const actions = {
  funcionalidad({ commit }, funcionalidad) {
    const data = { nombrefuncionalidad: funcionalidad }
    return this.$axios.$post(`Prmtrs/VmSlLnc`, data)
  },
  contacto({ commit }, formulario) {
    const data = {
      nombres: formulario.nombre,
      apellidos: formulario.apellido,
      celular: formulario.telefono,
      correo: formulario.email
    }
    return this.$axios.$post(`Prmtrs/VmSndCtc`, data)
  },
}
