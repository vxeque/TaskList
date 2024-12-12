using Microsoft.EntityFrameworkCore;

namespace TaskListCRUD.DataAccess
{
    public class TaskListRepository
    {
        private readonly TaskListContext _context;

        public async Task<TaskListData?> GetTaskById(long id)
        {
            return await _context.TaskListData.FindAsync(id);
        }

        public TaskListRepository(TaskListContext context)
        {
            _context = context;
        }

        // añadir tarea a la db 
        public async Task AddTask(TaskListData task)
        {
            _context.TaskListData.Add(task);
            await _context.SaveChangesAsync();
        }

        // obtener todas las tareas de la db 
        public async Task<List<TaskListData>> GetAllTasks()
        {
            return await _context.TaskListData.ToListAsync();
        }


        // actualizar una tarea en la bd
        public async Task UpdateTask(long id, TaskListData updatedTask)
        {
            var task = await _context.TaskListData.FindAsync(id);
            if (task == null)
            {
                throw new ArgumentException("Tarea no encontrada");
            }

            // actualiza las propiedades con los nuevos valores
            task.nameTask = updatedTask.nameTask;
            task.description = updatedTask.description;
            task.UpdateDate = DateTime.Now;
            task.finishTask = updatedTask.finishTask;

            _context.TaskListData.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTask(long id)
        {
            var taks = await _context.TaskListData.FindAsync(id);

            if (taks == null)
            {
                throw new ArgumentException("Tarea no encontrada"); 
            }

            _context.TaskListData.Remove(taks);
            await _context.SaveChangesAsync(); 
        }
    }
}
