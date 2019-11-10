using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenuController : MonoBehaviour
{
    string[] aPress = new string[] {"P1A", "P2A", "P3A", "P4A", };
    public GameObject MenuPanel;
    public GameObject HelpPanel;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < aPress.Length; i++)
        {
            if (Input.GetButtonUp(aPress[i]))
            {
                MenuPanel.SetActive(true);
                HelpPanel.SetActive(false);
            }
        }
    }
}
