public interface IExitableState
{
    public void Exit();
}

public interface IState : IExitableState
{
    public void Enter();
}

public interface IStateWithParam<T> : IExitableState
{
    public void Enter(T param);
}