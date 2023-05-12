namespace Keepr.Services;

public class VaultKeepsService
{
    private readonly VaultKeepsRepository _repo;
    private readonly VaultsService _vaultsService;

    public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService)
    {
        _repo = repo;
        _vaultsService = vaultsService;
    }

    internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
    {
        // TODO WHO owns the vault?
        //get vault, and check if the user, is the creator of it
        Vault vault = _vaultsService.GetOne(vaultKeepData.VaultId, vaultKeepData.CreatorId);
        if (vaultKeepData.CreatorId != vault.CreatorId)
        {
            throw new Exception("Something went wrong.");
        }
        int id = _repo.CreateVaultKeep(vaultKeepData);
        vaultKeepData.Id = id;
        VaultKeep vaultKeep = this.GetOne(id);
        return vaultKeep;
    }

    internal VaultKeep GetOne(int id)
    {
        VaultKeep vaultKeep = _repo.GetOne(id);
        if (vaultKeep == null)
        {
            throw new Exception("No Vault Keep found.");
        }
        return vaultKeep;
    }

    internal List<KeptKeep> GetVaultKeepsForVault(int vaultId, string userId)
    {
        _vaultsService.GetOne(vaultId, userId);
        List<KeptKeep> keeps = _repo.GetVaultKeepsForVault(vaultId);
        return keeps;
    }

    internal string RemoveVaultKeep(int vaultKeepId, string userId)
    {
        VaultKeep vaultKeep = GetOne(vaultKeepId);
        if (vaultKeep.CreatorId != userId)
        {
            throw new Exception("Something went wrong.");
        }
        _repo.RemoveVaultKeep(vaultKeepId);
        return "Vault Keep deleted.";
    }
}
