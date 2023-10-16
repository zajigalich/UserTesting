using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace UserTesting.API.Models;

public class PassTestRequest
{
    [NotNull]
    [MinLength(1)]
    public List<Answer> Answers { get; set; }

    public class Answer
	{
        public int QuestionOrdinal { get; set; }
        public int AnswerOrdinal { get; set; }
    }
}
