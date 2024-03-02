
using QuizList;
namespace QuizList.Model
{
    public interface QuizRepository
    {
        IEnumerable<Quiz> GetAll();
        Quiz Get(int id);
        Quiz Add(Quiz quiz);
        void Remove(int id);
        bool Update(Quiz quiz);
    }
}
