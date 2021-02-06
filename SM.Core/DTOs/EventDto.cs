using System;

namespace SM.Core.DTOs
{
    public class EventDto
    {
        public int Id { get; set; }
        public int IdSubjet { get; set; }
        public DateTime Date { get; set; }
        public int TypeOf { get; set; }
        public int IdTeacher { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public int Priority { get; set; }
        public int Active { get; set; }
    }
}
