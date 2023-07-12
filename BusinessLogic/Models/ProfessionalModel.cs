using System;
using System.Collections.Generic;

namespace BusinessLogic.Models;

public partial class ProfessionalModel
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;
    
    public long? Grade { get; set; }
}
