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

    async createVaultKeep(vaultKeepData) {
        const res = await api.post('api/vaultKeeps', vaultKeepData)
        logger.log('[Creating vaultKeep]', res.data)
    }

    async removeVaultKeep(vaultKeepId) {
        const res = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
        logger.log('[DELETING VAULTKEEP]', res.data)
        
    }
    
}

export const vaultKeepsService = new VaultKeepsService()