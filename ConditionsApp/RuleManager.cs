using ConditionsApp.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionsApp
{
    public class RuleManager
    {

        IEnumerable<IRule> _rules { get; set; }

        public RuleManager(IEnumerable<IRule> rules)
        {
            _rules = rules;
        }

        public int Receive (IMessage message)
        {
            var applicableRules = _rules.Where(r => r.IsApplicable(message)).ToList();
            var validRules = applicableRules.Where(r => r.Valid(message)).ToList();
            var result = 0;
            validRules.ForEach(r => result += r.Action.Do(message));
            return result;
        }

        public IEnumerable<int> ReceiveAll(IEnumerable<IMessage> messages)
        {
            var result = new List<int>();
            foreach (var message in messages)
            {
                result.Add(Receive(message));
            }
            return result;
        }
    }
}
