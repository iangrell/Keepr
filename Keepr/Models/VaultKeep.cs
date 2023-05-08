namespace Keepr.Models;

public class VaultKeep : RepoItem<int>
{
    public int KeepId { get; set; }
    public int VaultId { get; set; }
    public string CreatorId { get; set; }
    public Profile Creator { get; set; }
}

public class KeptKeep : Keep
{
    public int VaultKeepId { get; set; }
}