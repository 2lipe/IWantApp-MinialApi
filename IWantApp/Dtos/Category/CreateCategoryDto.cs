﻿using System.ComponentModel.DataAnnotations;

namespace IWantApp.Dtos.Category;

public class CreateCategoryDto
{
    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }
}