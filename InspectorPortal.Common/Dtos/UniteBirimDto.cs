using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InspectorPortal.Common.Dtos
{
    
    public class UniteBirimDto
    {
        public IQueryable<string> Birim { get; set; }
        public IQueryable<string> BirimSorumlusu { get; set; }
        public IQueryable<string> UstBirim { get; set; }
        public IQueryable<string> UstBirimSorumlusu { get; set; }

    }
}
