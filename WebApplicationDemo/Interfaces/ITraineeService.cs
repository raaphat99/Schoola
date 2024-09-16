using WebApplicationDemo.Models;
using WebApplicationDemo.ViewModels;

namespace WebApplicationDemo.Interfaces
{
    public interface ITraineeService
    {
        public ICollection<Trainee> GetAll();
        public ICollection<TraineeGradesViewModel> CourseGrade(int id);
    }
}
