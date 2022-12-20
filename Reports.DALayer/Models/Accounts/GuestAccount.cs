using Reports.DALayer.Entities.Sources;

namespace Reports.DALayer.Models.Accounts;

public class GuestAccount
{
    public GuestAccount(ISource sourceAcc)
    {
        Source = sourceAcc;
    }

    public ISource Source { get; set; }
}