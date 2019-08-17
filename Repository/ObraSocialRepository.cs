using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class ObraSocialRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<ObraSocial> ObraSocial { get; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public ObraSocialRepository(panicHealthAppContext context)
        {
            ObraSocial = context.Set<ObraSocial>();
            _context = context;
        }

        public List<TipoDocumento> GetTipoDocumento()
        {
            return TipoDocumento.ToList();
        }
        
    }
}
