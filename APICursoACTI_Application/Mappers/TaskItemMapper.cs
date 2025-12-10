using APICursoACTI_Application.DTOS;
using APICursoACTI_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICursoACTI_Application.Mappers
{
    public class TaskItemMapper
    {
        /// <summary>
        /// Metodo que convierte un CreateTaskItemDTO a una entidad TaskItem.
        /// Este podria ser movido a una clase de mapeo si se desea.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public TaskItem ToEntity(CreateTaskItemDTO dto)
        {
            return new TaskItem(dto.Title, dto.Description, dto.DueDate);
        }
        /// <summary>
        /// Metodo que convierte una entidad TaskItem a un GetTaskItemDTO.
        /// Este podria ser movido a una clase de mapeo si se desea.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public GetTaskItemDTO ToDTO(TaskItem entity)
        {
            return new GetTaskItemDTO
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Status = entity.Status,
                CreatedAt = entity.CreatedAt,
                DueDate = entity.DueDate
            };
        }
        /// <summary>
        /// Metodo para crear una nueva tarea.
        /// </summary>
        /// <param name="newTaskItem"></param>
        /// <returns></returns>

    }
}
