using APICursoACTI_Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICursoACTI_Domain.Entities
{
    /// <summary>
    /// Clase que representa una tarea en el sistema de CRUD de tareas.
    /// </summary>
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3,ErrorMessage ="El titulo debe de tener al menos 3 caracteres"), MaxLength(150)]
        [Required(ErrorMessage = "El titulo de la tarea es requerido")]
        [DisplayName("Titulo")]
        public string Title { get; set; } = null!;
        [DisplayName("Descripcion")]
        public string? Description { get; set; }
        [DisplayName("Estado")]
        public Status Status { get; set; } = Status.Pending;
        [DisplayName("Fecha de Creacion")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [DisplayName("Fecha de Vencimiento")]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Metodo para actualizar los detalles de la tarea.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="status"></param>
        /// <param name="dueDate"></param>
        public void Update(string title, string? description, Status status, DateTime? dueDate)
        {
            Title = title;
            Description = description;
            Status = status;
            DueDate = dueDate;
        }

        public TaskItem(string title, string? description, DateTime? dueDate, Status status = Status.Pending)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
