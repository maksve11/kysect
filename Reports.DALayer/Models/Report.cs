using Reports.DALayer.Entities.Message;
using Reports.DALayer.Entities.Sources;

namespace Reports.DALayer.Models;

public class Report
{
    public Report(IMessage message)
    {
        Message = message;
        Id = Guid.NewGuid();
        CreationTime = message.SendTime;
        ReportFinishTime = DateTime.Now;
    }

    public IMessage Message { get; set; }
    public Guid Id { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ReportFinishTime { get; set; }
}