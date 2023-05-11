using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keepr.Repositories;

    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }

    internal Profile GetProfile(string profileId)
    {
        string sql = @"
        SELECT
        id,
        name,
        picture,
        coverImg
        FROM accounts
        WHERE accounts.id = @profileId
        ;";
        // Profile profile = _db.Query<Account>(sql, new{profileId});
        return  _db.QueryFirstOrDefault<Account>(sql, new {profileId});
    }
}
