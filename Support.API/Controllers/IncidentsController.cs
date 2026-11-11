using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Support.API.Data;
using Support.API.Models;

namespace Support.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentsController : ControllerBase
{
    private readonly AppDbContext _context;

    private readonly ILogger<IncidentsController> _logger;

    public IncidentsController(
        AppDbContext context,
        ILogger<IncidentsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    // GET: api/Incidents
    [HttpGet]
    public async Task<IActionResult> GetIncidents()
    {
        var incidents = await _context.Incidents.ToListAsync();

        return Ok(incidents);
    }

    // GET: api/Incidents/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetIncident(int id)
    {
        var incident = await _context.Incidents.FindAsync(id);

        if (incident == null)
        {
            return NotFound(new { message = "Incident not found" });
        }

        return Ok(incident);
    }

    // POST: api/Incidents
    [HttpPost]
    public async Task<IActionResult> CreateIncident(Incident incident)
    {
        incident.Id = 0;
        incident.CreatedAt = DateTime.UtcNow;
        incident.Status = "Open";

        _context.Incidents.Add(incident);

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Incident {IncidentId} created with severity {Severity}",
            incident.Id,
            incident.Severity
        );

        return CreatedAtAction(
            nameof(GetIncident),
            new { id = incident.Id },
            incident
        );
    }

    // PUT: api/Incidents/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateIncident(
        int id,
        Incident updatedIncident)
    {
        var incident = await _context.Incidents.FindAsync(id);

        if (incident == null)
        {
            return NotFound(new { message = "Incident not found" });
        }

        incident.Status = updatedIncident.Status;
        incident.AssignedTo = updatedIncident.AssignedTo;
        incident.RootCause = updatedIncident.RootCause;
        incident.ResolutionNotes = updatedIncident.ResolutionNotes;

        if (updatedIncident.Status == "Resolved")
        {
            incident.ResolvedAt = DateTime.UtcNow;
        }

        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Incident {IncidentId} updated. Status: {Status}",
            incident.Id,
            incident.Status
        );

        return Ok(incident);
    }
}