using DiaryMVC.Models;

namespace DiaryMVC.Services
{
    public interface IMemoService
    {
        /// <summary>
        /// Creates memo in database
        /// </summary>
        /// <param name="model">memo to create</param>
        /// <returns>true if created</returns>
        bool Create(MemoModel model);

        /// <summary>
        /// Updates memo in database
        /// </summary>
        /// <param name="model">updated memo</param>
        /// <returns>true if updated</returns>
        bool Update(MemoModel model);
    }
}
