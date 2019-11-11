using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controllerMovementMenu : MonoBehaviour
{
    string aButton = "AButton";
    string horizontalController = "Horizontal";
    int cursorPlace = 1;
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
        if ((Input.GetAxis(horizontalController) < 0.5f && (Input.GetAxis(horizontalController) > -0.5f)) && reset != true)
        {
            reset = true;
        }
        if (reset)
        {
            if (Input.GetAxis(horizontalController) > 0.5f)
            {
                if (cursorPlace != 2)
                {
                    buttons[cursorPlace].color = Color.black;
                    cursorPlace++;
                    buttons[cursorPlace].color = Color.red;
                    reset = false;
                }
            }
            else if (Input.GetAxis(horizontalController) < -0.5f)
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

        if (Input.GetButtonUp(aButton)) 
        {
            switch (cursorPlace)
            {
                case 1:
                    SceneManager.LoadScene("CharacterSelect");
                    break;
                case 0:
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
