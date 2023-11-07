using UnityEngine.Events;
using UnityEngine.UI;

public class AbilityInventoryView : AbilityView
{
    public event UnityAction<Ability> ChangedAbility;
    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }

    public void RenderAbilityInInventory(Ability ability)
    {
        Ability = ability;
        Icon.sprite = ability.Icon;
        Label.text = ability.Label;
    }

    protected override void OnButtonClick()
    {
        ChangedAbility?.Invoke(Ability);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }
}
