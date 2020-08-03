using JessieProvider.Classes;
using JessieProvider.Models;
using System.Collections.Generic;

namespace JessieProvider
{
    public class JessieItemsProvider
    {
        public List<SurfboardDataModel> GetSurfboards()
        {
            Surfboard surfboard = new Surfboard();
            return surfboard.GetAll<SurfboardDataModel>(); ;
        }

        public List<MovieDataModel> GetMovies()
        {
            Movie movie = new Movie();
            return movie.GetAll<MovieDataModel>(); ;
        }
    }
}
