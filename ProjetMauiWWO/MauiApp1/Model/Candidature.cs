﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Model
{
    internal class Candidature{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProffesionalLink { get; set; }
        public Stream FileDocument {  get; set; }
    }
}
