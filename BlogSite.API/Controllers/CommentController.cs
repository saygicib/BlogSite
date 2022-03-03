using BlogSite.Business.Abstract;
using BlogSite.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("GetComments")]
        public ActionResult<List<Comment>> GetComments()
        {
            var comments = _commentService.GetAll();
            if (comments == null)
            {
                return NotFound();
            }
            return comments;
        }
        [HttpGet("GetCommentById")]
        public ActionResult<Comment> GetComment(int id)
        {
            var comment = _commentService.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }
        [HttpGet("GetCommentsByArticleId")]
        public ActionResult<List<Comment>> GetComments(int articleId)
        {
            var comments = _commentService.GetCommentsByArticleId(articleId);
            if (comments == null)
            {
                return NotFound();
            }
            return comments;
        }
        [HttpPost("UpdateComment")]
        public ActionResult<Comment> UpdateComment(Comment comment)
        {
            var updatedComment = _commentService.Add(comment);
            if (updatedComment == null)
            {
                return NotFound();
            }
            return updatedComment;
        }
        [HttpPost("AddComment")]
        public ActionResult<Comment> AddComment(Comment comment)
        {
            var addedComment = _commentService.Add(comment);
            if (addedComment == null)
            {
                return NotFound();
            }
            return addedComment;
        }
        [HttpPost("DeleteComment")]
        public ActionResult<Comment> DeleteComment(int id)
        {
            var deletedComment = _commentService.Delete(id);
            if (deletedComment == null)
            {
                return NotFound();
            }
            return deletedComment;
        }
    }
}
