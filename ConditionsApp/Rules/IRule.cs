using ConditionsApp.Actions;
using ConditionsApp.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionsApp
{
    public interface IRule
    {
        IEnumerable<ICondition> Conditions { get; set; }

        IAction Action { get; set; }

        bool IsApplicable(IMessage message);

        bool Valid(IMessage message);
    }
}
