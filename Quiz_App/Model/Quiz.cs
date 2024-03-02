using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizList
{
    public class Quiz
    {
        public int quiz_id { get; set; }
        public string? quiz_title { get; set; }
        public string? quiz_category { get; set; }

        public int no_of_questions { get; set; }

        public int max_marks { get; set; }

        

        public string? total_time { get; set; }
        

    }
}