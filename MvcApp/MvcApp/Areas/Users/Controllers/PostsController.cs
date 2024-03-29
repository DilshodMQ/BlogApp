﻿
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcApp.Enums;
using MvcApp.Models;
using MvcApp.Services.Interfaces;
using MvcApp.ViewModels;

namespace MvcApp.Areas.Users.Controllers
{
    [Area("Users")]
    [Authorize(Roles = "User")]
    public class PostsController : Controller
    {
       
        private IUserPostService _userPostService;
        public PostsController(IUserPostService userPostService)
        {
            _userPostService = userPostService; 
        }

        // GET: Posts
        public async Task<IActionResult> Index()
        {
           var curUserId=HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
           var curUserPosts=_userPostService.GetByAuthorId(curUserId);

            return View(curUserPosts);
        }

        // GET: Posts/Details/5
        
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _userPostService.Details(id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Posts/Create
        public IActionResult Create()
        {
           return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string submitBtn, [Bind("Title,Content")] PostCreateViewModel post)
        {
            
            if (ModelState.IsValid)
            {

                var curUserId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                Post curPost = new Post();
                curPost.Title = post.Title;
                curPost.Content = post.Content;
                curPost.DateCreated = DateTime.Now;
                curPost.AuthorId = curUserId;
                
                switch (submitBtn)
                {
                    case "Create as draft":
                        curPost.StatusId = (int)Enums.StatusesEnum.Draft;
                        break;
                    case "Submit to check":
                        curPost.StatusId = (int)Enums.StatusesEnum.WaitingForApproval;
                        break;
                }
                var addedPost = _userPostService.AddPost(curPost);
               
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }


        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _userPostService.GetById(id.Value);
            if (post == null)
            {
                return NotFound();
            }
            if (post.StatusId == (int)Enums.StatusesEnum.WaitingForApproval)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string submitBtn, [Bind("Title,Content")] PostEditViewModel postEditVM)
        {
            var curPost = _userPostService.GetById(id);
            if (ModelState.IsValid)
            {
                try
                {
                    if (curPost == null)
                    {
                        return NotFound();
                    }

                    curPost.Title = postEditVM.Title;
                    curPost.Content = postEditVM.Content;

                    switch (submitBtn)
                    {
                        case "Save as draft":
                            curPost.StatusId = (int)StatusesEnum.Draft;
                            break;
                        case "Submit to check":
                            curPost.StatusId = (int)StatusesEnum.WaitingForApproval;
                            break;
                    }

                    _userPostService.EditPost(curPost);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_userPostService.PostExists(postEditVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(curPost);

        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _userPostService.GetById(id.Value);
            if(post.StatusId==(int)StatusesEnum.WaitingForApproval)
            {
                return NotFound();
            }
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = _userPostService.GetById(id);
            if (post!=null)
            {
                _userPostService.Delete(post);
            }
            
            return RedirectToAction(nameof(Index));
        }

    }
}
