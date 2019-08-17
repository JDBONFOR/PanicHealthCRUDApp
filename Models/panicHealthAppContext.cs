using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PanicHealth.Models
{
    public class panicHealthAppContext : DbContext
    {
        public panicHealthAppContext()
        {
        }

        public panicHealthAppContext(DbContextOptions<panicHealthAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccionTipo> AccionTipo { get; set; }
        public virtual DbSet<ObraSocial> ObraSocial { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<PacienteContacto> PacienteContacto { get; set; }
        public virtual DbSet<PacienteHistorial> PacienteHistorial { get; set; }
        public virtual DbSet<Profesional> Profesional { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumento { get; set; }
        public virtual DbSet<TipoFamiliar> TipoFamiliar { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioEstado> UsuarioEstado { get; set; }
        public virtual DbSet<UsuarioPaciente> UsuarioPaciente { get; set; }
        public virtual DbSet<UsuarioTipo> UsuarioTipo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=127.0.0.1; Port=3306; Database=panicHealthApp; Uid=root; Pwd=password;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tienen crud
            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasKey(e => e.pac_doc_iid);

                entity.ToTable("paciente");

                entity.Property(e => e.pac_doc_iid)
                    .HasColumnName("pac_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.pac_apellido)
                    .IsRequired()
                    .HasColumnName("pac_apellido")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.pac_dni)
                    .IsRequired()
                    .HasColumnName("pac_dni")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.pac_doc_iid)
                    .HasColumnName("pac_doc_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.pac_nombre)
                    .IsRequired()
                    .HasColumnName("pac_nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.pac_numeroos)
                    .IsRequired()
                    .HasColumnName("pac_numeroos")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.pac_os_iid)
                    .HasColumnName("pac_os_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.pac_prof_iid)
                    .HasColumnName("pac_prof_iid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PacienteContacto>(entity =>
            {
                entity.HasKey(e => e.con_iid);

                entity.ToTable("paciente_contacto");

                entity.Property(e => e.con_iid)
                    .HasColumnName("con_iid")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.con_apellido)
                    .IsRequired()
                    .HasColumnName("con_apellido")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.con_direccion)
                    .IsRequired()
                    .HasColumnName("con_direccion")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.con_nombre)
                    .IsRequired()
                    .HasColumnName("con_nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.con_pac_iid)
                    .HasColumnName("con_pac_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.con_par_iid)
                    .HasColumnName("con_par_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.con_tel_celular)
                    .IsRequired()
                    .HasColumnName("con_tel_celular")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.con_tel_other)
                    .IsRequired()
                    .HasColumnName("con_tel_other")
                    .HasColumnType("varchar(12)");
            });

            modelBuilder.Entity<PacienteHistorial>(entity =>
            {
                entity.HasKey(e => e.hist_pac_iid);

                entity.ToTable("paciente_historial");

                entity.Property(e => e.hist_pac_iid)
                    .HasColumnName("hist_pac_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.hist_pac_acc_iid)
                    .HasColumnName("hist_pac_acc_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.hist_pac_datecreated)
                    .HasColumnName("hist_pac_datecreated")
                    .HasColumnType("date");

                entity.Property(e => e.hist_pac_latlong)
                    .HasColumnName("hist_pac_latlong")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.hist_pac_renglon)
                    .HasColumnName("hist_pac_renglon")
                    .HasColumnType("int(11)");

                entity.Property(e => e.hist_pac_result)
                    .IsRequired()
                    .HasColumnName("hist_pac_result")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Profesional>(entity =>
            {
                entity.HasKey(e => e.prof_iid);

                entity.ToTable("profesional");

                entity.Property(e => e.prof_iid)
                    .HasColumnName("prof_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.prof_apellido)
                    .IsRequired()
                    .HasColumnName("prof_apellido")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.prof_descripcion)
                    .IsRequired()
                    .HasColumnName("prof_descripcion")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.prof_email)
                    .IsRequired()
                    .HasColumnName("prof_email")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.prof_matricula)
                    .IsRequired()
                    .HasColumnName("prof_matricula")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.prof_nombre)
                    .IsRequired()
                    .HasColumnName("prof_nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.prof_telefono)
                    .IsRequired()
                    .HasColumnName("prof_telefono")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.usu_iid);

                entity.ToTable("usuario");

                entity.Property(e => e.usu_iid)
                    .HasColumnName("usu_iid")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.usu_datecreated)
                    .HasColumnName("usu_datecreated")
                    .HasColumnType("date");

                entity.Property(e => e.usu_dni)
                    .IsRequired()
                    .HasColumnName("usu_dni")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.usu_email)
                    .IsRequired()
                    .HasColumnName("usu_email")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.usu_estado)
                    .HasColumnName("usu_estado")
                    .HasColumnType("int(11)");

                entity.Property(e => e.usu_password)
                    .IsRequired()
                    .HasColumnName("usu_password")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.usu_tipo)
                    .HasColumnName("usu_tipo")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<UsuarioPaciente>(entity =>
            {
                entity.HasKey(e => e.usup_usu_iid);

                entity.ToTable("usuario_paciente");

                entity.Property(e => e.usup_usu_iid)
                    .HasColumnName("usup_usu_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.usup_pac_iid)
                    .HasColumnName("usup_pac_iid")
                    .HasColumnType("int(11)");
            });


            // Solo tienen GET
            modelBuilder.Entity<AccionTipo>(entity =>
            {
                entity.HasKey(e => e.acc_iid);

                entity.ToTable("accion_tipo");

                entity.Property(e => e.acc_iid)
                    .HasColumnName("acc_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.acc_descripcion)
                    .IsRequired()
                    .HasColumnName("acc_descripcion")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<ObraSocial>(entity =>
            {
                entity.HasKey(e => e.os_iid);

                entity.ToTable("obra_social");

                entity.Property(e => e.os_iid)
                    .HasColumnName("os_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.os_direccion)
                    .IsRequired()
                    .HasColumnName("os_direccion")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.os_nombre)
                    .IsRequired()
                    .HasColumnName("os_nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.os_telefono)
                    .IsRequired()
                    .HasColumnName("os_telefono")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TipoDocumento>(entity =>
            {
                entity.HasKey(e => e.doc_iid);

                entity.ToTable("tipo_documento");

                entity.Property(e => e.doc_iid)
                    .HasColumnName("doc_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.doc_descripcion)
                    .IsRequired()
                    .HasColumnName("doc_descripcion")
                    .HasColumnType("varchar(20)");
            });

            modelBuilder.Entity<TipoFamiliar>(entity =>
            {
                entity.HasKey(e => e.par_iid);

                entity.ToTable("tipo_familiar");

                entity.Property(e => e.par_iid)
                    .HasColumnName("par_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.par_descripcion)
                    .IsRequired()
                    .HasColumnName("par_descripcion")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<UsuarioEstado>(entity =>
            {
                entity.HasKey(e => e.usuarioestado_iid);

                entity.ToTable("usuario_estado");

                entity.Property(e => e.usuarioestado_iid)
                    .HasColumnName("usuarioestado_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.usuarioestado_descripcion)
                    .IsRequired()
                    .HasColumnName("usuarioestado_descripcion")
                    .HasColumnType("varchar(255)");
            });           

            modelBuilder.Entity<UsuarioTipo>(entity =>
            {
                entity.HasKey(e => e.usut_iid);

                entity.ToTable("usuario_tipo");

                entity.Property(e => e.usut_iid)
                    .HasColumnName("usut_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.usut_descripcion)
                    .IsRequired()
                    .HasColumnName("usut_descripcion")
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
