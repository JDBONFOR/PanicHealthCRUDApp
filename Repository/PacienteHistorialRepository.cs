using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class PacienteHistorialRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<PacienteHistorial> PacienteHistorial { get; set; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public PacienteHistorialRepository(panicHealthAppContext context)
        {
            PacienteHistorial = context.Set<PacienteHistorial>();
            _context = context;
        }

        public List<PacienteHistorial> GetPacienteHistorial()
        {
            return PacienteHistorial.ToList();
        }

    }
}
