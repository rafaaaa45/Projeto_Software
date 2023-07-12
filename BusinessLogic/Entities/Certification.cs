using System;
using System.Collections.Generic;

namespace BusinessLogic.Entities;

public partial class Certification
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Exam> Exams { get; set; } = new List<Exam>();
}
