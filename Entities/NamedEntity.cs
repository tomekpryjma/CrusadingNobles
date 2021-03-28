using System;
using System.Collections.Generic;
using System.Text;

namespace CrusadingNobles.Entities
{
    public class NamedEntity : AbstractNamedEntity
    {
        protected string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public NamedEntity()
        {
            GenerateName();
        }

        protected override string GenerateName()
        {
            _name = "Slron";
            return "Slron";
        }
    }
}
