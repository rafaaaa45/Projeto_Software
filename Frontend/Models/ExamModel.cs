using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Frontend.Models;

public partial class ExamModel
{
    public int Id { get; set; }

    public long? CertificationId { get; set; }

    public string Name { get; set; } = null!;

    public long MinimumGrade { get; set; }
}
