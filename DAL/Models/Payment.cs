﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public decimal PaidAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentStatus { get; set; }

    public virtual Order Order { get; set; } = null!;
}
