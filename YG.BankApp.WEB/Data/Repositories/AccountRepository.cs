using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Context;
using YG.BankApp.WEB.Data.Entities;
using YG.BankApp.WEB.Data.Interfaces;

namespace YG.BankApp.WEB.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _bankContext;

        public AccountRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public void AddAccount(Account entity)
        {
            _bankContext.Add(entity);
            _bankContext.SaveChanges();
        }
    }
}
