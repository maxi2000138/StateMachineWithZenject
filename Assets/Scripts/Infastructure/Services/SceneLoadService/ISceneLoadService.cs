using System;

namespace Infastructure.Services.SceneLoadService
{
    public interface ISceneLoadService : IService
    {
        void LoadScene(string sceneName, Action action = null);
    }
}