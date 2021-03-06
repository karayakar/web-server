import Vue from 'vue'
import Vuex from 'vuex'
import * as types from './mutation_types'

/**
 * Root Scope of VUEX
 */
import * as getters from './getters'

/**
 * Module Scope of VUEX
 */
import auth from './modules/auth'


Vue.use(Vuex)


/**
 * Export
 */
export default new Vuex.Store({
    getters,
    modules: {
        auth,
    },
    strict: true
})
