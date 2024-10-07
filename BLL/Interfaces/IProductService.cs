using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    internal interface IProductService
    {
        public void Add();
        public void Update();
        public void Delete();
        public void Get();
        public void GetAll();
    }
}
