using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DinoAPI.Models;

namespace DinoAPI.Data
{
    public class DinoAPIContext : DbContext
    {
        public DinoAPIContext (DbContextOptions<DinoAPIContext> options)
            : base(options)
        {
        }

        public DbSet<DinoAPI.Models.Dino> Dino { get; set; } = default!;
    }
}
