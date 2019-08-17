using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using PanicHealth.Models;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace PanicHealth.Repository
{
    public class UsuarioRepository
    {
        // Hago el DbSet<NombreDeTabla>
        public DbSet<Usuario> Usuario { get; set; }
        // Defino el contexto a utilizar
        private panicHealthAppContext _context = null;

        // Constructor
        public UsuarioRepository(panicHealthAppContext context)
        {
            Usuario = context.Set<Usuario>();
            _context = context;
        }

        public List<Usuario> GetUsers()
        {
            return Usuario.ToList();
        }

        public Usuario CreateUser(Usuario usuario)
        {
            Usuario.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public Usuario GetUsersById(int id)
        {
            return Usuario.Where(u => u.usu_iid == id).First();
        }

        public Usuario DeleteUser(int id)
        {
            var usuario = GetUsersById(id);
            Usuario.Remove(usuario);            
            _context.SaveChanges();
            return usuario;
        }

        public Usuario UpdateUser(int id, JObject jsonEntity)
        {
            // GET ENTITY
            var entityUpd = GetUsersById(id);

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
