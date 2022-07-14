using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD.Data.Dto.QuestionChoice
{
    public class QuestionsDto
    {
        public int QuestionId { get; set; }
        public string content { get; set; }
        public string ImgUrl { get; set; }
        public string SubjectName { get; set; }
        public bool? IsMultiple { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public List<QuestionChoiceDto> QuestionChoiceDtos { get; set; }
        public string Selected { get; set; }

    }

    public class QuestionChoiceDto
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; } 
        public bool? IsAnswer { get; set; }
        public string content { get; set; }
    }
}
