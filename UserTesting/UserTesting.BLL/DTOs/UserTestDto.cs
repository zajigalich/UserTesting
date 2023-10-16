namespace UserTesting.BLL.DTOs;

public class UserTestDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public bool Passed { get; set; }

    public decimal? Mark { get; set; }
}
