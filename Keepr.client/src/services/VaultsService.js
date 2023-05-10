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

}

export const vaultsService = new VaultsService()