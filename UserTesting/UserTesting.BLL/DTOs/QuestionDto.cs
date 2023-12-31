﻿namespace UserTesting.BLL.DTOs;

public class QuestionDto
{
	public int Ordinal { get; set; }

	public string Text { get; set; }

	public List<OptionDto> Options { get; set; }

    public OptionDto Answer { get; set; }
}
