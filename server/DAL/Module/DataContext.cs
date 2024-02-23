using DAL.Enum;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;

namespace DAL.Module
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
            options.UseSqlite(b => b.MigrationsAssembly("server"));
        }

        public DbSet<Card> cards => Set<Card>();
        public DbSet<Game> game => Set<Game>();
        public DbSet<GameCard> gameCard => Set<GameCard>();
        public DbSet<Player> player => Set<Player>();
        public DbSet<GamePlayer> gamePlayer => Set<GamePlayer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameCard>()
            .HasOne(e => e.Game)
            .WithMany(e => e.GameCard)
            .HasForeignKey(e => e.GameId)
            .IsRequired();

            modelBuilder.Entity<GameCard>()
            .HasOne(e => e.Card)
            .WithMany(e => e.GameCard)
            .HasForeignKey(e => e.CardId)
            .IsRequired();

            modelBuilder.Entity<GameCard>()
            .HasOne(e => e.FlippedPlayer)
            .WithMany(e => e.GameCard)
            .HasForeignKey(e => e.FlippedPlayerId);


            modelBuilder.Entity<Card>()
                .HasData(
                new Card { Id = 1, Name = "CLUBS A", Image = "AC.png", CardCategory = CardCategory.CLUBS, CardType = CardType.ACE},
                new Card { Id = 2, Name = "CLUBS 2", Image = "2C.png", CardCategory = CardCategory.CLUBS, CardType = CardType.TWO },
                new Card { Id = 3, Name = "CLUBS 3", Image = "3C.png", CardCategory = CardCategory.CLUBS, CardType = CardType.THREE},
                new Card { Id = 4, Name = "CLUBS 4", Image = "4C.png", CardCategory = CardCategory.CLUBS, CardType = CardType.FOUR},
                new Card { Id = 5, Name = "CLUBS 5", Image = "5C.png", CardCategory = CardCategory.CLUBS, CardType = CardType.FIVE},
                new Card { Id = 6, Name = "CLUBS 6", Image = "6C.png", CardCategory = CardCategory.CLUBS, CardType = CardType.SIX},
                new Card { Id = 7, Name = "CLUBS 7", Image = "7C.png", CardCategory = CardCategory.CLUBS, CardType = CardType.SEVEN},
                new Card { Id = 8, Name = "CLUBS 8", Image = "8C.png", CardCategory = CardCategory.CLUBS, CardType = CardType.EIGHT},
                new Card { Id = 9,Name = "CLUBS 9", Image = "9C.png", CardCategory = CardCategory.CLUBS, CardType = CardType.NINE},
                new Card { Id = 10, Name = "CLUBS 10", Image = "10C.png", CardCategory = CardCategory.CLUBS, CardType = CardType.TEN},
                new Card { Id=11, Name = "CLUBS J", Image = "JC.png", CardCategory = CardCategory.CLUBS, CardType = CardType.JACK},
                new Card { Id=12, Name = "CLUBS Q", Image = "QC.png", CardCategory = CardCategory.CLUBS, CardType = CardType.QUEEN},
                new Card { Id=13, Name = "CLUBS K", Image = "KC.png", CardCategory = CardCategory.CLUBS, CardType = CardType.KING},

                new Card { Id = 14, Name = "DIAMONDS A", Image = "AD.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.ACE },
                new Card { Id = 15, Name = "DIAMONDS 2", Image = "2D.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.TWO },
                new Card { Id = 16, Name = "DIAMONDS 3", Image = "3D.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.THREE },
                new Card { Id = 17, Name = "DIAMONDS 4", Image = "4D.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.FOUR },
                new Card { Id = 18, Name = "DIAMONDS 5", Image = "5D.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.FIVE },
                new Card { Id = 19, Name = "DIAMONDS 6", Image = "6D.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.SIX },
                new Card { Id = 20, Name = "DIAMONDS 7", Image = "7D.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.SEVEN },
                new Card { Id = 21, Name = "DIAMONDS 8", Image = "8D.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.EIGHT },
                new Card { Id = 22, Name = "DIAMONDS 9", Image = "9D.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.NINE },
                new Card { Id = 23, Name = "DIAMONDS 10", Image = "10D.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.NINE },
                new Card { Id = 24, Name = "DIAMONDS J", Image = "JD.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.JACK },
                new Card { Id = 25, Name = "DIAMONDS Q", Image = "QD.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.KING },
                new Card { Id = 26, Name = "DIAMONDS K", Image = "KD.png", CardCategory = CardCategory.DIAMONDS, CardType = CardType.QUEEN },

                new Card { Id = 27, Name = "HEARTS A", Image = "AH.png", CardCategory = CardCategory.HEARTS, CardType = CardType.ACE },
                new Card { Id = 28, Name = "HEARTS 2", Image = "2H.png", CardCategory = CardCategory.HEARTS , CardType = CardType.TWO },
                new Card { Id = 29, Name = "HEARTS 3", Image = "3H.png", CardCategory = CardCategory.HEARTS , CardType = CardType.THREE },
                new Card { Id = 30, Name = "HEARTS 4", Image = "4H.png", CardCategory = CardCategory.HEARTS , CardType = CardType.FOUR },
                new Card { Id = 31, Name = "HEARTS 5", Image = "5H.png", CardCategory = CardCategory.HEARTS , CardType = CardType.FIVE },
                new Card { Id = 32, Name = "HEARTS 6", Image = "6H.png", CardCategory = CardCategory.HEARTS , CardType = CardType.SIX },
                new Card { Id = 33, Name = "HEARTS 7", Image = "7H.png", CardCategory = CardCategory.HEARTS , CardType = CardType.SEVEN },
                new Card { Id = 34, Name = "HEARTS 8", Image = "8H.png", CardCategory = CardCategory.HEARTS , CardType = CardType.EIGHT },
                new Card { Id = 35, Name = "HEARTS 9", Image = "9H.png", CardCategory = CardCategory.HEARTS , CardType = CardType.NINE },
                new Card { Id = 36, Name = "HEARTS 10", Image = "10H.png", CardCategory = CardCategory.HEARTS , CardType = CardType.TEN },
                new Card { Id = 37, Name = "HEARTS J", Image = "JH.png", CardCategory = CardCategory.HEARTS , CardType = CardType.JACK },
                new Card { Id = 38, Name = "HEARTS Q", Image = "QH.png", CardCategory = CardCategory.HEARTS , CardType = CardType.QUEEN },
                new Card { Id = 39, Name = "HEARTS K", Image = "KH.png", CardCategory = CardCategory.HEARTS , CardType = CardType.KING },

                new Card { Id = 40, Name = "SPADES A", Image = "AS.png", CardCategory = CardCategory.SPADES, CardType = CardType.ACE },
                new Card { Id = 41, Name = "SPADES 2", Image = "2S.png", CardCategory = CardCategory.SPADES , CardType = CardType.TWO },
                new Card { Id = 42, Name = "SPADES 3", Image = "3S.png", CardCategory = CardCategory.SPADES , CardType = CardType.THREE },
                new Card { Id = 43, Name = "SPADES 4", Image = "4S.png", CardCategory = CardCategory.SPADES , CardType = CardType.FOUR },
                new Card { Id = 44, Name = "SPADES 5", Image = "5S.png", CardCategory = CardCategory.SPADES , CardType = CardType.FIVE },
                new Card { Id = 45, Name = "SPADES 6", Image = "6S.png", CardCategory = CardCategory.SPADES , CardType = CardType.SIX },
                new Card { Id = 46, Name = "SPADES 7", Image = "7S.png", CardCategory = CardCategory.SPADES , CardType = CardType.SEVEN },
                new Card { Id = 47, Name = "SPADES 8", Image = "8S.png", CardCategory = CardCategory.SPADES , CardType = CardType.EIGHT },
                new Card { Id = 48, Name = "SPADES 9", Image = "9S.png", CardCategory = CardCategory.SPADES , CardType = CardType.NINE },
                new Card { Id = 49, Name = "SPADES 10", Image = "10S.png", CardCategory = CardCategory.SPADES , CardType = CardType.TEN },
                new Card { Id = 50, Name = "SPADES J", Image = "JS.png", CardCategory = CardCategory.SPADES , CardType = CardType.JACK },
                new Card { Id = 51, Name = "SPADES Q", Image = "QS.png", CardCategory = CardCategory.SPADES , CardType = CardType.QUEEN },
                new Card { Id = 52, Name = "SPADES K", Image = "KS.png", CardCategory = CardCategory.SPADES , CardType = CardType.KING }
            );
            modelBuilder.Entity<Card>().Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Player>()
                .HasData(new Player { Id = 1, Name = "Player 1" }, new Player { Id = 2, Name = "Player 2" });
        }
    }
}
