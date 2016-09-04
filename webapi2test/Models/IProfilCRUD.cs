using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi2test.Models
{
    interface IProfilCRUD<T>
    {
        List<T> List();
        T Details(T data);
        bool Delete(T data);
        bool Add(T data);
        bool Update(T data);
    }
}
