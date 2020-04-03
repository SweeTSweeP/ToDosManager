using System;
using System.Collections.Generic;

namespace ToDosManagerBackSide.Domain.Entities
{
    public class Day
    {
        public int Id { get; set; }
        public DateTime TasksDay { get; set; }
        public IEnumerable<Record> TaskRecords { get; set; }
    }
}