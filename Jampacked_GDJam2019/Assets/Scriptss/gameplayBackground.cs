using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameplayBackground : MonoBehaviour
{
    private bool isFirstFrame = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstFrame)
        {
            GameObject[] blobs = GameObject.FindGameObjectsWithTag("Blob");
            for (int i = 0; i < blobs.Length; i++)
                blobs[i].GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(3.0f, 6.0f), Random.Range(3.0f, 6.0f));

            isFirstFrame = false;
        }

        GameObject[] blobs2 = GameObject.FindGameObjectsWithTag("Blob");
        for (int i = 0; i < blobs2.Length; i++)
            blobs2[i].GetComponent<Rigidbody2D>().velocity *= 1.2f;
    }
}
