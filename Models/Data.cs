using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace csvtestapi.Models
{
    public class Data
    {
        [Index(0)]
        public int seq { get; set; }
        [Index(1)]
        public string? FirstName { get; set; }
        [Index(2)]
        public string? LastName { get; set; }
        [Index(3)]
        public int Age { get; set; }
        [Index(4)]
        public string? Street { get; set; }
        [Index(5)]
        public string? city { get; set; }
        [Index(6)]
        public string? state { get; set; }
        [Index(7)]
        public string? zip { get; set; }
        [Index(8)]
        public string? dollar { get; set; }
        [Index(9)]
        public string? pick { get; set; }
        [Index(10)]
        public string? date { get; set; }

    }
}