using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();

        void Add(Color car);

        void Delete(Color car);

        void Update(Color car);
    }
}
