﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Owner : User
    {
        public List<Inmueble> Property {  get; set; } = new List<Inmueble>();
        public string? Photo { get; set; }
        public int? Rating {  get; set; }  
    }
}