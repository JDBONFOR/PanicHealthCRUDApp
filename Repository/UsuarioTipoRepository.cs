using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class UsuarioTipoRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<UsuarioTipo> UsuarioTipo { get; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public UsuarioTipoRepository(panicHealthAppContext context)
        {
            UsuarioTipo = context.Set<UsuarioTipo>();
            _context = context;
        }

        public List<UsuarioTipo> GetUsuarioTipo()
        {
            return UsuarioTipo.ToList();
        }
        
    }
}
