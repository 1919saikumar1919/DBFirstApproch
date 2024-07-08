using System;
using System.Collections.Generic;

namespace DBFirstApproch.Models;

public partial class Department
{
    public Guid DepartmentId { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
