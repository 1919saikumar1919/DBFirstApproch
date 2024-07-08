using System;
using System.Collections.Generic;

namespace DBFirstApproch.Models;

public partial class Candidate
{
    public Guid CandidateId { get; set; }

    public string? CadidateCurrentAddress { get; set; }

    public string? CadidatePermanentAddress { get; set; }

    public string? Experiance { get; set; }

    public string? Domain { get; set; }

    public Guid ParsonId { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Parson Parson { get; set; } = null!;
}
