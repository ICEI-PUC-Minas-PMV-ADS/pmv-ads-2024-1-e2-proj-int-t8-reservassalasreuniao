using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using reserva_sala_reuniao.Models;


namespace reserva_sala_reuniao.Models
{

    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cargo> Cargos { get; set; }

public DbSet<reserva_sala_reuniao.Models.Admin> Admin { get; set; }

public DbSet<reserva_sala_reuniao.Models.Localizacao> Localizacao { get; set; }

public DbSet<reserva_sala_reuniao.Models.Reserva> Reserva { get; set; }

public DbSet<reserva_sala_reuniao.Models.Sala> Sala { get; set; }

public DbSet<reserva_sala_reuniao.Models.Setor> Setor { get; set; }

public DbSet<reserva_sala_reuniao.Models.Usuario> Usuario { get; set; }

public DbSet<reserva_sala_reuniao.Models.Relatorio> Relatorio { get; set; }

public DbSet<reserva_sala_reuniao.Models.RelatorioTipo> RelatorioTipo { get; set; }
        /*public DbSet<Setor> Setores { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Localizacao> Localizacoes { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<RelatorioTipo> RelatorioTipos { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }*/

        }

 }
