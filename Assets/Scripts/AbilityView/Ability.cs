using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] private Sphere _spherePrefab;
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isPurchased = false;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool isPurchased => _isPurchased;

    public void CastAbility(Transform castPoint) =>
        Instantiate(_spherePrefab, castPoint);
}
