using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Context;
using YG.BankApp.WEB.Data.Entities;
using YG.BankApp.WEB.Data.Interfaces;

namespace YG.BankApp.WEB.Data.Repositories
{
    public class ApplicationUserRepository :IApplicationUserRepository
    {
        private readonly BankContext _bankContext;

        public ApplicationUserRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public List<ApplicationUser> GetAll()
        {
            return _bankContext.ApplicationUsers.ToList();
        }
        public ApplicationUser GetById(int id)
        {
            return _bankContext.ApplicationUsers.FirstOrDefault(x => x.Id == id);
        }
    }
}
