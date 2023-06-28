using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject _panel; 
    public void OpenPanel()
    {
        _panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClosePanel()
    {
        _panel.SetActive(false);
        Time.timeScale = 1;
    }
}
