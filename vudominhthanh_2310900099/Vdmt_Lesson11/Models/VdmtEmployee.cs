using System;
using System.Collections.Generic;

namespace vudominnhthanh_2310900099.Models;

public partial class VdmtEmployee
{
    public string VdmtEmpId { get; set; } = null!;

    public string? VdmtEmpName { get; set; }

    public int? VdmtEmpLevel { get; set; }

    public DateOnly? VdmtEmpStartDate { get; set; }

    public byte? VdmtEmpstatus { get; set; }
}
