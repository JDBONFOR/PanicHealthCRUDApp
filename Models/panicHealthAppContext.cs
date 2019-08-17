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
                entity.HasKey(e => e.PacIid);

                entity.ToTable("paciente");

                entity.HasIndex(e => e.PacDocIid)
                    .HasName("fk_pac_doc_iid");

                entity.HasIndex(e => e.PacOsIid)
                    .HasName("fk_pac_os_iid");

                entity.HasIndex(e => e.PacProfIid)
                    .HasName("fk_pac_prof_iid");

                entity.Property(e => e.PacIid)
                    .HasColumnName("pac_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PacApellido)
                    .IsRequired()
                    .HasColumnName("pac_apellido")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PacDni)
                    .IsRequired()
                    .HasColumnName("pac_dni")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PacDocIid)
                    .HasColumnName("pac_doc_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PacNombre)
                    .IsRequired()
                    .HasColumnName("pac_nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PacNumeroos)
                    .IsRequired()
                    .HasColumnName("pac_numeroos")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.PacOsIid)
                    .HasColumnName("pac_os_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PacProfIid)
                    .HasColumnName("pac_prof_iid")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.PacDocI)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.PacDocIid)
                    .HasConstraintName("paciente_ibfk_1");

                entity.HasOne(d => d.PacOsI)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.PacOsIid)
                    .HasConstraintName("paciente_ibfk_3");

                entity.HasOne(d => d.PacProfI)
                    .WithMany(p => p.Paciente)
                    .HasForeignKey(d => d.PacProfIid)
                    .HasConstraintName("paciente_ibfk_2");
            });

            modelBuilder.Entity<PacienteContacto>(entity =>
            {
                entity.HasKey(e => e.ConIid);

                entity.ToTable("paciente_contacto");

                entity.HasIndex(e => e.ConParIid)
                    .HasName("fk_con_par_iid");

                entity.Property(e => e.ConIid)
                    .HasColumnName("con_iid")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ConApellido)
                    .IsRequired()
                    .HasColumnName("con_apellido")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ConDireccion)
                    .IsRequired()
                    .HasColumnName("con_direccion")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ConNombre)
                    .IsRequired()
                    .HasColumnName("con_nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ConPacIid)
                    .HasColumnName("con_pac_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ConParIid)
                    .HasColumnName("con_par_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ConTelCelular)
                    .IsRequired()
                    .HasColumnName("con_tel_celular")
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.ConTelOther)
                    .IsRequired()
                    .HasColumnName("con_tel_other")
                    .HasColumnType("varchar(12)");

                entity.HasOne(d => d.ConI)
                    .WithOne(p => p.PacienteContacto)
                    .HasForeignKey<PacienteContacto>(d => d.ConIid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("paciente_contacto_ibfk_2");

                entity.HasOne(d => d.ConParI)
                    .WithMany(p => p.PacienteContacto)
                    .HasForeignKey(d => d.ConParIid)
                    .HasConstraintName("paciente_contacto_ibfk_1");
            });

            modelBuilder.Entity<PacienteHistorial>(entity =>
            {
                entity.HasKey(e => e.HistPacIid);

                entity.ToTable("paciente_historial");

                entity.HasIndex(e => e.HistPacAccIid)
                    .HasName("fk_hist_pac_acc_iid");

                entity.Property(e => e.HistPacIid)
                    .HasColumnName("hist_pac_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HistPacAccIid)
                    .HasColumnName("hist_pac_acc_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HistPacDatecreated)
                    .HasColumnName("hist_pac_datecreated")
                    .HasColumnType("date");

                entity.Property(e => e.HistPacLatlong)
                    .HasColumnName("hist_pac_latlong")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.HistPacRenglon)
                    .HasColumnName("hist_pac_renglon")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HistPacResult)
                    .IsRequired()
                    .HasColumnName("hist_pac_result")
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.HistPacAccI)
                    .WithMany(p => p.PacienteHistorial)
                    .HasForeignKey(d => d.HistPacAccIid)
                    .HasConstraintName("paciente_historial_ibfk_1");

                entity.HasOne(d => d.HistPacI)
                    .WithOne(p => p.PacienteHistorial)
                    .HasForeignKey<PacienteHistorial>(d => d.HistPacIid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("paciente_historial_ibfk_2");
            });

            modelBuilder.Entity<Profesional>(entity =>
            {
                entity.HasKey(e => e.ProfIid);

                entity.ToTable("profesional");

                entity.Property(e => e.ProfIid)
                    .HasColumnName("prof_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProfApellido)
                    .IsRequired()
                    .HasColumnName("prof_apellido")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ProfDescripcion)
                    .IsRequired()
                    .HasColumnName("prof_descripcion")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ProfEmail)
                    .IsRequired()
                    .HasColumnName("prof_email")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ProfMatricula)
                    .IsRequired()
                    .HasColumnName("prof_matricula")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.ProfNombre)
                    .IsRequired()
                    .HasColumnName("prof_nombre")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.ProfTelefono)
                    .IsRequired()
                    .HasColumnName("prof_telefono")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.usu_iid);

                entity.ToTable("usuario");

                entity.HasIndex(e => e.usu_estado)
                    .HasName("fk_cat");

                entity.HasIndex(e => e.usu_tipo)
                    .HasName("fk_usu_tipo");

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

                entity.HasOne(d => d.UsuEstadoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.usu_estado)
                    .HasConstraintName("usuario_ibfk_1");

                entity.HasOne(d => d.UsuI)
                    .WithOne(p => p.Usuario)
                    .HasForeignKey<Usuario>(d => d.usu_iid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_ibfk_4");

                entity.HasOne(d => d.UsuTipoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.usu_tipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_ibfk_3");
            });

            modelBuilder.Entity<UsuarioPaciente>(entity =>
            {
                entity.HasKey(e => e.UsupUsuIid);

                entity.ToTable("usuario_paciente");

                entity.HasIndex(e => e.UsupPacIid)
                    .HasName("fk_usup_pac_iid");

                entity.Property(e => e.UsupUsuIid)
                    .HasColumnName("usup_usu_iid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsupPacIid)
                    .HasColumnName("usup_pac_iid")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.UsupPacI)
                    .WithMany(p => p.UsuarioPaciente)
                    .HasForeignKey(d => d.UsupPacIid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_paciente_ibfk_1");
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
