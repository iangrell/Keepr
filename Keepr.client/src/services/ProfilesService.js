import { AppState } from "../AppState.js"
import { Profile } from "../models/Account.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"



class ProfilesService {

    async getProfile(profileId) {
        const res = await api.get(`api/profiles/${profileId}`)
        logger.log('[GETTING PROFILE]', res.data)
        AppState.activeProfile = new Profile(res.data)
    }

}

export const profilesService = new ProfilesService()