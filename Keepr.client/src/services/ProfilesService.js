import { AppState } from "../AppState.js"
import { Profile } from "../models/Account.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"
import { Vault } from "../models/Vault.js"
import { Keep } from "../models/Keep.js"



class ProfilesService {

    async getProfile(profileId) {
        const res = await api.get(`api/profiles/${profileId}`)
        logger.log('[GETTING PROFILE]', res.data)
        AppState.activeProfile = new Profile(res.data)
    }

    async getProfileVaults(profileId) {
        const res = await api.get(`api/profiles/${profileId}/vaults`)
        logger.log('[GETTING PROFILE VAULTS]', res.data)
        AppState.vaults = res.data.map(v => new Vault(v))
    }

    async getProfileKeeps(profileId) {
        const res = await api.get(`api/profiles/${profileId}/keeps`)
        logger.log('[GETTING PROFILE KEEPS]', res.data)
        AppState.keeps = res.data.map(k => new Keep(k))
    }

}

export const profilesService = new ProfilesService()