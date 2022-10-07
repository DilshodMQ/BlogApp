using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcApp.Data;
using MvcApp.Models;
using MvcApp.ViewModels;

namespace MvcApp.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "User")]
    public class PostsController : Controller
    {
        private readonly MvcAppContext _context;

        public PostsController(MvcAppContext context)
        {
            _context = context;
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
            var curUserId=HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userPosts = _context.Posts.Include(p => p.Status).Where(p =>p.AuthorId == curUserId);
            return View(userPosts);
        }

        // GET: Posts/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.Include(p=>p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public async Task<IActionResult> Create()
        {
            
            var statuses=_context.Statuses.Take(2);

            ViewBag.Statuses = new SelectList(statuses, "Id", "Name");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int statusId, [Bind("Title,Content")] PostCreateViewModel post)
        {
            Post curPost = new Post();
            if (ModelState.IsValid)
            {
                
                var curUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                
              
                curPost.Title = post.Title;
                curPost.Content = post.Content;
                curPost.DateCreated=DateTime.Now;
                curPost.AuthorId = curUserId;
                curPost.StatusId = statusId;
                _context.Add(curPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }
     
        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            var statuses = _context.Statuses.Take(2);

            ViewBag.Statuses = new SelectList(statuses, "Id", "Name");
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int statusId, [Bind("Title,Content")] PostCreateViewModel post)
        {
           
            var curPost = await _context.Posts.FirstAsync(p=>p.Id==id);
            curPost.Title = post.Title;
            curPost.Content = post.Content;
            curPost.StatusId = statusId;
            _context.SaveChanges();
                return RedirectToAction(nameof(Index));
          
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Posts == null)
            {
                return NotFound();
            }

            var post = await _context.Posts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

       
       

     
    }
}
