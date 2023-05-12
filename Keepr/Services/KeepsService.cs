namespace Keepr.Services;

public class KeepsService
{
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
        _repo = repo;
    }

    internal Keep CreateKeep(Keep keepData)
    {
        int keepId = _repo.CreateKeep(keepData);
        Keep keep = this.GetOne(keepId, keepData.CreatorId);
        return keep;
    }

    internal Keep EditKeep(Keep keepData, int keepId)
    {
        Keep originalKeep = this.GetOne(keepData.Id, keepData.CreatorId);

        if (originalKeep.CreatorId != keepData.CreatorId)
        {
            throw new Exception("Something went wrong.");
        }

        originalKeep.Name = keepData.Name ?? originalKeep.Name;
        originalKeep.Description = keepData.Description ?? originalKeep.Description;
        originalKeep.Img = keepData.Img ?? originalKeep.Img;

        _repo.EditKeep(originalKeep);
        originalKeep.UpdatedAt = DateTime.Now;
        return originalKeep;
    }

    internal List<Keep> GetAll()
    {
        List<Keep> keeps = _repo.GetAll();
        return keeps;
    }

    internal Keep GetOne(int keepId, string userId)
    {
        Keep keep = _repo.GetOne(keepId);
        if (keep == null) throw new Exception("No Keep found with that ID.");
        keep.Views++;
        _repo.EditKeep(keep);
        return keep;
    }

    internal List<Keep> GetProfileKeeps(string profileId)
    {
        List<Keep> keeps = _repo.GetProfileKeeps(profileId);
        return keeps;
    }

    internal string Remove(int keepId, string userId)
    {
        Keep keep = GetOne(keepId, userId);
        if (keep.CreatorId != userId)
        {
            throw new Exception("Something went wrong.");
        }
        _repo.Remove(keepId);
        return "Keep deleted.";
    }
}
