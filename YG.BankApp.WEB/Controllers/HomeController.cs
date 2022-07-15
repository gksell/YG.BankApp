using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Context;
using YG.BankApp.WEB.Data.Interfaces;
using YG.BankApp.WEB.Data.Mapping;
using YG.BankApp.WEB.Models;

namespace YG.BankApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankContext _context;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly IUserMapper _userMapper;

        public HomeController(BankContext bankContext,
            IApplicationUserRepository applicationUserRepository,
            IUserMapper userMapper)
        {
            _context = bankContext;
            _applicationUserRepository = applicationUserRepository;
            _userMapper = userMapper;
        }

        public IActionResult Index()
        {
            var userList = _applicationUserRepository.GetAll();
            //List<UserListModel> userListModel = new List<UserListModel>();
            
            //foreach (var item in userList)
            //{
            //    UserListModel user = new UserListModel();
            //    user.Id = item.Id;
            //    user.Name = item.Name;
            //    user.Surname = item.Surname;

            //    userListModel.Add(user);
                
            //}
            return View(_userMapper.MapToUserList(userList));
        }
    }
}
