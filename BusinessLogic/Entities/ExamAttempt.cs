using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessLogic.Entities;

public partial class ExamAttempt
{
    public long Id { get; set; }

    public int? ExamId { get; set; }

    public long? ProfessionalId { get; set; }

    public string AttemptName { get; set; } = null!;

    public long? Grade { get; set; }
    
    public byte[]? AttemptDate { get; set; }
    
    public virtual Exam? Exam { get; set; }
    
    public virtual Professional? Professional { get; set; }
}
