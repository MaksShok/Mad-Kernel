using System;
using GameInstall;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
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
            // тут проходит регистарция того что нам нужно
            _sceneLoader.Load(Initial, LoadGameScene);
        }

        public void Exit()
        {
            
        }

        private void LoadGameScene()
        {
            _stateMachine.Enter<LoadGameSceneState, string>("GameScene");
        }
    }
}