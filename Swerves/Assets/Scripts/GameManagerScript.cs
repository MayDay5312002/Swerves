using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public int time = 0;
    public int lives = 4;
    public GameObject[] livesObjects;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecLives(){
        if(lives > 0){
            livesObjects[lives--].SetActive(false);
        }
        if(lives == 0){
            GameObject.Find("Menu Panel").SetActive(true);
        }
    }
    public void IncScore(){

    }
}
