﻿using ChainSyncSolution.Domain.BaseDomain;

namespace ChainSyncSolution.Domain.Entities;

public class Supplier : BaseEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string ProfileImage { get; set; } = null!;

    public List<Product> Products { get; set; } = new List<Product>();
}
