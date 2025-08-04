using Systems.MovementSystems;
using Systems.ViewSystems;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private Entitas.Systems _systems;

    private void Start()
    {
        var contexts = Contexts.sharedInstance;

        _systems = new Feature("Systems")
            .Add(new ViewSystems(contexts))
            .Add(new MovementSystems(contexts));

        _systems.Initialize();
    }

    private void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}