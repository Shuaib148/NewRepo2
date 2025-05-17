using System;
using System.Collections.Generic;

namespace NIC_PRACTICAL.Models;

public partial class StudentDetail
{
    public int Id { get; set; }

    public int StudentRoll { get; set; }

    public string? StudentName { get; set; }

    public string? TotalMarks { get; set; }

    public int? DeptCode { get; set; }

    public DateOnly? Dob { get; set; }

    public string? DeptName { get; set; }
}
