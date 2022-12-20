using Reports.DALayer.Tools;

namespace Reports.DALayer.Models;

public class Account
{
    public Account(string login, string password)
    {
        if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            throw new DaException("Can't create this account");
        Login = login;
        Password = password;
    }

    public string Login { get; private set; }
    public string Password { get; private set; }

    public void ChangePassword(string newPassword)
    {
        if (string.IsNullOrWhiteSpace(newPassword))
            throw new DaException("Can't change password on this account");
        Password = newPassword;
    }
}