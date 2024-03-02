using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using QuizList.Model;
using QuizList;
namespace QuizList.Model
{
    public class IQuizRepository : QuizRepository
    {
        private List<Quiz> quizes = new List<Quiz>();
        private int _nextId = 1;
        public IQuizRepository()
        {
            Add(new Quiz { quiz_id = 1,quiz_title = "Guess Me",quiz_category = "science",no_of_questions = 10,max_marks = 10,total_time = "1hr" });

        }
        public IEnumerable<Quiz> GetAll()
        {
            return quizes;
        }

        public Quiz Get(int id)
        {
            return quizes.Find(p => p.quiz_id == id);
        }

        public Quiz Add(Quiz quiz)
        {
            if (quiz == null)
            {
                throw new ArgumentNullException("item");
            }
            quiz.quiz_id = _nextId++;
            quizes.Add(quiz);
            return quiz;
        }

        public void Remove(int id)
        {
            quizes.RemoveAll(p => p.quiz_id == id);
        }
        public bool Update(Quiz quiz)
        {
            if (quiz == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = quizes.FindIndex(p => p.quiz_id == quiz.quiz_id);
            if (index == -1)
            {
                return false;
            }
            quizes.RemoveAt(index);
            quizes.Add(quiz);
            return true;
        }
    }
}