using Reports.DALayer.Tools;

namespace Reports.DALayer.Entities.Sources;

public class MailSource : ISource
{
    public MailSource(string name, string mail)
    {
        if (string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(name))
            throw new DaException("can't be this mail or name");
        Mail = mail;
        Name = name;
        Id = Guid.NewGuid();
    }

    public string Name { get; set; }
    public string Mail { get; set; }
    public Guid Id { get; set; }
    public string Author()
    {
        return string.Concat(Name, Mail);
    }
}