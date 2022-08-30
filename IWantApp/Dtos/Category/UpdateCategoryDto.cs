using System.ComponentModel.DataAnnotations;

namespace IWantApp.Dtos.Category;

public class UpdateCategoryDto
{
    [StringLength(100, MinimumLength = 2)]
    public string Name { get; set; }
    public bool HasActive { get; set; }
}