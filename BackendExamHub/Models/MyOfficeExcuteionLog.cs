using System;
using System.Collections.Generic;

namespace BackendExamHub.Models;

public partial class MyOfficeExcuteionLog
{
    public long DeLogAutoId { get; set; }

    public string DeLogStoredPrograms { get; set; } = null!;

    public Guid DeLogGroupId { get; set; }

    public bool DeLogIsCustomDebug { get; set; }

    public string DeLogExecutionProgram { get; set; } = null!;

    public string? DeLogExecutionInfo { get; set; }

    public bool? DeLogVerifyNeeded { get; set; }

    public DateTime DeLogExDateTime { get; set; }
}
