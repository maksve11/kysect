using Reports.DALayer.Models;
using Reports.DALayer.Tools;

namespace Reports.DALayer.Entities.Employee;

public class Builder : IBuilder
{
    private readonly Employee _employee = new Employee();
    public IBuilder SetNameAndSurname(string? name, string? surname)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname))
            throw new DaException("Cannot create client without name or surname");
        _employee.Name = name;
        _employee.Surname = surname;
        return this;
    }

    public IBuilder SetStatus(int id)
    {
        switch (id)
        {
            case 1:
                _employee.Status = EmployeeStatus.JuniorManager;
                break;
            case 2:
                _employee.Status = EmployeeStatus.MiddleManager;
                break;
            case 3:
                _employee.Status = EmployeeStatus.TeamLead;
                break;
            default:
                throw new DaException("Can't set this status");
        }

        return this;
    }

    public IBuilder SetSubordinates(List<Employee> employees)
    {
        foreach (Employee emp in employees)
        {
            if (!(bool)_employee.Subordinates?.Contains(emp))
            {
                _employee.AddSubordinates(emp);
            }
        }

        return this;
    }

    public IBuilder SetLeader(Guid id)
    {
        if (_employee.LeaderId != null)
            throw new DaException("there's leader yet");
        _employee.LeaderId = id;
        return this;
    }

    public IBuilder SetAccount(Account account)
    {
        _employee.Account = account;
        return this;
    }

    public Employee Build()
    {
        Employee employee = _employee;
        return employee;
    }
}