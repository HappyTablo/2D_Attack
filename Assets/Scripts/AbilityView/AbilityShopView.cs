using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AbilityShopView : AbilityView
{
    [SerializeField] protected TMP_Text Price;

    public event UnityAction<Ability, AbilityShopView> BuyButtonClick;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
        Button.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
        Button.onClick.RemoveListener(TryLockItem);
    }

    private void TryLockItem()
    {
        if (Ability.isPurchased)
            Button.interactable = false;
    }

    public void Render(Ability ability)
    {
        Ability = ability;
        Label.text = ability.Label;
        Price.text = ability.Price.ToString();
        Icon.sprite = ability.Icon;
    }

    protected override void OnButtonClick() =>
        BuyButtonClick?.Invoke(Ability, this);
}
