using System.ComponentModel.DataAnnotations;
using System;

namespace AspNetCoreTodo.Models
{
    public class ToDoItem
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public bool IsDone { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTimeOffset? DueAt { get; set; }
    }
}