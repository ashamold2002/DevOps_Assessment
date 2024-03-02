using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizList;
using QuizList.Model;
using System.Net;
using System.Net.Http;

namespace WebapiList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        static readonly QuizRepository repository = new IQuizRepository();

        [HttpGet]
        public IEnumerable<Quiz> GetAllQuizes()
        {
            return repository.GetAll();
        }
        [HttpGet("id")]
        public Quiz GetQuizes(int id)
        {
            Quiz quiz = repository.Get(id);
            if (quiz == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return null;

            }
            return quiz;
        }

        [HttpGet("Title")]
        public IEnumerable<Quiz> GetByQuiz(string quiz_title)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.quiz_title,quiz_title, StringComparison.OrdinalIgnoreCase));
        }
        [HttpPost]
        public ActionResult PostProduct(Quiz item)
        {
            repository.Add(item);

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Quiz quiz)
        {
            if (id != quiz.quiz_id)
                return BadRequest();
            else
                repository.Update(quiz);
            return Ok();
        }


    }
}