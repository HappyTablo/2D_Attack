using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrityState : State
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _animator.Play("EnemyCelebrity");
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
