using JobsAPI.Entities;
using JobsAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobsAPI.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    private readonly JobsDbContext _context;

    public JobsController(JobsDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var jobs = _context.Jobs.AsNoTracking().ToList();
        return Ok(jobs);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var job = _context.Jobs.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (job is null)
        {
            return NotFound();
        }

        return Ok(job);
    }

    [HttpPost]
    public IActionResult Post(Job job)
    {
        _context.Jobs.Add(job);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { job.Id }, job);
    }

    [HttpPut("{id:int}")]
    public IActionResult Post(int id, Job input)
    {
        var job = _context.Jobs.FirstOrDefault(x => x.Id == id);
        if (job is null)
        {
            return NotFound();
        }

        job.Update(
            input.Title,
            input.Description,
            input.Company,
            input.Location,
            input.Salary
        );

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var job = _context.Jobs.FirstOrDefault(x => x.Id == id);
        if (job is null)
        {
            return NotFound();
        }

        _context.Jobs.Remove(job);
        _context.SaveChanges();

        return NoContent();
    }
}