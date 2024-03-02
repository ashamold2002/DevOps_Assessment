using QuizList;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using WebapiList.Controllers;
//using WebApplication1.Controllers;
//using WebApplication1.Model;

namespace TestProject1
{
    public class Tests
    {


        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void Post_with_0_id_returns_OkResult()
        {
            QuizController addQuizController = new QuizController();

            Quiz quiz = new Quiz()
            {
                quiz_id = 1,
                quiz_title = "Guess Me",
                quiz_category="Science",
                no_of_questions = 10,
                max_marks = 10,
                total_time = "1hr"
        
            };

            var result = addQuizController.PostProduct(quiz);

            Assert.IsInstanceOf<OkResult>(result);
        }
        [Test]
        public void Update_with_correct_type_returns_correctResult()
        {

            QuizController updateQuizController = new QuizController();

            Quiz quiz = new Quiz()
            {
                quiz_id = 2,
                quiz_title = "Guess Who",
                quiz_category = "Gk",
                no_of_questions = 10,
                max_marks = 10,
                total_time = "1hr"
            };

            var result = updateQuizController.Update(quiz.quiz_id, quiz).Result;

            Assert.IsInstanceOf<OkResult>(result);

        }

        [Test]
        public void GetById_returns_correctResult()
        {
            QuizController quizController = new QuizController();
            var result = quizController.GetQuizes(1);

            var value = result.quiz_id;
            Assert.AreEqual(1, value);

        }
        [Test]
        public void Get_returnsAllResults_give_correct_type()
        {
            QuizController quizController = new QuizController();
            var result = quizController.GetAllQuizes();
            Assert.IsInstanceOf<List<Quiz>>(result);

        }



    }
}