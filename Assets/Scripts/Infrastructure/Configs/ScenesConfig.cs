using System;
using UnityEngine;
using Zenject;

namespace Infrastructure.Configs
{
    [CreateAssetMenu(fileName = "new Settings",menuName = "Installers/SceneSettings")]
    public class ScenesConfig : ScriptableObjectInstaller<ScenesConfig>
    {
        public SceneSettings BootstrapSceneSettings;
        public SceneSettings GameSceneSettings;
    
        [Serializable]
        public class SceneSettings
        {
            public string Name;
        }

        public override void InstallBindings()
        {
            Container.BindInstance(this);
        }
    }
}
