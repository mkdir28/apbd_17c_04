using System;
namespace LegacyApp;

public class UserProccer
{
    public void ClientType(User user)
    {
        switch (user.Client.Type)
        {
            case "VeryImportantClient":
                user.HasCreditLimit = false;
                break;
            case "ImportantClient":
                using (var userCreditService = new UserCreditService()) {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
                break;
            default:
                user.HasCreditLimit = true; 
                using (var userCreditService = new UserCreditService()) {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
                break;
        }
    }
}