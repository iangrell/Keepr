using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keepr.Services;

    public class ProfilesService
    {
        private readonly ProfilesRepository _repo;

    public ProfilesService(ProfilesRepository repo)
    {
        _repo = repo;
    }

    internal Profile GetProfile(string profileId)
    {
        Profile profile = _repo.GetProfile(profileId);
        if (profile == null) throw new Exception("No profile found.");
        return profile;
    }
}
