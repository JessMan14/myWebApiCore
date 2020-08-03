using JessieProvider.Models;
using System.Collections.Generic;

namespace JessieProvider.Classes
{
    public class Movie : IStuff
    {
        private List<MovieDataModel> _movieDataModels = new List<MovieDataModel>();

        public Movie()
        {
            CreateMovies();
        }

        public void Add<T>(T t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(int id)
        {
            throw new System.NotImplementedException();
        }

        public T Get<T>()
        {
            throw new System.NotImplementedException();
        }

        public List<T> GetAll<T>()
        {
            return _movieDataModels as List<T>;
        }

        private void CreateMovies()
        {
            MovieDataModel movieDataModelStarWars = new MovieDataModel();
            movieDataModelStarWars.title = "Star Wars";
            movieDataModelStarWars.source = "Amazon Prime";
            _movieDataModels.Add(movieDataModelStarWars);

            MovieDataModel movieDataModelTheMatrix = new MovieDataModel();
            movieDataModelTheMatrix.title = "Star Wars";
            movieDataModelTheMatrix.source = "NetFlix";
            _movieDataModels.Add(movieDataModelTheMatrix);
        }
    }
}
