using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionsApp.Conditions
{
    public interface ICondition
    {
        bool Valid(IMessage message);
    }
}
