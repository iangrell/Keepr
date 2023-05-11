namespace Keepr.Repositories;

public class VaultsRepository
{
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal int CreateVault(Vault vaultData)
    {
        string sql = @"
        INSERT INTO
        vaults(
            name,
            description,
            img,
            isPrivate,
            creatorId
        )
        VALUES(
            @Name,
            @Description,
            @Img,
            @isPrivate,
            @CreatorId
        );
        SELECT LAST_INSERT_ID()
        ;";
        int id = _db.ExecuteScalar<int>(sql, vaultData);
        return id;
    }

    internal void EditVault(Vault originalVault)
    {
        string sql = @"
        UPDATE vaults
        SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = @IsPrivate
        ;";
        _db.Execute(sql, originalVault);
    }

    internal List<Vault> GetMyVaults(string userId)
    {
        string sql = @"
        SELECT
        vaults.*,
        creator.*
        FROM vaults
        JOIN accounts creator ON creator.id = vaults.creatorId
        WHERE vaults.creatorId = @userId
        ;";
        List<Vault> vaults = _db.Query<Vault, Profile, Vault>(sql, (vaults, creator) =>
        {
            vaults.Creator = creator;
            return vaults;
        }, new{userId}).ToList();
            return vaults;
    }

    internal Vault GetOne(int vaultId)
    {
        string sql = @"
        SELECT
        vaults.*,
        creator.*
        FROM vaults
        JOIN accounts creator ON creator.id = vaults.creatorId
        WHERE vaults.id = @vaultId;";
        Vault vault = _db.Query<Vault, Profile, Vault>(sql, (vaults, creator) =>
        {
            vaults.Creator = creator;
            return vaults;
        }, new { vaultId }).FirstOrDefault();
        return vault;
    }

    internal List<Vault> GetProfileVaults(string profileId)
    {
        string sql = @"
        SELECT
        vaults.*,
        creator.*
        FROM vaults
        JOIN accounts creator ON creator.id = vaults.creatorId
        WHERE vaults.creatorId = @ProfileId
        ;";
        List<Vault> vaults = _db.Query<Vault, Account, Vault>
        (sql, (vaults, creator) =>
        {
            vaults.Creator = creator;
            return vaults;
        }, new{profileId}).ToList();
        return vaults;
    }

    internal void Remove(int vaultId)
    {
        string sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1";
        _db.Execute(sql, new { vaultId });
    }
}
