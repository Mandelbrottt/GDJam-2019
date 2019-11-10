using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameplayBackground : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject[] blobList;
    Vector3[] position = new Vector3[4];

    void Start()
    {
        for (int i = 0; i < position.Length; i++)
        {
            position[i] = new Vector3(i, i, 0);
        }
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Additive);
        for (int i = 0; i < 4; i++)
        {
            blobList = Resources.LoadAll<GameObject>("Prefabs");
            Instantiate(blobList[i]);
            blobList[i].transform.position = position[i];
            blobList[i].transform.position += new Vector3(-9.0f + (2.0f * i + 0.95f) * 18.0f / 8.0f, 0.3f);


        }
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
