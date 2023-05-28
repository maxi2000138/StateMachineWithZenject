using System;
using System.Threading.Tasks;

namespace Infrastructure.Services.SceneLoadService
{
    public interface ISceneLoadService : IService
    {
        void LoadScene(string sceneName, Action action = null);
    }
}