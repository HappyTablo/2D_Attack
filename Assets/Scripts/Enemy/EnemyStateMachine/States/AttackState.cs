using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delayBetweenAttack;
    private float _lastAttackTime;
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delayBetweenAttack;
        }
        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack(Player player)
    {
        _animator.Play("EnemyAttack");
        player.ApplyDamage(_damage);
    }
}
