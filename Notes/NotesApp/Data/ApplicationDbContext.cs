// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

namespace NotesApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<Note> Notes { get; set; }
    }
}
