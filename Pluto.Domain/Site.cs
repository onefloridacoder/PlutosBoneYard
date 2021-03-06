﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace PlutoDomain
{
    public class Site
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<ThemePark> ThemeParks { get; set; }

        public string CreatedBy { get; set; }
        
        public DateTime CreatedDate { get; set; }
        
        public string UpdatedBy { get; set; }
        
        public DateTime UpdatedDate { get; set; }


    }
}
