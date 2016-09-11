﻿using AndroidShowcase.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndroidShowcase.Business.Abstract
{
    public interface IAndroidShowcaseRepository
    {
        IEnumerable<Note> Notes();
        IEnumerable<Product> Products();
    }
}