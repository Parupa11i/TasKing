using System;
using System.ComponentModel.DataAnnotations;
using TasKing.TasKingData;
namespace TasKing.ViewModels
{
    public class VTodoItem
    {
        public VTodoItem()
        {
        }
        [Key]
        public Guid Id { get; set; }

        public string Descr { get; set; }

        public Status Status { get; set; }

    }
}
