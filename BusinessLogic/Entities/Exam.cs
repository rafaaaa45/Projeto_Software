using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessLogic.Entities;

public partial class Exam
{
    public int Id { get; set; }

    public long? CertificationId { get; set; }

    public string Name { get; set; } = null!;

    public long MinimumGrade { get; set; }
    
    public virtual Certification? Certification { get; set; }
    
    public virtual ICollection<ExamAttempt> ExamAttempts { get; set; } = new List<ExamAttempt>();
}
