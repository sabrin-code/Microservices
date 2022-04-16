using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogWepApi.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string CourseTable { get; set ; }
        public string CategoryTable { get; set ; }
        public string ConnectionString { get ; set; }
        public string DatabaseName { get ; set; }
    }
}
