using System.ComponentModel.DataAnnotations;

namespace Support.API.Models;

public class Incident
{
    public int Id { get; set; }

    [Required]
    [StringLength(150)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^(Low|Medium|High|Critical)$")]
    public string Severity { get; set; } = "Medium";

    [Required]
    [RegularExpression("^(Open|In Progress|Resolved)$")]
    public string Status { get; set; } = "Open";

    public int? AffectedOrderId { get; set; }

    public string? AssignedTo { get; set; }

    public string? RootCause { get; set; }

    public string? ResolutionNotes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? ResolvedAt { get; set; }
}