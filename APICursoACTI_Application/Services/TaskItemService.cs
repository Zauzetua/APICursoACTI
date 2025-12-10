using APICursoACTI_Application.DTOS;
using APICursoACTI_Application.Interfaces.Repositories;
using APICursoACTI_Application.Interfaces.Services;
using APICursoACTI_Application.Mappers;
using APICursoACTI_Domain.Entities;
using APICursoACTI_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICursoACTI_Application.Services
{
    /// <summary>
    /// Servicio para gestionar las operaciones relacionadas con las tareas.
    /// </summary>
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _taskItemRepository;
        private readonly TaskItemMapper _mapper;

        public TaskItemService(ITaskItemRepository taskItemRepository, TaskItemMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }
        /// <summary>
        /// Metodo para crear una nueva tarea.
        /// </summary>
        /// <param name="newTaskItem"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetTaskItemDTO>> CreateTaskItemAsync(CreateTaskItemDTO newTaskItem)
        {
            var taskItem = _mapper.ToEntity(newTaskItem);
            var result = await _taskItemRepository.AddAsync(taskItem);
            var serviceResponse = ServiceResponse<GetTaskItemDTO>.Ok(_mapper.ToDTO(result));
            return serviceResponse;
        }
        /// <summary>
        /// Metodo para eliminar una tarea por su Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<bool>> DeleteTaskItemAsync(int id)
        {
            var deleted = await _taskItemRepository.DeleteAsync(id);
            if (!deleted)
            {
                return ServiceResponse<bool>.Fail("No se logro eliminar la tarea");
            }
            return ServiceResponse<bool>.Ok(true);

        }
        /// <summary>
        /// Metodo para obtener todas las tareas.
        /// </summary>
        /// <returns></returns>
        public async Task<ServiceResponse<List<GetTaskItemDTO>>> GetAllTaskItemsAsync()
        {
            var taskItems = await _taskItemRepository.GetAllAsync();
            var taskItemDTOs = taskItems.Select(_mapper.ToDTO).ToList();
            return ServiceResponse<List<GetTaskItemDTO>>.Ok(taskItemDTOs);
        }
        /// <summary>
        /// Metodo para obtener una tarea por su Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetTaskItemDTO>> GetTaskItemByIdAsync(int id)
        {
            var taskItem = await _taskItemRepository.GetByIdAsync(id);
            if (taskItem == null)
            {
                return ServiceResponse<GetTaskItemDTO>.Fail("Tarea no encontrada");
            }
            return ServiceResponse<GetTaskItemDTO>.Ok(_mapper.ToDTO(taskItem));
        }
        /// <summary>
        /// Metodo para actualizar una tarea existente.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<ServiceResponse<GetTaskItemDTO>> UpdateTaskItemAsync(int id, UpdateTaskItemDTO dto)
        {
            var existingTaskItem = await _taskItemRepository.GetByIdAsync(id);
            if (existingTaskItem == null)
            {
                return ServiceResponse<GetTaskItemDTO>.Fail("Tarea no encontrada");
            }
            existingTaskItem.Update(dto.Title, dto.Description, dto.Status, dto.DueDate);

            var result = await _taskItemRepository.UpdateAsync(existingTaskItem);

            return ServiceResponse<GetTaskItemDTO>.Ok(_mapper.ToDTO(result));
        }
    }
}
