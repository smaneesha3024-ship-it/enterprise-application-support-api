using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Support.API.Data;

namespace Support.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReportsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Reports/dashboard
    [HttpGet("dashboard")]
    public async Task<IActionResult> GetDashboard()
    {
        var totalIncidents =
            await _context.Incidents.CountAsync();

        var openIncidents =
            await _context.Incidents
                .CountAsync(i => i.Status == "Open");

        var highSeverityIncidents =
            await _context.Incidents
                .CountAsync(i =>
                    i.Status == "Open" &&
                    i.Severity == "High");

        var resolvedIncidents =
            await _context.Incidents
                .Where(i =>
                    i.Status == "Resolved" &&
                    i.ResolvedAt != null)
                .ToListAsync();

        var averageResolutionTime =
            resolvedIncidents.Count == 0
                ? 0
                : resolvedIncidents.Average(i =>
                    (i.ResolvedAt!.Value - i.CreatedAt)
                    .TotalMinutes);

        var dashboard = new
        {
            TotalIncidents = totalIncidents,
            OpenIncidents = openIncidents,
            HighSeverityOpenIncidents = highSeverityIncidents,
            ResolvedIncidents = resolvedIncidents.Count,
            AverageResolutionTimeMinutes =
                Math.Round(averageResolutionTime, 2)
        };

        return Ok(dashboard);
    }
}