using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Professional
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ExamAttempt> ExamAttempts { get; set; } = new List<ExamAttempt>();
}
