using System;
using System.Collections.Generic;

namespace Vdmt_Ls10.Models;

public partial class VdmtPost
{
    public int Vdmtid { get; set; }

    public string? VdmtTitle { get; set; }

    public string? VdmtImage { get; set; }

    public string? VdmtContent { get; set; }

    public bool? VdmtStatus { get; set; }
}
