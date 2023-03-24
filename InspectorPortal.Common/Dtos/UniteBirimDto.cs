using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectorPortal.Common.Dtos
{
    public class UniteBirimDto
    {
        public List<string> Birim { get; set; }
        public List<string> BirimSorumlusu { get; set; }
        public List<string> UstBirim { get; set; }
        public List<string> UstBirimSorumlusu { get; set; }

    }
}
