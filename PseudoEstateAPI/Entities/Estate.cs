using System;
using System.Collections.Generic;

namespace PseudoEstateAPI.Entities;

public partial class Estate
{
    public long Id { get; set; }

    public string EstateId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? BuildType { get; set; }

    public string? Address { get; set; }

    public double? SquareMeters { get; set; }

    public double? TotalPrice { get; set; }

    public string? Owner { get; set; }

    public string? AgentId { get; set; }

    public string? Status { get; set; }

    public string? OnlineDtm { get; set; }

    public string? CreateId { get; set; }

    public string? CreateName { get; set; }

    public string? CreateDtm { get; set; }

    public string? ModifyId { get; set; }

    public string? ModifyName { get; set; }

    public string? ModifyDtm { get; set; }

    public string? DeleteId { get; set; }

    public string? DeleteName { get; set; }

    public string? DeleteDtm { get; set; }
}
