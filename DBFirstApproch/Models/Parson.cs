using System;
using System.Collections.Generic;

namespace DBFirstApproch.Models;

public partial class Parson
{
    public Guid ParsonId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Genger { get; set; }

    public string? Materialstatus { get; set; }

    public DateTime DateOfBirth { get; set; }

    public int Age { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
}
