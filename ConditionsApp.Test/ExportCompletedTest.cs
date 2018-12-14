using ConditionsApp.Conditions;
using ConditionsApp.Rules;
using Syndy.Messaging.ExportService.Export.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ConditionsApp.Test.Conditions
{
    public class ExportCompletedTest
    {
        private static Guid exportId = Guid.Parse("08d5af9a-ddb6-4b99-85dd-b0fc801a66d7");

        private ExportCompleted exportCompleted1 = new ExportCompletedClass
        {
            ExportDefinitionId = exportId,
            ProductsNum = 5,
            Status = "Active"
        };

        private ExportCompleted exportCompleted2 = new ExportCompletedClass
        {
            ExportDefinitionId = exportId,
            ProductsNum = 0,
            Status = "Active"
        };

        private ExportCompleted exportCompleted3 = new ExportCompletedClass
        {
            ExportDefinitionId = exportId,
            ProductsNum = 5,
            Status = "Inactive"
        };

        private ExportCompleted exportCompleted4 = new ExportCompletedClass
        {
            ExportDefinitionId = exportId,
            ProductsNum = 0,
            Status = "Active"
        };

        private ExportCompleted exportCompleted5 = new ExportCompletedClass
        {
            ExportDefinitionId = exportId,
            ProductsNum = 10,
            Status = "Active"
        };

        private ExportProductNumCondition exportProductNumCondition = new ExportProductNumCondition();

        private ExportStatusCondition exportStatusCondition = new ExportStatusCondition();

        private SuccessRule successRule = new SuccessRule();

        [Fact]
        public void NonValidCondition()
        {
            Assert.False(exportProductNumCondition.Valid(new ExportCompletedMessage(exportCompleted1)));
        }

        [Fact]
        public void ReceiveTest()
        {
            var manager = CreateManager();
            var messages = CreateMessages();
            var results = manager.ReceiveAll(messages).ToList();
            // 1 if both conditions of the rule are validated, else 0
            var toCompare = new List<int> { 0, 1, 0, 1, 0 };
            Assert.Equal(results, toCompare);
        }

        [Fact]
        public void ValidCondition()
        {
            Assert.True(exportProductNumCondition.Valid(new ExportCompletedMessage(exportCompleted2)));
        }

        public RuleManager CreateManager()
        {
            var rules = new List<IRule> { successRule };
            
            return (new RuleManager(rules));
        }

        public IEnumerable<IMessage> CreateMessages()
        {
            var messages = new List<IMessage>();
            messages.Add(new ExportCompletedMessage(exportCompleted1));
            messages.Add(new ExportCompletedMessage(exportCompleted2));
            messages.Add(new ExportCompletedMessage(exportCompleted3));
            messages.Add(new ExportCompletedMessage(exportCompleted4));
            messages.Add(new ExportCompletedMessage(exportCompleted5));
            return messages;
        }

    }
}
