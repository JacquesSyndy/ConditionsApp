using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syndy.Messaging.ExportService.Export.Events
{
    public interface ExportCompleted: IConvertible
    {
        Guid ExportDefinitionId { get; set; }
        int ProductsNum { get; set; }
        string Status { get; set; }
        string FilePath { get; set; }
    }
}
