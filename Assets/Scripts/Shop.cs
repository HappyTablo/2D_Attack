using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Ability> _abilities;
    [SerializeField] private Player _player;
    [SerializeField] private AbilityShopView _abilityView;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for(int i = 0; i < _abilities.Count; i++)
            AddItem(_abilities[i]);
    }

    private void AddItem(Ability ability)
    {
        var view = Instantiate(_abilityView, _itemContainer.transform);
        view.BuyButtonClick += OnBuyButtonClick;
        view.Render(ability);
    }

    private void OnBuyButtonClick(Ability ability, AbilityShopView view)
    {
        TryBuyAbility(ability, view);
    }

    private void TryBuyAbility(Ability ability, AbilityShopView view)
    {
        if(ability.Price <= _player.Coins)
        {
            _player.BuyAbility(ability);
            view.BuyButtonClick -= OnBuyButtonClick;
        }
    }
}
