const userEmpty = {
  login: false,
  ndt2: 0,
  dt1: null,
  dt2: '',
  dt6: null,
  bdt2: false
}
export const state = () => ({
  user: userEmpty
})
export const mutations = {
  SET_USER(state, user) {
    user.login = true
    state.user = user
  },
  CLS_USER(state) {
    state.user = userEmpty
  },
  SET_SALDO(state, obj) {
    state.user.ndt2 = obj.saldo
  }
}
export const getters = {
  GET_MENU(state) {
    if (state.user.bdt2) {
      return [{ title: 'usuario', icon: 'dashboard', href: '/user' }, {
        title: 'perfil',
        icon: 'mdi-account',
        href: '/user/profile'
      }, { title: 'pagos', icon: 'mdi-cash-multiple', href: '/user/pay' }, {
        title: 'pagos_val',
        icon: 'mdi-bank-check',
        href: '/user/pay/validate'
      }, { title: 'usuarios', icon: 'mdi-account-group', href: '/user/users' }, {
        title: 'configuracion',
        icon: 'settings',
        href: '/user/config'
      }, {
        title: 'logout',
        icon: 'mdi-logout',
        href: null
      }]
    } else {
      return [{ title: 'usuario', icon: 'dashboard', href: '/user' }, {
        title: 'perfil',
        icon: 'mdi-account',
        href: '/user/profile'
      }, { title: 'pagos', icon: 'mdi-cash-multiple', href: '/user/pay' }, {
        title: 'logout',
        icon: 'mdi-logout',
        href: null
      }]
    }
  },
  GET_FLAG(state) {
    return state.user.bdt2
  },
  GET_USER(state) {
    return state.user
  },
  GET_STATUS(state) {
    return state.user.login
  },
  GET_TOKEN(state) {
    return state.user.dt1
  },
  GET_USER_AVATAR(state) {
    const array = state.user.dt2.match(/\b(\w)/g)
    const cadena = array ? array.length > 2 ? `${array[0]}${array[2]}` : array.join('') : '☺'
    return {
      img: !!state.user.dt6,
      value: state.user.dt6 ? state.user.dt6 : cadena
    }
  }
}
