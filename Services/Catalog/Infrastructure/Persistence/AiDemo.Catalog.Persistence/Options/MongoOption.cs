using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiDemo.Catalog.Persistence.Options
{
    public class MongoOption
    {
        public string DatabaseName { get; set; } = default!;
        public string ConnectionString { get; set; } = default!;
    }
}
