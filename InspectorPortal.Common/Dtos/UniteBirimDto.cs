using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InspectorPortal.Common.Dtos
{
    public class AddUnit
    {

        public string UniteAdi { get; set; }
        public string UniteSorumlusu { get; set; }

    }

    public class AddBirim
    {
        public int BirimID { get; set; }
        public string BirimAdi { get; set; }
        public string BirimSorumlusu { get; set; }


    }
    public class Option
    {
        public int Id { get; set; }
        public string label { get; set; }
    }
}
