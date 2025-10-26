using System.ComponentModel.DataAnnotations;

namespace ForgeFolio.DAL.Entities
{
    public class ToDoList
    {
        [Key]
        public int ToDoListID { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }
    }
}
