using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities;

namespace WebStore.Domain.ViewModels
{
    public class BreadCrumbViewModel
    {
        public Section Section { get; set; }

        public Brand Brand { get; set; }

        public string Product { get; set; }
    }
}
