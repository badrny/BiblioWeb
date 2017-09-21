using BiblioWebServicesCore.Model;
using System.Linq;

namespace BiblioWebServicesCore.Data
{
    public class DBInitializer
    {
        public static void Initialize(BookContext context)
        {
            context.Database.EnsureCreated();
            // Look for exist types
            if (context.Types.Any())
            {
                return;   // DB has been seeded
            }
            ////var book = new Book {Author = "jpl",CoverSrc ="src",Date =DateTime.Now ,Format = Book.BookFormat.numérique ,Title ="la vie est courte"};
            ////var book1 = new Book { Author = "hanouna", CoverSrc = "src", Date = DateTime.Now, Format = Book.BookFormat.Poche, Title = "touche pas a mon poste" };
            ////context.Books.Add(book);
            ////context.Books.Add(book1);
            ////context.SaveChanges();
            var bookTypes = new Model.Type[]
            {
                new Model.Type { Label = "Actu,politique et société"},
                new Model.Type { Label = "Adolescents"},
                new Model.Type { Label = "Art,Musique et Cinéma"},
                new Model.Type { Label = "bandes Dessiné"},
                new Model.Type { Label = "Cuisine et Vins" },
                new Model.Type { Label = "Entreprise et Bourse" },
                new Model.Type { Label = "Fantasy et Terreur" },
                new Model.Type { Label = "Humour" },
                new Model.Type { Label = "Informatique et Internet" },
                new Model.Type { Label = "Romans et Littérature" },
                new Model.Type { Label = "Sciense Fiction" },
                new Model.Type { Label = "Sciense,Techniques et Médecines" },
                new Model.Type { Label = "Science Humaines" },
                new Model.Type { Label = "Sports et Passions" },
                new Model.Type { Label = "Tourisme et Voyage" },
        };
            foreach (Model.Type bt in bookTypes)
            {
                context.Types.Add(bt);
            }
            context.SaveChanges();
        }
    }
}
