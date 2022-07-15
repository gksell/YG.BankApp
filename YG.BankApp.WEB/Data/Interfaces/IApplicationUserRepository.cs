using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Entities;

namespace YG.BankApp.WEB.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll();
        ApplicationUser GetById(int id);
    }
}
