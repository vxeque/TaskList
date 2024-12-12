
using TaskListCRUD.DataAccess;

namespace TaskListCRUD.Business.Services
{
    public class TaskListService
    {
        private readonly TaskListRepository _taskListRepository;

        public async Task<TaskListData?> GetTaskById(long id)
        {
            return await _taskListRepository.GetTaskById(id);
        }

        public TaskListService(TaskListRepository taskListRepository)
        {
            _taskListRepository = taskListRepository;
        }

        // añadir una tarea
        public async Task AddTask(TaskListData taskData)
        {

            // Lógica de negocio antes de pasar al repositorio
            if (taskData == null) return;

            await _taskListRepository.AddTask(taskData);
        }

        // obtener todas las tareas
        public async Task<List<TaskListData>> GetTasks()
        {

            // añadir aqui la logica de negocios antes de pasar el repositorio

            return await _taskListRepository.GetAllTasks();
        }

        // actualizar tarea
        public async Task UpdateTask(long id, TaskListData updateTask)
        {
            // logica de negocio para pasar al repositorio
            if (updateTask == null) return;

            // aqui podemos validar si la tarea que se requiere actualizar tiene todos los datos necesarios
            await _taskListRepository.UpdateTask(id, updateTask);
        }

        // Eliminar Tarea
        public async Task DeleteTask(long id)
        {
            // logica de negocio antes de pasar al repositorio
            if (id <= 0) return;

            // aqui se ponen validaciones adicionales


            await _taskListRepository.DeleteTask(id);
        }
    }
}