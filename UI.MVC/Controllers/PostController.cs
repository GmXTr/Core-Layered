using AutoMapper;
using Core.Abstracts.IServices;
using Core.Concretes.Entities;
using Data.Migrations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.MVC.Models;
using Utilities.Extensions;

namespace UI.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;
        private readonly IMapper mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            this.postService = postService;
            this.mapper = mapper;
        }

        // GET: PostController
        public async Task<ActionResult> Index(int page = 1, int per_page = 10)
        {
            return View(await postService.GetPostsAsync(page, per_page));
        }

        // GET: PostController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await postService.GetPostAsync(id));
        }

        // GET: PostController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Categories = new SelectList(await postService.GetCategoriesAsync(), "Id", "Name");
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreatePostViewModel model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var post = new Post
                    {
                        Title = model.Title,
                        Subtitle = model.Subtitle,
                        Content = model.Content,
                        CategoryId = model.CategoryId,
                        Draft = model.Draft,
                        PublishDate = model.PublishDate
                    };

                    if (model.FeaturedImage != null && model.FeaturedImage.Length > 0)
                    {
                        var ext = Path.GetExtension(model.FeaturedImage.FileName);

                        var guidName = $"{model.Title.ToUrl()}-{DateTime.Now:yyyyMMddHHmmss}{ext}";

                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", guidName);

                        var db_path = Path.Combine("\\uploads", guidName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await model.FeaturedImage.CopyToAsync(stream);
                        }

                        post.FeaturedImage = db_path;
                    }
                    else
                    {
                        post.FeaturedImage = "https://placeholder.co/800x450";
                    }

                    await postService.CreatePostAsync(post, model.Tags?.Split(','));
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Categories = new SelectList(await postService.GetCategoriesAsync(), "Id", "Name", model.CategoryId);
                    return View(model);
                }
            }
            catch
            {
                ViewBag.Categories = new SelectList(await postService.GetCategoriesAsync(), "Id", "Name", model.CategoryId);
                return View(model);
            }
        }

        // GET: PostController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var post = await postService.GetPostAsync(id);
            var model = new EditPostViewModel
            {
                Id = id,
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.CategoryId,
                FeaturedImagePath = post.FeaturedImage,
                PublishDate = post.PublishDate,
                Subtitle = post.Subtitle,
                Tags = string.Join(",", post.Tags),
                FeaturedImage = null,
                Draft = post.Draft
            };
            ViewBag.Categories = new SelectList(await postService.GetCategoriesAsync(), "Id", "Name", post.CategoryId);
            return View(model);
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditPostViewModel model)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
