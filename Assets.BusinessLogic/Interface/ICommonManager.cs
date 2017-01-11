﻿using Assets.DO;
using System.Collections.Generic;

namespace Assets.BusinessLogic.Interface
{
    public interface ICommonManager
    {
        List<Country> GetAllCountries();
    }
}