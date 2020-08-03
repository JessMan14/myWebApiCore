using JessieProvider.Models;
using System.Collections.Generic;

namespace JessieProvider.Classes
{
    public class Surfboard : IStuff
    {
        private List<SurfboardDataModel> _surfboardDataModels = new List<SurfboardDataModel>();

        public Surfboard()
        {
            CreateSurfboards();
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
            return _surfboardDataModels as List<T>;
        }

        private void CreateSurfboards()
        {
            SurfboardDataModel surfboardDataModelSampler = new SurfboardDataModel();
            surfboardDataModelSampler.manufacturer = "Channel Islands";
            surfboardDataModelSampler.model = "Sampler";
            surfboardDataModelSampler.height = 5.11;
            surfboardDataModelSampler.width = 2.5;
            surfboardDataModelSampler.volume = 32.0;
            _surfboardDataModels.Add(surfboardDataModelSampler);

            SurfboardDataModel surfboardDataModelPodMod = new SurfboardDataModel();
            surfboardDataModelPodMod.manufacturer = "Channel Islands";
            surfboardDataModelPodMod.model = "Pod Mod";
            surfboardDataModelPodMod.height = 5.11;
            surfboardDataModelPodMod.width = 2.6;
            surfboardDataModelPodMod.volume = 36.0;
            _surfboardDataModels.Add(surfboardDataModelPodMod);
        }

    }
}
