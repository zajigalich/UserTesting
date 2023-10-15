namespace UserTesting.DAL.Entities
{
	public class Question
	{
		public int Number { get; set; }

		public string Text { get; set; }

		public List<Option> Options { get; set; }

		public Option Answer { get; set; }
	}
}
