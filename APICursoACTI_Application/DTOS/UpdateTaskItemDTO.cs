using APICursoACTI_Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICursoACTI_Application.DTOS
{
    public class UpdateTaskItemDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo es requerido")]
        [MinLength(3, ErrorMessage = "El titulo debe tener al menos 3 caracteres")]
        [DisplayName("Titulo de la tarea")]
        public string Title { get; set; } = null!;
        [DisplayName("Descripcion de la tarea")]
        public string? Description { get; set; }
        [DisplayName("Fecha de vencimiento")]
        public DateTime DueDate { get; set; }
        [DisplayName("Estado de la tarea")]
        [AllowedValues([Status.Pending, Status.InProgress, Status.Completed], ErrorMessage = "El estado debe ser Pending(0), InProgress(1) o Completed(2)")]
        public Status Status { get; set; } = Status.Pending;
    }
}
