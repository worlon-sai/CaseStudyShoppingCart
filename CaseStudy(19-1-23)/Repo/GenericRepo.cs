using CaseStudy_19_1_23_.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaseStudy_19_1_23_.Repo
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        public Cases_Context _Context = null;
        public DbSet<T> _Table= null;

        public GenericRepo(Cases_Context context)
        {
            _Context = context;
            _Table=_Context.Set<T>();
        }

        public bool Delete(int id)
        {
            T existing =_Table.Find(id);
            _Table.Remove(existing);
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            var re=_Table.ToList();
            return re;
        }

        public T GetById(int id)
        {
            T re=_Table.Find(id);
            
          return re;
        }

        public void Save()
        {
            _Context.SaveChanges();
            
        }

        public bool Update(T entity)
        {
            var re= _Table.Find(entity);
            if (re == null)
            {
                _Table.Attach(entity);
                return true;
            }
            _Context.Entry(entity).State = EntityState.Modified;
            return true;
        }
    }
}