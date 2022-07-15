using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Context;
using YG.BankApp.WEB.Data.Interfaces;

namespace YG.BankApp.WEB.Data.Repositories
{
    public class Repository<T>:IRepository<T> where T: class, new()
    {
        private readonly BankContext _bankcontext;

        public Repository(BankContext bankcontext)
        {
            _bankcontext = bankcontext;
        }

        public void Create(T entity)
        {
            _bankcontext.Set<T>().Add(entity);
            _bankcontext.SaveChanges();
        }
        public void Remove (T entiy)
        {
            _bankcontext.Set<T>().Remove(entiy);
            _bankcontext.SaveChanges();
        }
        public List<T> GetAll()
        {
            return _bankcontext.Set<T>().ToList();
        }
        public T GetById(object id)
        {
            return _bankcontext.Set<T>().Find(id);
        }
        public void Update(T entity)
        {
            _bankcontext.Set<T>().Update(entity);
            _bankcontext.SaveChanges();
        }
        public IQueryable<T> QueryableData()
        {
            return _bankcontext.Set<T>().AsQueryable();
        }
    }
}
