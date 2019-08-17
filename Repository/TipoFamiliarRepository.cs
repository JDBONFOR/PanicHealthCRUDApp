using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class TipoFamiliarRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<TipoFamiliar> TipoFamiliar { get; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public TipoFamiliarRepository(panicHealthAppContext context)
        {
            TipoFamiliar = context.Set<TipoFamiliar>();
            _context = context;
        }

        public List<TipoFamiliar> GetTipoFamiliar()
        {
            return TipoFamiliar.ToList();
        }
        
    }
}
