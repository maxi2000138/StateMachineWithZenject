using Infrastructure;
using UnityEngine;
using Zenject;

public class GameRunner : MonoBehaviour
{
    private GameBootstrapper.Factory _bootstraperFactory;

    [Inject]
    public void Construct(GameBootstrapper.Factory bootstraperFactory)
    {
        _bootstraperFactory = bootstraperFactory;
    }

    private void Awake()
    {
        _bootstraperFactory.Create();
    }
}
