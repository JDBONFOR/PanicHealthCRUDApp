using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class UsuarioPacienteRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<UsuarioPaciente> UsuarioPaciente { get; set; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public UsuarioPacienteRepository(panicHealthAppContext context)
        {
            UsuarioPaciente = context.Set<UsuarioPaciente>();
            _context = context;
        }

        public List<UsuarioPaciente> GetUsuarioPaciente()
        {
            return UsuarioPaciente.ToList();
        }

    }
}
