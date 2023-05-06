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
        int id = _repo.CreateVault(vaultData);
        vaultData.Id = id;
        return vaultData;
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
}
