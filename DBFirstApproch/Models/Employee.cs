using System;
using System.Collections.Generic;

namespace DBFirstApproch.Models;

public partial class Employee
{
    public Guid EmployeeId { get; set; }

    public long Salary { get; set; }

    public string? Occupation { get; set; }

    public string? Position { get; set; }

    public DateTime DateOfJoining { get; set; }

    public int Status { get; set; }

    public string? Designation { get; set; }

    public Guid DepartmentId { get; set; }

    public Guid CandidateId { get; set; }

    public virtual Candidate Candidate { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;
}
