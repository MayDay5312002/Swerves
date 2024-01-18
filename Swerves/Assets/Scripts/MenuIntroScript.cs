using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuIntroScript : MonoBehaviour
{
    int count = 0;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        BestScoreScript.EncryptionBypass();
    }

    // Update is called once per frame
    void Update()
    {
        if((GameObject.Find("Player") == false && count == 0) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab)){
            panel.SetActive(true);
            count++;
        }
    }
}
