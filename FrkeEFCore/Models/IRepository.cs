using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrkeEFCore.Models
{
    public interface IRepository
    {
        public IQueryable<DataEntry> tblDataEntries { get; }
    }
}
