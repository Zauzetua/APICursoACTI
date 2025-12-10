using APICursoACTI_Domain.Entities;

namespace APICursoACTI_Application.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz que dicta las operaciones CRUD para la entidad TaskItem.
    /// </summary>
    public interface ITaskItemRepository
    {
        Task<TaskItem> AddAsync(TaskItem taskItem);
        Task<TaskItem?> GetByIdAsync(int id);
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem> UpdateAsync(TaskItem entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> AnyAsync(int id);
    }
}
