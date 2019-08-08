using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class PacienteRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<Paciente> Paciente { get; set; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public PacienteRepository(panicHealthAppContext context)
        {
            Paciente = context.Set<Paciente>();
            _context = context;
        }

        public List<Paciente> GetPaciente()
        {
            return Paciente.ToList();
        }

    }
}
