import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {import('./models/Keep.js').Keep[]} */
  keeps: [],
  /** @type {import('./models/Keep.js').Keep|null} */
  activeKeep: null,
  /** @type {import('./models/Vault.js').Vault[]} */
  vaults: [],
  /** @type {import('./models/Vault.js').Vault[]} */
  myVaults: [],
  /** @type {import('./models/Vault.js').Vault|null} */
  activeVault: null,
  /** @type {import('./models/KeptKeep.js').KeptKeep[]} */
  keptKeeps: [],
  /** @type {import('./models/KeptKeep.js').KeptKeep|null} */
  activeKeptKeep: null,
  /** @type {import('./models/Profile.js').Profile|null} */
  activeProfile: null,
})
