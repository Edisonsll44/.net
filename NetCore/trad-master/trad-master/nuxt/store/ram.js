export const state = () => ({
  error: {
    show: false,
    obj: {
      data:{}
    }
  }
})
export const mutations = {
  SET_ERROR(state, error) {
    state.error.show = true
    if(error){
      state.error.obj = error
    }else{
      state.error.obj = {
        data:{
          detail:"Existe problemas para comunicarse con el servidor, vuelve a intentar"
        }
      }
    }
  },
  SET_ERROR_STATUS(state, status) {
    state.error.show = !!status
  }
}
export const getters = {
  GET_ERROR(state) {
    return state.error.obj
  },
  GET_ERROR_STATUS(state) {
    return state.error.show
  }
}
