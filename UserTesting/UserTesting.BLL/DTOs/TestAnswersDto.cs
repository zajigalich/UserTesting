namespace UserTesting.BLL.DTOs;

public class TestAnswersDto
{
    public Guid TestId { get; set; }

    public List<AnswerDto> Answers { get; set; }

	public class AnswerDto
    {
		public int QuestionOrdinal { get; set; }
		public int AnswerOrdinal { get; set; }
	}
}
