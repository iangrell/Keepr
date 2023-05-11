<template>
  <nav class="navbar navbar-expand-lg navbar-dark bg-light px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <button class="btn btn-outline-dark rounded-pill">Home</button>
      </div>
    </router-link>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <button data-bs-toggle="modal" data-bs-target="#keepCreateFormModal" class="btn">Create Keep</button>
        <button data-bs-toggle="modal" data-bs-target="#vaultCreateFormModal" class="btn">Create Vault</button>
        <!-- <li>
          <router-link :to="{ name: 'About' }" class="btn text-success lighten-30 selectable text-uppercase">
            About
          </router-link>
        </li> -->
      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <Login />
    </div>
  </nav>

  <Modal id="keepCreateFormModal" class="modal">
    <template #header>
      <h5 class="text-dark">Add your Keep</h5>
    </template>
    <template #modalBody>
      <KeepCreateForm />
    </template>
  </Modal>

  <Modal id="vaultCreateFormModal" class="modal">
    <template #header>
      <h5 class="text-dark">Create Vault</h5>
    </template>
    <template #modalBody>
      <VaultCreateForm />
    </template>
  </Modal>
</template>

<script>
import Login from './Login.vue'
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
