using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Entities;
using YG.BankApp.WEB.Models;

namespace YG.BankApp.WEB.Data.Mapping
{
    public class AccountMapper : IAccountMapper
    {
        public Account MapAdd(AccountCreateModel account)
        {
           return new Account()
            {
                ApplicationUserId = account.ApplicationUserId,
                AccountNumber = account.AccountNumber,
                Balance =account.Balance
            };
        }
    }
}
