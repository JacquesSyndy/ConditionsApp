using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionsApp.Conditions
{
    public abstract class Condition : ICondition
    {
        public bool Valid(IMessage message)
        {
            var messageType = Type.GetType(message.fullNameSpace + ", ConditionsApp.Contracts");
            return ValidObj(Convert.ChangeType(message.EventObj, messageType));
        }

        public abstract bool ValidObj(dynamic eventObj);
    }
}
