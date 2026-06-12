using System;
namespace samplecrud.Models
{
    public class RoutineTask
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public string? Status { get; set; }
        public string? Category { get; set; }
        public string? Priority { get; set; }
        public DateTime DueDateTime { get; set; }
    }
}

