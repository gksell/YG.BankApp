using YG.BankApp.WEB.Data.Entities;
using YG.BankApp.WEB.Models;

namespace YG.BankApp.WEB.Data.Mapping
{
    public interface IAccountMapper
    {
        Account MapAdd(AccountCreateModel account);
    }
}
