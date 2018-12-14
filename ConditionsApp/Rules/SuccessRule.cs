using ConditionsApp.Actions;
using ConditionsApp.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionsApp.Rules
{
    public class SuccessRule: IRule
    {
        public IEnumerable<ICondition> Conditions { get; set; }

        public IAction Action { get; set; }

        public SuccessRule()
        {
            var cond = new List<ICondition>();
            cond.Add(new ExportProductNumCondition());
            cond.Add(new ExportStatusCondition());
            Conditions = cond;

            Action = new PrintOkAction();

        }

        public bool Valid(IMessage message)
        {
            foreach (var cond in Conditions)
            {
                if (!cond.Valid(message))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsApplicable(IMessage message)
        {
            return message.fullNameSpace == "Syndy.Messaging.ExportService.Export.Events.ExportCompleted";
        }
    }
}
