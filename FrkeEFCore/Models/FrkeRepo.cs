using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrkeEFCore.Models
{
    public class FrkeRepo : IRepository
    {
        private FrkeInterlockDb context;
        public FrkeRepo(FrkeInterlockDb ctx = null)
        {
            if (ctx != null)
                context = ctx;
            else
                context = new FrkeInterlockDb();
        }
        public IQueryable<DataEntry> tblDataEntries => 
            context.tblDataEntries;
    }
}
