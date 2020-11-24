using DiaryMVC.Models;

namespace DiaryMVC.Services
{
    public interface IMeetingService
    {
        /// <summary>
        /// Creates memo in database
        /// </summary>
        /// <param name="model">memo to create</param>
        /// <returns>true if created</returns>
        bool Create(MeetingModel model);

        /// <summary>
        /// Updates memo in database
        /// </summary>
        /// <param name="model">updated memo</param>
        /// <returns>true if updated</returns>
        bool Update(MeetingModel model);
    }
}
