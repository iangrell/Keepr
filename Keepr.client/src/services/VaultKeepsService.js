import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import { KeptKeep } from "../models/KeptKeep.js"




class VaultKeepsService {

    async getKeepsInVault(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        logger.log('[GETTING KEPTKEEPS]', res.data)
        AppState.keptKeeps = res.data.map(k => new KeptKeep(k))
    }
}

export const vaultKeepsService = new VaultKeepsService()