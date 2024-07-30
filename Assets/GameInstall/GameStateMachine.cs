using System;
using System.Collections.Generic;
using Bootstrap.GameStates;
using GameInstall;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateMachine
{
    private readonly Dictionary<Type, IExitableState> _states;

    public GameStateMachine(SceneLoader sceneLoader)
    {
        _states = new Dictionary<Type, IExitableState>
        {
            { typeof(BootstrapState), new BootstrapState(this, sceneLoader) },
            { typeof(LoadGameSceneState), new LoadGameSceneState(this, sceneLoader) },
        };
    }

    public void Enter<TState>() where TState : class, IState
    {
        IState state = GetState<TState>();
        state?.Enter();

        Debug.Log("Состояние активно " + state.GetType().Name); // проверка
    }

    public void Enter<TState, T>(T param) where TState : class, IStateWithParam<T>
    {
        IStateWithParam<T> state = GetState<TState>();
        state?.Enter(param);

        Debug.Log("Состояние активно " + state.GetType().Name); // проверка
    }

    private TState GetState<TState>() where TState : class, IExitableState
    {
        var state = _states[typeof(TState)];
        return state as TState;
    }
}