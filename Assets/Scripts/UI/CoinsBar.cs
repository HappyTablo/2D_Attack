using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CoinsBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        _text.text = _player.Coins.ToString();
        _player.CoinsChanged += OnCoinsChanged;
    }

    private void OnDisable()
    {
        _player.CoinsChanged -= OnCoinsChanged;
    }

    private void OnCoinsChanged(int coins)
    {
        _text.text = coins.ToString();
    }
}
