using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void OpenPanel(string name)
    {
        panel.SetActive(!panel.activeSelf);
    }
}
