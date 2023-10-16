namespace UserTesting.BLL.DTOs;

public class TestDto
{
	public Guid Id { get; set; }

	public string Name { get; set; }

	public string Description { get; set; }

	public List<QuestionDto> Questions { get; set; }
}
