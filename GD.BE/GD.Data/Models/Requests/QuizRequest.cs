using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Data.Models.Requests
{
    public class QuizRequest
    {
        public int questionId { get; set; }
        public string answerChoice { get; set; }
    }
}
