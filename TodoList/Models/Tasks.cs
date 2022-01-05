using System;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Tasks
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="You must enter a title")]
        public string Title { get; set; }
        public string Description { get; set; } = "Description not found";
        public DateTime Start { get; set; } = DateTime.Now;
        public DateTime End { get; set; }
        public bool IsCompleted { get; set; }
    }
}
