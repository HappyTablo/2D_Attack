using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<Ability> abilities;
    [SerializeField] private AbilityInventoryView abilityInventoryView;
    [SerializeField] private GameObject container;

    private List<AbilityInventoryView> _abilityViews = new List<AbilityInventoryView>();
    public Ability currentAbility;

    private void Start()
    {
        AddAbilityView(currentAbility);
    }
    public void AddAbility(Ability ability)
    {
        abilities.Add(ability);
        AddAbilityView(ability);
    }

    private void AddAbilityView(Ability ability)
    {
        var view = Instantiate(abilityInventoryView, container.transform);
        view.RenderAbilityInInventory(ability);
        _abilityViews.Add(view);
        view.ChangedAbility += SetAbility;
    }

    private void SetAbility(Ability ability)
    {
        currentAbility = ability;
    }

    private void OnDisable()
    {
        foreach(var view in _abilityViews)
        {
            if(view != null)
                view.ChangedAbility -= SetAbility;
        }
    }
}
