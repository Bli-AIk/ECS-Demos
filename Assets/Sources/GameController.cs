using Sources.Systems;
using UnityEngine;

namespace Sources
{
    public class GameController : MonoBehaviour
    {
        private Contexts _contexts;
        private Entitas.Systems _systems;

        private void Start()
        {
            _contexts = Contexts.sharedInstance;
            _systems = CreateSystems(_contexts);
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private static Entitas.Systems CreateSystems(Contexts contexts)
        {
            return new Feature("Systems")
                .Add(new InitializeSystems(contexts))
                .Add(new ViewSystems(contexts))
                .Add(new InputSystems(contexts));
        }
    }
}