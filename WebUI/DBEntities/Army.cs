using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.DBEntities
{
    public class Army
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Type> Types { get; set; }
    }
}