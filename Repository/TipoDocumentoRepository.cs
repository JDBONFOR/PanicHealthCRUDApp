using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class TipoDocumentoRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<TipoDocumento> TipoDocumento { get; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public TipoDocumentoRepository(panicHealthAppContext context)
        {
            TipoDocumento = context.Set<TipoDocumento>();
            _context = context;
        }

        public List<TipoDocumento> GetTipoDocumento()
        {
            return TipoDocumento.ToList();
        }
        
    }
}
