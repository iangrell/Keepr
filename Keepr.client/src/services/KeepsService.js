import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "../AppState.js"
import { Keep } from "../models/Keep.js"




class KeepsService {

    async getKeeps() {
        const res = await api.get('api/keeps')
        logger.log('[GETTING KEEPS]', res.data)
        AppState.keeps = res.data.map(k => new Keep(k))
    }

    async getKeepById(keepId) {
        const res = await api.get(`api/keeps/${keepId}`)
        logger.log('[]GOT ONE KEEP', res.data)
        AppState.activeKeep = new Keep(res.data)
    }

    async createKeep(keepData) {
        const res = await api.post('api/keeps', + keepData)
        logger.log('[CREATED KEEP]')
        AppState.keeps.push(new Keep(res.data))
        return res.data
    }

}

export const keepsService = new KeepsService()