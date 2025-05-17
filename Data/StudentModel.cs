namespace NIC_PRACTICAL.Data
{
	public class StudentModel
	{
		public int Id { get; set; }

		public int StudentRoll { get; set; }

		public string? StudentName { get; set; }

		public string? TotalMarks { get; set; }

		public int? DeptCode { get; set; }

		public string? DeptName { get; set; }
		public DateOnly? Dob { get; set; }

	}
}
