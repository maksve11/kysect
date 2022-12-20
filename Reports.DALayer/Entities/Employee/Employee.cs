using System.Collections.Immutable;
using Reports.DALayer.Models;
using Reports.DALayer.Tools;

namespace Reports.DALayer.Entities.Employee;

public class Employee : IEquatable<Employee>
{
    public Employee() { }

    public Guid? LeaderId { get; set; }
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public Account? Account { get; set; }

    public EmployeeStatus? Status { get; set; }
    public List<Employee>? Subordinates { get; set; }

    public void AddSubordinates(Employee employee)
    {
        if ((bool)Subordinates?.Contains(employee))
            throw new DaException("this employee already yet");
        if (Status <= employee.Status)
            throw new DaException("this employee can't add because status");
        Subordinates?.Add(employee);
    }

    public void RemoveSubordinates(Employee employee)
    {
        if ((bool)Subordinates?.Contains(employee))
            throw new DaException("this employee doesn't here");
        Subordinates?.Remove(employee);
    }

    public bool Equals(Employee? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Subordinates != null && Id.Equals(other.Id) && Name == other.Name && Surname == other.Surname && Subordinates.Equals(other.Subordinates);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Employee)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Surname, Subordinates);
    }
}