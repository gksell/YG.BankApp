using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Context;
using YG.BankApp.WEB.Data.Entities;
using YG.BankApp.WEB.Data.Interfaces;
using YG.BankApp.WEB.Data.Mapping;
using YG.BankApp.WEB.Data.Repositories;
using YG.BankApp.WEB.Models;

namespace YG.BankApp.WEB.Controllers
{
    public class AccountController : Controller
    {
        //private readonly BankContext _context;
        //private readonly IApplicationUserRepository _applicationUserRepository;
        //private readonly IAccountMapper _accountMapper;
        //private readonly IAccountRepository _accountRepository;
        //private readonly IUserMapper _userMapper;
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<ApplicationUser> _applicationUserRepository;

        public AccountController(IRepository<ApplicationUser> applicationUserRepository,
            IRepository<Account> accountRepository)
        {
            _applicationUserRepository = applicationUserRepository;
            _accountRepository = accountRepository;
        }

        //public AccountController(/*BankContext context,*/
        //    IApplicationUserRepository applicationUserRepository,
        //    IUserMapper userMapper,
        //    IAccountRepository accountRepository,
        //    IAccountMapper accountMapper)
        //{
        //    //_context = context;
        //    _applicationUserRepository = applicationUserRepository;
        //    _userMapper = userMapper;
        //    _accountRepository = accountRepository;
        //    _accountMapper = accountMapper;
        //}

        public IActionResult Create(int id)
        {
            var userInfo = _applicationUserRepository.GetById(id);
            
            return View(new UserListModel() { 
                Id =userInfo.Id,
                Name = userInfo.Name,
                Surname = userInfo.Surname
            }); 
        }
        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            //_context.Accounts.Add(new Account
            //{
            //    AccountNumber = model.AccountNumber,
            //    ApplicationUserId = model.ApplicationUserId,
            //    Balance = model.Balance
            //});
            //_context.SaveChanges();
            //_accountRepository.AddAccount(_accountMapper.MapAdd(model));
            _accountRepository.Create(new Account()
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId
            });
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult GetAccountList(int id)
        {
            var query = _accountRepository.QueryableData();
            var accountList = query.Where(x => x.ApplicationUserId == id).ToList();

            var userDetail = _applicationUserRepository.GetById(id);
            var listOfPage = new List<AccountListModel>();

            foreach (var item in accountList)
            {
                listOfPage.Add(new AccountListModel()
                {

                    AccountNumber = item.AccountNumber,
                    Balance = item.Balance,
                    Id = item.Id,
                    ApplicationUserId = item.ApplicationUserId,
                    FullName = userDetail.Name + " " + userDetail.Surname
                });
            }
            
            return View(listOfPage);
        }
         public IActionResult SendMoney(int id)
        {
            var query = _accountRepository.QueryableData();
            var elseAccount = query.Where(x => x.Id != id).ToList();


            var list = new List<AccountListModel>();

            ViewBag.SenderId = id;
            foreach (var item in elseAccount)
            {
                list.Add(new AccountListModel()
                {
                    AccountNumber = item.AccountNumber,
                    Balance = item.AccountNumber,
                    ApplicationUserId = item.ApplicationUserId,
                    Id = item.Id
                });
            }

            return View(new SelectList(list,"Id","AccountNumber"));
        }
        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {

            // Sorun 1 !!! Eğer bir hesaptan para düştüğünde bağlantı giderse
            //işlem yarıda kesilirse para kaybı yaşanacak !
            // Sorun 2 Hesap kontrolleri yapılmalı
            var senderAccount = _accountRepository.GetById(model.SenderId);
            senderAccount.Balance -= model.Amount;
            _accountRepository.Update(senderAccount);

            var account = _accountRepository.GetById(model.AccountId);
            account.Balance += model.Amount;
            _accountRepository.Update(account);

            return RedirectToAction("Index", "Home");
        }
    }
}
