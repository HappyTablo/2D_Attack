using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] protected State _nextState;
    protected Player Target {get; private set;}

    public bool NeedTransit {get; protected set;}
    public State NextState => _nextState;

    public void Init(Player target)
    {
        Target = target;
    }

    private void OnEnable()
    {
        NeedTransit = false;
    }

}
