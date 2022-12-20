using Reports.DALayer.Entities.Employee;
using Reports.DALayer.Tools;

namespace Reports.DALayer.Models.Accounts;

public class EmployeeAccount
{
    public EmployeeAccount(string login, string password, Employee employee)
    {
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            throw new DaException("Can't create this account");
        Login = login;
        Password = password;
        Employee = employee;
    }

    public string Login { get; private set; }
    public string Password { get; private set; }
    public Employee Employee { get; set; }

    public void ChangePassword(string newPassword)
    {
        if (string.IsNullOrWhiteSpace(newPassword))
            throw new DaException("Can't change password on this account");
        Password = newPassword;
    }
}