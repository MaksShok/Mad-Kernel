
using GameInstall;
using GameplayAssets.Input;
using UnityEngine;


namespace Bootstrap.GameStates
{
    public class BootstrapState : IState
    {
        private GameStateMachine _stateMachine;
        private SceneLoader _sceneLoader;

        const string Initial = "Initial";

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        public void Enter()
        {
            RegistrationServices();
            _sceneLoader.Load(Initial, LoadGameScene);
        }

        public void Exit()
        {
            
        }

        private void LoadGameScene()
        {
            _stateMachine.Enter<LoadGameSceneState, string>("GameScene");
        }

        public static IInputService RegistrationServices()
        {
            if (Application.isMobilePlatform)
                return new MobileInputService();
            
            else 
                return new DesktopInputService();
        }
    }
}