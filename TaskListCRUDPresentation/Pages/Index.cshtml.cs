using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskListCRUD.Business.Services;
using TaskListCRUD.DataAccess;

namespace TaskListCRUDPresentation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TaskListService _taskListService;

        public IndexModel(TaskListService taskListService)
        {
            _taskListService = taskListService;
        }

        [BindProperty]
        public TaskListData NewTask { get; set; }

        public List<TaskListData> Tasks { get; set; }

        public async Task OnGetAsync()
        {
            // Obtener todas las tareas cuando se carga la p�gina
            Tasks = await _taskListService.GetTasks();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                // Agregar una nueva tarea
                NewTask.CreateDate = DateTime.Now;
                NewTask.UpdateDate = DateTime.Now;
                NewTask.finishTask = false;

                await _taskListService.AddTask(NewTask);

                // Despu�s de agregar, redirigir de nuevo a la misma p�gina para actualizar la lista
                return RedirectToPage();
            }

            // Si algo va mal, volver a mostrar el formulario
            return Page();
        }

        // Acci�n para eliminar una tarea
        public async Task<IActionResult> OnPostDeleteAsync(long taskId)
        {
            if (taskId <= 0)
            {
                return NotFound();
            }

            // Eliminar la tarea con el id proporcionado
            await _taskListService.DeleteTask(taskId);

            // Despu�s de eliminar, redirigir de nuevo a la misma p�gina para actualizar la lista
            return RedirectToPage();
        }


        // Acci�n para actualizar una tarea
        public async Task<IActionResult> OnPostUpdateAsync(long taskId, string nameTask, string description)
        {
            if (taskId <= 0 || string.IsNullOrEmpty(nameTask) || string.IsNullOrEmpty(description))
            {
                return NotFound();
            }

            // Obtener la tarea actual para actualizarla
            var taskToUpdate = await _taskListService.GetTaskById(taskId);

            if (taskToUpdate == null)
            {
                return NotFound();
            }

            // Actualizar los campos de la tarea
            taskToUpdate.nameTask = nameTask;
            taskToUpdate.description = description;
            taskToUpdate.UpdateDate = DateTime.Now;

            // Llamar al servicio para guardar los cambios
            await _taskListService.UpdateTask(taskId, taskToUpdate);

            // Despu�s de actualizar, redirigir a la p�gina actual para actualizar la lista
            return RedirectToPage();
        }


    }
}
