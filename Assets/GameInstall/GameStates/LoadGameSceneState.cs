using System;
using GameInstall;

namespace Bootstrap.GameStates
{
    public class LoadGameSceneState : IStateWithParam<string>
    {
        private GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;
        
        public LoadGameSceneState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName);
        }

        public void Exit()
        {
            
        }
    }
}