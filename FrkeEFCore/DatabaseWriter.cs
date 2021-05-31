using System;
using System.Collections.Generic;
using System.Text;
using FrkeEFCore.Models;

namespace FrkeEFCore
{
    public class DatabaseWriter
    {
        private FrkeInterlockDb context;
        public DatabaseWriter()
        {
            context = new FrkeInterlockDb();
        }

        public void Add(DataEntry dataEntry)
        {
            context.tblDataEntries.Add(dataEntry);
            context.SaveChanges();
        }

        ~DatabaseWriter()
        {
            context.Dispose();
        }
    }
}
