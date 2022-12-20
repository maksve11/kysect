﻿using Reports.DALayer.Models.Accounts;

namespace Reports.DALayer.Entities.Employee;

public interface IBuilder
{
    IBuilder SetNameAndSurname(string? name, string? surname);
    IBuilder SetStatus(int id);

    IBuilder SetSubordinates(List<Employee> employees);
    IBuilder SetLeader(Guid id);
    IBuilder SetAccount(EmployeeAccount account);

    Employee Build();
}