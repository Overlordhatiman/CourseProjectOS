using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.DBEntities
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public int ArmyId { get; set; }
        public Army Army { get; set; }
    }
}