namespace Keepr.Services;

public class VaultsService
{
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
        _repo = repo;
    }

    internal Vault CreateVault(Vault vaultData)
    {
        int vaultId = _repo.CreateVault(vaultData);
        vaultData.Id = vaultId;
        Vault vault = this.GetOne(vaultId, vaultData.CreatorId);
        return vault;
    }

    internal Vault EditVault(Vault vaultData)
    {
        Vault originalVault = GetOne(vaultData.Id, vaultData.CreatorId);

        if (originalVault.CreatorId != vaultData.CreatorId)
        {
            throw new Exception("Something went wrong.");
        }

        originalVault.Name = vaultData.Name ?? originalVault.Name;
        originalVault.Description = vaultData.Description ?? originalVault.Description;
        originalVault.Img = vaultData.Img ?? originalVault.Img;
        originalVault.IsPrivate = vaultData.IsPrivate != null ? vaultData.IsPrivate : originalVault.IsPrivate;

        _repo.EditVault(originalVault);
        originalVault.UpdatedAt = DateTime.Now;
        return originalVault;


    }

    internal List<Vault> GetMyVaults(string userId)
    {
        List<Vault> vaults = _repo.GetMyVaults(userId);
        return vaults;
    }

    internal Vault GetOne(int vaultId, string userId)
    {

        Vault vault = _repo.GetOne(vaultId);
        if (vault == null)
        {
            throw new Exception("No Vault found with this ID.");
        }

        if (vault.IsPrivate == true && userId != vault.CreatorId)
        {
            throw new Exception("Something went wrong.");
        }

        return vault;
    }

    internal List<Vault> GetProfileVaults(string profileId, string userId)
    {
        // TODO filter out private vaults if not the owner
        //REFRENCE help reviews get all restaurants
        List<Vault> vaults = _repo.GetProfileVaults(profileId);
        List<Vault> filteredVaults = vaults.FindAll(v => v.IsPrivate == false || v.CreatorId == userId);

        return filteredVaults;
    }

    internal string Remove(int vaultId, string userId)
    {
        Vault vault = GetOne(vaultId, userId);
        if (vault.CreatorId != userId)
        {
            throw new Exception("Something went wrong.");
        }
        _repo.Remove(vaultId);
        return "Vault deleted.";
    }
}
