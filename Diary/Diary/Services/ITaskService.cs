using DiaryMVC.Models;

namespace DiaryMVC.Services
{
    public interface ITaskService
    {
        /// <summary>
        /// Creates task in database
        /// </summary>
        /// <param name="model">task to create</param>
        /// <returns>true if created</returns>
        bool Create(TaskModel model);

        /// <summary>
        /// Updates task in database
        /// </summary>
        /// <param name="model">updated task</param>
        /// <returns>true if updated</returns>
        bool Update(TaskModel model);
    }
}
