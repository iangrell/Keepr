namespace Keepr.Repositories;

public class KeepsRepository
{
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
        _db = db;
    }

    public Keep GetOne(int keepId)
    {
        string sql = @"
        SELECT
        keeps.*,
        COUNT(vaultKeeps.id) AS kept,
        creator.*
        FROM keeps
        JOIN accounts creator ON creator.id = keeps.creatorId
        LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
        WHERE keeps.id = @keepId
        GROUP BY (keeps.id)
        ;";
        Keep keep = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
        {
            keep.Creator = creator;
            return keep;
        }, new { keepId }).FirstOrDefault();
        return keep;
    }

    internal int CreateKeep(Keep keepData)
    {
        string sql = @"
        INSERT INTO
        keeps(
            name,
            description,
            img,
            creatorId
        )
        VALUES(
            @Name,
            @Description,
            @Img,
            @CreatorId
        );
        SELECT LAST_INSERT_ID();";

        int keepId = _db.ExecuteScalar<int>(sql, keepData);
        keepData.Id = keepId;
        return keepId;
    }

    internal void EditKeep(Keep originalKeep)
    {
        string sql = @"
        UPDATE keeps
        SET
        name = @Name,
        description = @Description,
        img = @Img,
        views = @Views,
        kept = @Kept
        WHERE id = @Id
        ;";

        _db.Execute(sql, originalKeep);
    }

    internal List<Keep> GetAll()
    {
        string sql = @"
        SELECT
        keeps.*,
        creator.*
        FROM keeps
        JOIN accounts creator ON creator.id = keeps.creatorId;";
        List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
        {
            keep.Creator = creator;
            return keep;
        }).ToList();
        return keeps;
    }

    internal List<Keep> GetProfileKeeps(string profileId)
    {
        string sql = @"
        SELECT
        keeps.*,
        creator.*
        FROM keeps
        JOIN accounts creator ON creator.id = keeps.creatorId
        WHERE keeps.creatorId = @ProfileId
        ;";
        List<Keep> keeps = _db.Query<Keep, Account, Keep>
        (sql, (keeps, creator) => 
        {
            keeps.Creator = creator;
            return keeps;
        }, new{profileId}).ToList();
        return keeps;
    }

    internal void Remove(int keepId)
    {
        string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";
        _db.Execute(sql, new { keepId });
    }
}
