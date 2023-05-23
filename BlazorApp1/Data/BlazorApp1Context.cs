using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;

namespace BlazorApp1.Data
{
    public class BlazorApp1Context : DbContext
    {
        public BlazorApp1Context (DbContextOptions<BlazorApp1Context> options)
            : base(options)
        {
        }

        public DbSet<BlazorApp1.Data.OCRbook> OCRbook { get; set; } = default!;
        public DbSet<BlazorApp1.Data.BookName> BookName { get; set; }
        public DbSet<BlazorApp1.Data.OCRBookLine> OCRBookLine { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<OCRbook>()
                .Property(e => e.Text)
                .HasConversion(
                v=>JsonConvert.SerializeObject(v),
                v=>JsonConvert.DeserializeObject <PageJson>(v));

        }
    }
}
