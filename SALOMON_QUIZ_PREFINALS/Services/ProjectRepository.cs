using ModernPortfolio.Models;

namespace ModernPortfolio.Services
{
    public class ProjectRepository
    {
        private static readonly List<Project> _projects = new()
        {
            new Project
            {
                Id = 1,
                Title = "Academic Database Management System",
                ShortDescription = "An ASP.NET Core MVC application designed to manage student academic records.",
                FullDescription = "Features student enrollment tracking, course registration, grade entry processing, and role-based access control.",
                Category = "Web Development",
                GitHubUrl = "https://github.com/yourusername/academic-db-system",
                ThumbnailUrl = "/images/thumbnails/project1.png",
                TechStack = new List<string> { "ASP.NET Core MVC", "C#", "SQL Server", "Bootstrap 5" },
                Comments = new List<ProjectComment>
                {
                    new ProjectComment { Id = 1, ProjectId = 1, Author = "Peer Reviewer", Text = "Clean structure and well-implemented MVC pattern!", PostedAt = DateTime.Now.AddDays(-2) }
                }
            },
            new Project
            {
                Id = 2,
                Title = "Network Packet Analyzer & Monitor",
                ShortDescription = "A CLI tool built for packet capture, traffic analysis, and network protocol evaluation.",
                FullDescription = "Analyzes TCP/UDP traffic, tracks active network interfaces, detects bandwidth usage spikes, and logs network events in real time.",
                Category = "Networking",
                GitHubUrl = "https://github.com/yourusername/network-packet-analyzer",
                ThumbnailUrl = "/images/thumbnails/project2.png",
                TechStack = new List<string> { "C#", ".NET Core", "SharpPcap", "Networking Protocols" },
                Comments = new List<ProjectComment>()
            },
            new Project
            {
                Id = 3,
                Title = "Interactive Portfolio Web App",
                ShortDescription = "Modern MVC personal portfolio featuring hardcoded authentication and interactive commenting.",
                FullDescription = "Built with ASP.NET Core MVC, Cookie Authentication, responsive UI design, dynamic Table of Contents, detailed project views, and live comment posting per project.",
                Category = "Web Development",
                GitHubUrl = "https://github.com/yourusername/mvc-portfolio",
                ThumbnailUrl = "/images/thumbnails/project3.png",
                TechStack = new List<string> { "ASP.NET Core MVC", "HTML5/CSS3", "JavaScript", "Bootstrap 5" },
                Comments = new List<ProjectComment>()
            }
        };

        public List<Project> GetAllProjects() => _projects;

        public Project? GetProjectById(int id) => _projects.FirstOrDefault(p => p.Id == id);

        public void AddComment(int projectId, ProjectComment comment)
        {
            var project = GetProjectById(projectId);
            if (project != null)
            {
                comment.Id = project.Comments.Count > 0 ? project.Comments.Max(c => c.Id) + 1 : 1;
                comment.ProjectId = projectId;
                comment.PostedAt = DateTime.Now;
                project.Comments.Add(comment);
            }
        }
    }
}