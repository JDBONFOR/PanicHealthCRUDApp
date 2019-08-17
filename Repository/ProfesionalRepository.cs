using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class ProfesionalRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<Profesional> Profesional { get; set; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public ProfesionalRepository(panicHealthAppContext context)
        {
            Profesional = context.Set<Profesional>();
            _context = context;
        }

        // Obtener lista de profesionales
        public List<Profesional> GetProfesional()
        {
            return Profesional.ToList();
        }

        // Crear un profesional
        public Profesional CreateProfesional(Profesional profesional)
        {
            Profesional.Add(profesional);
            _context.SaveChanges();
            return profesional;
        }

        // Obtener un profesional especifico
        public Profesional GetProfesionalById(int id)
        {
            return Profesional.Where(p => p.prof_iid == id).First();
        }

        // Eliminar un profesional
        public Profesional DeleteProfesional(int id)
        {
            var profesional = GetProfesionalById(id);
            Profesional.Remove(profesional);
            _context.SaveChanges();
            return profesional;
        }

        // Actualizar un profesional
        public Profesional UpdateProfesional(int id, JObject jsonEntity)
        {
            // GET ENTITY
            var entityUpd = GetProfesionalById(id);

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
