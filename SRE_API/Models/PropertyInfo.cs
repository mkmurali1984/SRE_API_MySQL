using System;
using System.Collections.Generic;

namespace SRE_API.Models;

public partial class PropertyInfo
{
    public int Pid { get; set; }

    public string? PersonName { get; set; }

    public string? OwnershipType { get; set; }

    public string? PersonAddress { get; set; }

    public string? ContactNumber { get; set; }

    public string? EmailAddress { get; set; }

    public string? Purpose { get; set; }

    public string? PropertyType { get; set; }

    public string? PropertySubtype { get; set; }

    public string? Price { get; set; }

    public string? PropertyDescription { get; set; }

    public string? Dimension { get; set; }

    public string? MapUrl { get; set; }

    public string? Location { get; set; }

    public string? ImageFileName { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsApproved { get; set; }
}
