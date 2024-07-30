using System;
using System.Collections;
using System.Collections.Generic;
using Bootstrap.GameStates;
using GameInstall;
using GameInstall.Interfaces;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
{
    private Game _game;

    private void Awake()
    {
        _game = new Game(this);
        _game.stateMachine.Enter<BootstrapState>();
        
        DontDestroyOnLoad(this);
    }
}