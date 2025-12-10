using APICursoACTI_Application.DTOS;
using APICursoACTI_Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
namespace APICursoACTI_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        public TaskItemsController(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }
        // GET: api/<TaskItemsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasksItems = await _taskItemService.GetAllTaskItemsAsync();
            return Ok(tasksItems.Data);
        }

        // GET api/<TaskItemsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var taskItem = await _taskItemService.GetTaskItemByIdAsync(id);
            if (!taskItem.Success)
                return NotFound(taskItem.Message);
            return Ok(taskItem.Data);
        }

        // POST api/<TaskItemsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTaskItemDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdTaskItem = await _taskItemService.CreateTaskItemAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = createdTaskItem.Data!.Id }, createdTaskItem.Data);
        }

        // PUT api/<TaskItemsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTaskItemDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updatedTaskItem = await _taskItemService.UpdateTaskItemAsync(id, dto);
            if (!updatedTaskItem.Success)
                return NotFound(updatedTaskItem.Message);
            return Ok(updatedTaskItem.Data);
        }

        // DELETE api/<TaskItemsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _taskItemService.DeleteTaskItemAsync(id);
            if (!result.Success)
                return NotFound(result.Message);
            return NoContent();
        }
    }
}
