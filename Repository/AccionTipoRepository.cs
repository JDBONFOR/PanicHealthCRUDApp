using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class AccionTipoRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<AccionTipo> AccionTipo { get; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public AccionTipoRepository(panicHealthAppContext context)
        {
            AccionTipo = context.Set<AccionTipo>();
            _context = context;
        }

        public List<AccionTipo> GetAcciones()
        {
            return AccionTipo.ToList();
        }
        
    }
}
