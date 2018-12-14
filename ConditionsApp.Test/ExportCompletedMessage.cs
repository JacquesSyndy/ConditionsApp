using ConditionsApp.Conditions;
using Syndy.Messaging.ExportService.Export.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionsApp.Test
{
    public class ExportCompletedMessage: IMessage
    {
        public ExportCompletedMessage(ExportCompleted exportCompleted)
        {
            fullNameSpace = "Syndy.Messaging.ExportService.Export.Events.ExportCompleted";
            EventObj = exportCompleted;
        }

        public string fullNameSpace { get; set; }

        public dynamic EventObj { get; set; }
    }
}
