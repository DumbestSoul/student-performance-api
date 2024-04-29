using System;
using System.Collections.Generic;

namespace StudentPerformance.Entity.Models;

public partial class Marksheet
{
    public Guid MarksheetId { get; set; }

    public Guid? StudentId { get; set; }

    public string Sub { get; set; } = null!;

    public decimal? TotalMark { get; set; }

    public decimal MarksObtained { get; set; }

    public virtual StudentMaster? Student { get; set; }
}
