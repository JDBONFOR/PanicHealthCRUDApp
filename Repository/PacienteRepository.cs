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

        // Obtener lista de pacientes
        public List<Paciente> GetPaciente()
        {
            return Paciente.ToList();
        }

        // Crear un paciente
        public Paciente CreatePaciente(Paciente paciente)
        {
            Paciente.Add(paciente);
            _context.SaveChanges();
            return paciente;
        }

        // Obtener un paciente especifico
        public Paciente GetPacienteById(int id)
        {
            return Paciente.Where(pa => pa.pac_iid == id).First();
        }

        // Eliminar un paciente
        public Paciente DeletePaciente(int id)
        {
            var paciente = GetPacienteById(id);
            Paciente.Remove(paciente);
            _context.SaveChanges();
            return paciente;
        }

        // Update de un paciente
        public Paciente UpdatePaciente(int id, JObject jsonEntity)
        {
            // GET ENTITY
            var entityUpd = GetPacienteById(id);

            // APPLY CHANGES
            foreach (var property in jsonEntity)
            {
                var p = property.Key;
                var v = property.Value;

                var entityProp = entityUpd.GetType().GetProperty(p);
                if (entityProp != null && entityProp.GetSetMethod() != null)
                    entityProp.SetValue(entityUpd, v.ToObject(entityProp.PropertyType), null);
            }

            //SAVE
            _context.SaveChanges();

            // RETURN
            return entityUpd;
        }

    }
}
