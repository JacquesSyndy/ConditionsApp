using ConditionsApp.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionsApp.Actions
{
    public class PrintOkAction: IAction
    {
        public int Do(IMessage message)
        {
            Console.WriteLine(message.fullNameSpace + ": Ok");
            return 1;
        }
    }
}
