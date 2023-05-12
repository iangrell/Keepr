namespace Keepr.Repositories;

public class VaultKeepsRepository
{
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal int CreateVaultKeep(VaultKeep vaultKeepData)
    {
        string sql = @"
        INSERT INTO
        vaultKeeps(
            keepId,
            vaultId,
            creatorId
        )
        VALUES(
            @KeepId,
            @VaultId,
            @CreatorId
        );
        SELECT LAST_INSERT_ID()
        ;";
        int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
        vaultKeepData.Id = id;
        vaultKeepData.CreatedAt = DateTime.Now;
        vaultKeepData.UpdatedAt = DateTime.Now;
        return id;
    }

    internal VaultKeep GetOne(int id)
    {
        string sql = "SELECT * FROM vaultKeeps WHERE id = @id;";
        VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { id }).FirstOrDefault();
        return vaultKeep;
    }

    internal List<KeptKeep> GetVaultKeepsForVault(int vaultId)
    {
        string sql = @"
        SELECT
        vaultKeeps.*,
        keeps.*,
        creator.*
        FROM vaultKeeps
        JOIN keeps ON keeps.id = vaultKeeps.keepId
        JOIN accounts creator ON creator.id = keeps.creatorId
        WHERE vaultKeeps.vaultId = @vaultId
        ;";
        List<KeptKeep> keeps = _db.Query<VaultKeep, KeptKeep, Profile, KeptKeep>
        (sql, (vaultKeeps, keeps, creator) =>
        {
            keeps.Creator = creator;
            keeps.VaultKeepId = vaultKeeps.Id;
            return keeps;
        }, new { vaultId }).ToList();
        return keeps;
    }

    internal void RemoveVaultKeep(int vaultKeepId)
    {
        string sql = "DELETE FROM vaultKeeps WHERE id = @vaultKeepId LIMIT 1;";
        _db.Execute(sql, new { vaultKeepId });
    }
}
