using UnityEngine.Events;
using UnityEngine.UI;

public class AbilityInventoryView : AbilityView
{
    public event UnityAction<Ability> ChangedAbility;
    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }

    public void RenderAbilityInInventory(Ability ability)
    {
        this.Ability = ability;
        Icon.sprite = ability.Icon;
        Label.text = ability.Label;
    }

    protected override void OnButtonClick()
    {
        ChangedAbility?.Invoke(Ability);
    }
}
