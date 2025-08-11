using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStoreApi.Infrastructure.AI
{
    public class AISettings
    {
        public const string SectionName = "AISettings";
        public string ApiKey { get; set; }
        public string OpenRouterUrl { get; set; }
        public string Model { get; set; }
    }
}
