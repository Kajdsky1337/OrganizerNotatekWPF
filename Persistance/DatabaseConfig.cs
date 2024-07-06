using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektOrganizerNotatek.Persistance
{
    public static class DatabaseConfig
    {
        public static string ConnectionString { get; } = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = OrganizerNotatekDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False;";
    }

}
