using System;
using System.Collections.Generic;

namespace PseudoEstateAPI.Entities;

public partial class Agent
{
    public long Id { get; set; }

    public string AgentId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Title { get; set; }

    public string? PhoneNo { get; set; }

    public string? Licenses { get; set; }

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
