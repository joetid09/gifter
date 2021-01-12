using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gifter.Models;
using Gifter.Repositories;

namespace Gifter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_commentRepo.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var comment = _commentRepo.GetById(id);
            if(id != comment.Id)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpGet("getbyuser/{id}")]
        public IActionResult GetByUser(int id)
        {
            return Ok(_commentRepo.GetByUserId(id));
        }            

        [HttpPut("{id}")]
        public IActionResult Update(int id, Comment comment)
        {
            if(id != comment.Id)
            {
                return BadRequest();
            }
            _commentRepo.UpdateComment(comment);
            return NoContent();
        }
    }
}
