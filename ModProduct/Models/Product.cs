﻿using Db.Interfaces;

namespace ModProduct.Models;

public class Product : IEntity
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
}