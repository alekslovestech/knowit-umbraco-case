using System.ComponentModel.DataAnnotations;

namespace KnowItUmbraco.Api.Models;

public class Product {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }

    [MaxLength(50)]
    public string Category { get; set; } = string.Empty;

    [MaxLength(30)]
    public string Color { get; set; } = string.Empty;

[MaxLength(20)]
    public string somethignElse { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public bool IsActive { get; set; } = true;
}
