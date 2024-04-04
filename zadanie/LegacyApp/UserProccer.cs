using System;
namespace LegacyApp;

public class UserProccer
{
    public void ClientType(User user)
    {
        if (user.Client.Type == "VeryImportantClient")
        {
            user.HasCreditLimit = false;
        }
        else if (user.Client.Type == "ImportantClient")
        {
            using (var userCreditService = new UserCreditService())
            {
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                creditLimit = creditLimit * 2;
                user.CreditLimit = creditLimit;
            }
        }
        else
        {
            user.HasCreditLimit = true;
            using (var userCreditService = new UserCreditService())
            {
                int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                user.CreditLimit = creditLimit;
            }
        }
    }
}