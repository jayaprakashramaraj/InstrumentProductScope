
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstrumentProductScope
{
    [Serializable]
    public class Instument2ProductScope
    {
        public int InstrumentId { get; set; }
        public string InsutrementName { get; set; }
        public List<ProductScope> OriginalProductScopeList { get; set; }
        public List<ProductScope> ProductScopeList { get; set; }
    }

    [Serializable]
    public class ProductScope
    {
        public int ProductScopeId { get; set; }
        public string ProductScopeName { get; set; }

    }

}