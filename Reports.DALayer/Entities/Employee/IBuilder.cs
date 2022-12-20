using Reports.DALayer.Models;

namespace Reports.DALayer.Entities.Employee;

public interface IBuilder
{
    IBuilder SetNameAndSurname(string? name, string? surname);
    IBuilder SetStatus(int id);

    IBuilder SetSubordinates(List<Employee> employees);
    IBuilder SetLeader(Guid id);
    IBuilder SetAccount(Account account);

    Employee Build();
}