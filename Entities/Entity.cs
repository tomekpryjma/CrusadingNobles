using System;
using System.Collections.Generic;
using System.Text;
using CrusadingNobles.Buffs;

namespace CrusadingNobles
{
    public class Entity
    {
        protected float _health { get; set; }
        protected float _attack { get; set; }
        protected float _armour { get; set; }
        protected List<Buff> _buffs { get; }

        public void AddBuff(Buff buff)
        {
            _buffs.Add(buff);
        }
    }
}
