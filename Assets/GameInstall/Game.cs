using GameInstall;
using GameInstall.Interfaces;

public class Game
{
    public GameStateMachine stateMachine;
    public SceneLoader sceneLoader;

    public Game(ICoroutineRunner coroutineRunner)
    {
        sceneLoader = new SceneLoader(coroutineRunner);
        stateMachine = new GameStateMachine(sceneLoader);
    }
}