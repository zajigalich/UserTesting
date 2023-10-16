namespace UserTesting.BLL.DTOs;

public class TestWithoutAnswerDto
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public List<QuestionWithoutAnswerDto> Questions { get; set; }
}
