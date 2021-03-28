using System;
using System.Collections.Generic;
using System.Text;

namespace CrusadingNobles.Buffs
{
    public class Buff
    {
        protected string _name { get; }

        public Buff(string name)
        {
            _name = name;
        }
    }
}
