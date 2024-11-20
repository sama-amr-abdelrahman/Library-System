using Library_System.AppContext;

namespace Library_System.Repository_Pattern.Genre
{
    public class GenreRepo : IGenreRepo
    {
        private readonly AppDbContext _context;
        public GenreRepo(AppDbContext context)
        {
            _context = context;
        }
    }
}
