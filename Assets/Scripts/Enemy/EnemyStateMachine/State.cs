using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] protected List<Transition> _transitions;
    protected Player Target { get; set; }

    public void Enter(Player player)
    {
        if (enabled == false)
        {
            Target = player;
            enabled = true;
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
            enabled = false;
        }
    }

    public State GetState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.NextState;
        }
        return null;
    }
}
