import VuexPersistence from 'vuex-persist'

import Crypto from 'crypto-js'
import Cookie from 'js-cookie'
import { v4 as uuidv4 } from 'uuid'

const cookieName = Crypto.RIPEMD160('cache')

const storageKey = Crypto.RIPEMD160('cache')

const encryptionToken = Cookie.get(cookieName) || uuidv4()
Cookie.set(cookieName, encryptionToken, {
  // secure: true,
  expires: 7
})

export default ({ store }) => {
  new VuexPersistence({
    storage: {
      getItem: () => {
        const store = sessionStorage.getItem(storageKey)
        if (store) {
          try {
            const bytes = Crypto.AES.decrypt(store, encryptionToken)
            return JSON.parse(bytes.toString(Crypto.enc.Utf8))
          } catch (e) {
            sessionStorage.removeItem(storageKey)
          }
        }
        return null
      },
      setItem: (key, value) => {
        const store = Crypto.AES.encrypt(value, encryptionToken).toString()
        return sessionStorage.setItem(storageKey, store)
      },
      removeItem: () => sessionStorage.removeItem(storageKey)
    },
    modules: ['sesion']
  }).plugin(store)
  new VuexPersistence({
    storage: {
      getItem: () => {
        const store = localStorage.getItem(storageKey)
        if (store) {
          try {
            const bytes = Crypto.AES.decrypt(store, encryptionToken)
            return JSON.parse(bytes.toString(Crypto.enc.Utf8))
          } catch (e) {
            localStorage.removeItem(storageKey)
          }
        }
        return null
      },
      setItem: (key, value) => {
        const store = Crypto.AES.encrypt(value, encryptionToken).toString()
        return localStorage.setItem(storageKey, store)
      },
      removeItem: () => localStorage.removeItem(storageKey)
    },
    modules: ['local']
  }).plugin(store)
}
