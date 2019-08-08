using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class ProfesionalRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<Profesional> Profesional { get; set; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public ProfesionalRepository(panicHealthAppContext context)
        {
            Profesional = context.Set<Profesional>();
            _context = context;
        }

        public List<Profesional> GetProfesional()
        {
            return Profesional.ToList();
        }
    }
}
