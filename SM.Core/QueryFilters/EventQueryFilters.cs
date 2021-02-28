using System;

namespace SM.Core.QueryFilters
{
    public class EventQueryFilters
    {
        public int? Id { get; set; }
        public int? IdSubjet { get; set; }
        public DateTime? Date { get; set; }
        public int? IdUser { get; set; }
        public int? TypeId { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public int? Priority { get; set; }
        public int? Active { get; set; }

    }
}
