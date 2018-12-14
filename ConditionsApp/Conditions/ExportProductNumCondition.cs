using Syndy.Messaging.ExportService.Export.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionsApp.Conditions
{
    public class ExportProductNumCondition: Condition
    {
        public override bool ValidObj(dynamic eventObj)
        {
            return eventObj.ProductsNum == 0;
        }
    }
}
