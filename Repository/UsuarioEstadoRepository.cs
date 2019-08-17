using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class UsuarioEstadoRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<UsuarioEstado> UsuarioEstado { get; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public UsuarioEstadoRepository(panicHealthAppContext context)
        {
            UsuarioEstado = context.Set<UsuarioEstado>();
            _context = context;
        }

        public List<UsuarioEstado> GetUsuarioEstado()
        {
            return UsuarioEstado.ToList();
        }
        
    }
}
