import { Profile } from "./Account.js"



export class Keep {
    constructor(data) {
        this.id = data.id
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.views = data.views
        this.kept = data.kept
        this.creator = new Profile(data.creator)
        this.creatorId = data.creatorId
    }
}