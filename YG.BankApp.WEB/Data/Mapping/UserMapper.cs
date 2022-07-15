using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Entities;
using YG.BankApp.WEB.Models;

namespace YG.BankApp.WEB.Data.Mapping
{
    public class UserMapper :IUserMapper
    {
        public List<UserListModel> MapToUserList(List<ApplicationUser> applicationUsers)
        {
            return applicationUsers.Select(x => new UserListModel()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname
            }).ToList();
            
        }
        public UserListModel MapToUserListById(ApplicationUser applicationUser)
        {
            UserListModel userListModel = new UserListModel();

            userListModel.Id = applicationUser.Id;
            userListModel.Name = applicationUser.Name;
            userListModel.Surname = applicationUser.Surname;
            return userListModel;
        }
    }
}
