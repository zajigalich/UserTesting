using UserTesting.DAL.Entities;

namespace UserTesting.BLL.DTOs;

public class QuestionWithoutAnswerDto
{
	public int Number { get; set; }

	public string Text { get; set; }

	public List<OptionDto> Options { get; set; }
}
