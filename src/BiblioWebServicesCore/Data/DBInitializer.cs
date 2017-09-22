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
                return; // DB has been seeded
            
         var bookTypes = new[]
            {
                new Type { Label = "Actu,politique et société"},
                new Type { Label = "Adolescents"},
                new Type { Label = "Art,Musique et Cinéma"},
                new Type { Label = "bandes Dessiné"},
                new Type { Label = "Cuisine et Vins" },
                new Type { Label = "Entreprise et Bourse" },
                new Type { Label = "Fantasy et Terreur" },
                new Type { Label = "Humour" },
                new Type { Label = "Informatique et Internet" },
                new Type { Label = "Romans et Littérature" },
                new Type { Label = "Sciense Fiction" },
                new Type { Label = "Sciense,Techniques et Médecines" },
                new Type { Label = "Science Humaines" },
                new Type { Label = "Sports et Passions" },
                new Type { Label = "Tourisme et Voyage" },
        };
            foreach (Type bt in bookTypes)
            {
                context.Types.Add(bt);
            }
            context.SaveChanges();
        }
    }
}
