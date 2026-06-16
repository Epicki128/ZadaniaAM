using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Models
{
    public class ClosedQuestionModel
    {
        public string question { get; set; }
        public string imageSrc { get; set; }
        public string answerA { get; set; }
        public string answerB { get; set; }
        public string answerC { get; set; }
        public char correctAnswer { get; set; }
    }
}
