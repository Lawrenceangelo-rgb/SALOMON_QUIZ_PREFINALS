using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernPortfolio.Models;
using ModernPortfolio.Services;

namespace ModernPortfolio.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ProjectRepository _repository;

        public PortfolioController(ProjectRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var projects = _repository.GetAllProjects();
            return View(projects);
        }

        public IActionResult Details(int id)
        {
            var project = _repository.GetProjectById(id);
            if (project == null)
                return NotFound();

            return View(project);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(int projectId, string author, string text)
        {
            if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(text))
            {
                TempData["Error"] = "Author and comment text are required.";
                return RedirectToAction("Details", new { id = projectId });
            }

            var comment = new ProjectComment
            {
                Author = author.Trim(),
                Text = text.Trim()
            };

            _repository.AddComment(projectId, comment);
            TempData["Success"] = "Comment added successfully!";
            return RedirectToAction("Details", new { id = projectId });
        }
    }
}