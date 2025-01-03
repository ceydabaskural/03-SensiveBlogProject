﻿using SensiveBlog.EntityLayer;
using SensiveBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensiveBlog.DataAccessLayer.Abstract
{
    public interface ICategoryDal : IGenericDal<Category> //ICategoryDal interfacesini generic yapımız olan IGenericDal ile Category sınıfımız için miras alıyoruz
    {
    }
    
}
