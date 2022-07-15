using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Entities;
using YG.BankApp.WEB.Models;

namespace YG.BankApp.WEB.Data.Mapping
{
    public interface IUserMapper
    {
        List<UserListModel> MapToUserList(List<ApplicationUser> applicationUsers);
        UserListModel MapToUserListById(ApplicationUser applicationUser);
    }
}
