using APICursoACTI_Application.Interfaces.Repositories;
using APICursoACTI_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICursoACTI_Infrastructure.Repositories
{
    public class InMemoryTaskItemRepository : ITaskItemRepository
    {
        private readonly List<TaskItem> _taskItems;
        public InMemoryTaskItemRepository()
        {
            _taskItems = [];
        }

        /// <summary>
        /// Metodo para leer el siguiente Id disponible.
        /// Este metodo no necesita ser asincrono, pero se implementa asi para cumplir con la firma del repositorio.
        /// </summary>
        /// <returns></returns>
        private int ReadNextId()
        {
            if (_taskItems.Count == 0)
                return 1;
            return _taskItems.Max(t => t.Id) + 1;
        }
        public async Task<TaskItem> AddAsync(TaskItem taskItem)
        {
            taskItem.Id = ReadNextId();
            _taskItems.Add(taskItem);
            return await Task.FromResult(taskItem);
        }

        public async Task<bool> AnyAsync(int id)
        {
            var exists = _taskItems.Any(t => t.Id == id);
            return await Task.FromResult(exists);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var taskItem = _taskItems.FirstOrDefault(t => t.Id == id);
            if (taskItem == null)
                return await Task.FromResult(false);
            _taskItems.Remove(taskItem);
            return await Task.FromResult(true);
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await Task.FromResult(_taskItems);
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            var taskItem = _taskItems.FirstOrDefault(t => t.Id == id);
            return await Task.FromResult(taskItem);
        }

        public async Task<TaskItem> UpdateAsync(TaskItem entity)
        {
            //Le pongo el operador ! porque en el servicio ya se valida si existe el objeto
            var taskItem = _taskItems.FirstOrDefault(t => t.Id == entity.Id)!;
            taskItem.Update(entity.Title, entity.Description, entity.Status, entity.DueDate);
            return await Task.FromResult(taskItem);
        }
    }
}
