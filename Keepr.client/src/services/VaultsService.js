import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import { Vault } from "../models/Vault.js"




class VaultsService {

    async getMyVaults(profileId) {
        const res = await api.get('account/vaults')
        logger.log('[MY VAULTS]', res.data)
        AppState.vaults = res.data.map(v => new Vault(v))
    }

    async getVaultById(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}`)
        logger.log('[GOT ONE VAULT]', res.data)
        AppState.activeVault = new Vault(res.data)
    }

    async createVault(vaultData) {
        const res = await api.post('api/vaults', vaultData)
        logger.log('[CREATE VAULT]')
        AppState.vaults.push(new Vault(res.data))
        return res.data
    }

    async deleteVault(vaultId) {
        const res = await api.delete(`api/vaults/${vaultId}`)
        logger.log('Deleting Vault', res.data)
        AppState.vaults = AppState.vaults.filter(v => v.vaults != vaultId)
    }

}

export const vaultsService = new VaultsService()