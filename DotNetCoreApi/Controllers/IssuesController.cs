using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreApi.Models;

namespace DotNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class IssuesController : Controller
    {
        private readonly DatabaseContext _context;
        public IssuesController(DatabaseContext context)
        {
            _context = context;
        }
        // GET api/issues
        [HttpGet]
        public IEnumerable<Issue> Get()
        {
            var issues = _context.Issues.ToList();
            return  issues;
        }

        // GET api/issues/5
        [HttpGet("{id}",Name = "GetIssue")]
        public IActionResult Get(int id)
        {
            var issue = _context.Issues.FirstOrDefault(i => i.Id == id);
            if (issue == null)
                return NotFound();


            return new ObjectResult(issue);
        }

        // POST api/issues
        [HttpPost]
        public IActionResult Post([FromBody]Issue issue)
        {
            issue.CreatedAt = DateTime.Now;
            issue.IsDeleted = false;
            if (issue.Title == null || issue.Description == null)
                return BadRequest();

            _context.Issues.Add(issue);
            _context.SaveChanges();

            return CreatedAtRoute("GetIssue",new { id = issue.Id },issue);
        }

        // PUT api/issues/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Issue issue)
        {
            var issueInDb = _context.Issues.FirstOrDefault(i => i.Id == id);
            if (issueInDb == null)
                return NotFound();

            issueInDb.Title = issue.Title;
            issueInDb.Description = issue.Description;
            issueInDb.UpdatedAt = DateTime.Now;

            _context.Issues.Update(issueInDb);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/issues/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var issue = _context.Issues.FirstOrDefault(i => i.Id == id);
            if (issue == null)
                return NotFound();

            issue.IsDeleted = true;
            //otherwise user the this code 
            _context.Issues.Remove(issue);
            //_context.Issues.Update(issue);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
