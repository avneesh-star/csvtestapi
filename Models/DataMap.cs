using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace csvtestapi.Models
{
    public class DataMap : ClassMap<Data>
    {
        public DataMap()
        {
            Map(p => p.seq).Index(0);
            Map(p => p.FirstName).Index(1);
            Map(p => p.LastName).Index(2);
            Map(p => p.Age).Index(3);
            Map(p => p.Street).Index(4);
            Map(p => p.city).Index(5);
            Map(p => p.state).Index(6);
            Map(p => p.zip).Index(7);
            Map(p => p.dollar).Index(8);
            Map(p => p.pick).Index(9);
            Map(p => p.date).Index(10);
        }
    }
}