using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    private Player _player;
    private State _currentState;
    public State CurrentState => _currentState;

    private void Start()
    {
        _player = GetComponent<Enemy>().Target;
        SetState(_firstState);
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        var nextState = _currentState.GetState();
        if (nextState != null)
            SetState(nextState);
    }

    private void SetState(State state)
    {
        _currentState?.Exit();
        _currentState = state;
        _currentState?.Enter(_player);
    }

}
