using System;
using System.Collections.Generic;
using System.Text;

namespace SaeApp.Model.Modules.System.Finance
{
    public class Tax
    {
        public const int EXEMPT = 1;
        public const int IVA_1 = 2;
        public const int IVA_2 = 3;
        public const int IVA_4 = 4;
        public const int IVA_10 = 5;
        public const int IVA_12 = 6;
        public const int IVA_13 = 7;

        public int IdTax { get; set; }
        public decimal TaxPercentage { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
