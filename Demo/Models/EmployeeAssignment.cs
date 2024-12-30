using System;
using System.Collections.Generic;

namespace Demo.Models;

public partial class EmployeeAssignment
{
    public int AssignmentId { get; set; }

    public int CustomerId { get; set; }

    public int DepartmentId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;
}
