using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessLogic.Models;

public partial class ExamAttemptModel
{
    public long Id { get; set; }

    public int? ExamId { get; set; }

    public long? ProfessionalId { get; set; }

    public string AttemptName { get; set; } = null!;

    public long? Grade { get; set; }
    
    public byte[]? AttemptDate { get; set; }
}
