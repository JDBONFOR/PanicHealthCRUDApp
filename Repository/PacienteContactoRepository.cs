using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class PacienteContactoRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<PacienteContacto> PacienteContacto { get; set; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public PacienteContactoRepository(panicHealthAppContext context)
        {
            PacienteContacto = context.Set<PacienteContacto>();
            _context = context;
        }

        public List<PacienteContacto> GetPacienteContacto()
        {
            return PacienteContacto.ToList();
        }
    }
}
