using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controllerMovementMenu : MonoBehaviour
{
    string aButton = "AButton";
    string verticalController = "Vertical";
    int cursorPlace = 0;
    public Text[] buttons = new Text[3];
    public GameObject MenuPanel;
    public GameObject HelpPanel;
    bool reset = false;

    public GameObject soundPrefab;

    private GameObject sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = Instantiate(soundPrefab);
        DontDestroyOnLoad(sound);

        GameObject.Find("mhappy").GetComponent<AudioSource>().loop = true;
        GameObject.Find("mhappy").GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetAxis(verticalController) < 0.5f && (Input.GetAxis(verticalController) > -0.5f)) && reset != true)
        {
            reset = true;
        }
        if (reset)
        {
            if (Input.GetAxis(verticalController) > 0.5f)
            {
                if (cursorPlace != 2)
                {
                    buttons[cursorPlace].color = Color.black;
                    cursorPlace++;
                    buttons[cursorPlace].color = Color.red;
                    reset = false;
                }

                GameObject.Find("uimove").GetComponent<AudioSource>().Play();
            }
            else if (Input.GetAxis(verticalController) < -0.5f)
            {

                if (cursorPlace != 0)
                {
                    buttons[cursorPlace].color = Color.black;
                    cursorPlace--;
                    buttons[cursorPlace].color = Color.red;
                    reset = false;
                }

                GameObject.Find("uimove").GetComponent<AudioSource>().Play();
            }

        }

        if (Input.GetButtonUp(aButton)) 
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

            GameObject.Find("uiselect").GetComponent<AudioSource>().Play();
        }

    }
}
