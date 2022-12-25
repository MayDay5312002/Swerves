using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript manager;
    public int time = 0;
    public int lives = 4;
    public GameObject liveObject;
    public GameObject MenuPanel;
    public GameObject objEnemy;
    public Text scoreText;
    public Text bestScoreText;

    void Awake(){
        if(manager == null){
            manager = this;
        }
        

    }
    void OnEnable(){
        bestScoreText.text = BestScore.BestScoreRead();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartInc();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecLives(){
        if(lives > 0){
            lives--;
            liveObject.transform.GetChild(lives).gameObject.SetActive(false);
            GameObject.FindWithTag("Player").GetComponent<Renderer>().material.color = Color.red;
            if(lives != 0)
                Invoke("ChangeToOrigColor", 0.5f);
            
        }
        if(lives == 0){
            if(GameObject.FindWithTag("Player").GetComponent<Move>().canMove == true){
                Invoke("ChangeToOrigColor", 2f);
                GameObject.FindWithTag("Player").GetComponent<Move>().canMove = false;
                objEnemy.SetActive(false);
                Destroy(GameObject.FindWithTag("Enemies"));
                MenuPanel.SetActive(true);
                GameObject.Find("MenuManager").gameObject.SetActive(false);
                StopInc();
                Move.mover.DeathAnim();
                BestScore.BestScoreWrite();
                bestScoreText.text = BestScore.BestScoreRead();
                
            }
        }
    }
    public void IncScore(){
        
    }

    void TimeInc(){
        time++;
        scoreText.text = time.ToString();
    }
    public void StopInc(){
        CancelInvoke("TimeInc");
    }
    public void StartInc(){
        InvokeRepeating("TimeInc", 1f, 1f);
    }

    void ChangeToOrigColor(){
        GameObject.FindWithTag("Player").GetComponent<Renderer>().material.color = Color.white;
    }
}
