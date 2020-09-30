using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Template.Domain.Service.Base
{
    public interface IBaseService<E> where E : class
    {
        E Add(E entity);
        void Update(E entity);
        void Delete(E entity);
        void Delete(int id);
        void Edit(E entity);
                
    }
}
