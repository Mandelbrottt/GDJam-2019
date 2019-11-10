using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controllerMovementMenu : MonoBehaviour
{
    string[] aPress = new string[] { "P1A", "P2A", "P3A", "P4A", };
    string[] verticalController = new string[] { "P1Vertical", "P2Vertical", "P3Vertical", "P4Vertical" };
    int cursorPlace = 0;
    public Text[] buttons = new Text[3];
    public GameObject MenuPanel;
    public GameObject HelpPanel;
    bool reset = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < verticalController.Length; i++)
        {


            if ((Input.GetAxis(verticalController[i]) < 0.5f && (Input.GetAxis(verticalController[i]) > -0.5f)) && reset != true)
            {
                reset = true;
            }
            if (reset)
            {
                if (Input.GetAxis(verticalController[i]) > 0.5f)
                {
                    if (cursorPlace != 2)
                    {
                        buttons[cursorPlace].color = Color.black;
                        cursorPlace++;
                        buttons[cursorPlace].color = Color.red;
                        reset = false;
                    }
                }
                else if (Input.GetAxis(verticalController[i]) < -0.5f)
                {

                    if (cursorPlace != 0)
                    {
                        buttons[cursorPlace].color = Color.black;
                        cursorPlace--;
                        buttons[cursorPlace].color = Color.red;
                        reset = false;
                    }

                }
            }
        }
        for (int i = 0; i < aPress.Length; i++)
        {
            if (Input.GetButtonUp(aPress[i]))
            {
                switch (cursorPlace)
                {
                    case 0:
                        SceneManager.LoadScene("CharacterSelect");
                        break;
                    case 1:
                        MenuPanel.SetActive(false);
                        HelpPanel.SetActive(true);
                        break;
                    case 2:
                        Application.Quit();
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
