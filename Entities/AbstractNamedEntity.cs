using System;
using System.Collections.Generic;
using System.Text;

namespace CrusadingNobles.Entities
{
    public abstract class AbstractNamedEntity : Entity
    {
        protected abstract string GenerateName();
    }
}
