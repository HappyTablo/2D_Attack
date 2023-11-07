using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    
    private Player _player;
    public Player Target => _player;

    public void Init(Player target)
    {
        _player = target;
    }

    public void ApplyDamage(int damage) =>
        _health -= damage;

    private void Update()
    {
        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        _player.AddCoins(_reward);
    }
}
