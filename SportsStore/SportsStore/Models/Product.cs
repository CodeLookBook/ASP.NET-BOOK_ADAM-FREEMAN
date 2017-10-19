﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Product
    {
        #region PROPERTIES

        public int     Id           { get; set; }
        public string  Name         { get; set; }
        public string  Description  { get; set; }
        public decimal Price        { get; set; }
        public string  Category     { get; set; }
        
        #endregion
    }
}