using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy_19_1_23_.Repo
{
    public interface IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        bool Update(T entity);

        bool Delete(int id);

        void Save();

    }
}
