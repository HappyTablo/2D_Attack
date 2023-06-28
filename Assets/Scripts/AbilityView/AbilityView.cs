using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbilityView : MonoBehaviour
{
    [SerializeField] protected TMP_Text Label;
    [SerializeField] protected Image Icon;
    [SerializeField] protected Button Button;

    protected Ability Ability;

    protected abstract void OnButtonClick();
}
