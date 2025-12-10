using APICursoACTI_Application.DTOS;

namespace APICursoACTI_Application.Interfaces.Services
{
    public interface ITaskItemService
    {
        Task<ServiceResponse<GetTaskItemDTO>> CreateTaskItemAsync(CreateTaskItemDTO newTaskItem);
        Task<ServiceResponse<List<GetTaskItemDTO>>> GetAllTaskItemsAsync();
        Task<ServiceResponse<GetTaskItemDTO>> GetTaskItemByIdAsync(int id);
        Task<ServiceResponse<GetTaskItemDTO>> UpdateTaskItemAsync(int id, UpdateTaskItemDTO updatedTaskItem);
        Task<ServiceResponse<bool>> DeleteTaskItemAsync(int id);

    }
}
