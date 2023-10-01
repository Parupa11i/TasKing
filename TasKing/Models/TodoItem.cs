using System;
using System.ComponentModel.DataAnnotations;

namespace TasKing.Models
{
    public class TodoItem
    {
        public TodoItem()
        {
        }

        [Key]
        public Guid Id { get; set; }

        public string Descr { get; set; }

        public string Status { get; set; }
    }
}
