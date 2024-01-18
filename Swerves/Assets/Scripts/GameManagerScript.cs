using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript manager;
    public bool higherScore = false;
    public Text bestScoreString;
    public int time = 0;
    public int lives = 4;
    public GameObject liveObject;
    public GameObject MenuPanel;
    public GameObject objEnemy;
    public Text scoreText;
    public Text bestScoreText;
    public float levelSpeed = 1f;
    public AudioSource deathSound;
    public AudioSource dingSound;

    public Animator bestScoreAnimator;
    void Awake(){
        if(manager == null){
            manager = this;
        }
        deathSound = GetComponent<AudioSource>();
        
        

    }
    void OnEnable(){//changed for performance webgl
        if(PlayerPrefs.HasKey("HighScore")){
        bestScoreText.text = PlayerPrefs.GetString("HighScore");
        }
        else{
            PlayerPrefs.SetString("HighScore", "0");
            bestScoreText.text = PlayerPrefs.GetString("HighScore");
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        StartInc();
    }

    // Update is called once per frame
    void Update()
    {
        if((time % 15) == 0 && time != 0){
            levelSpeed += 1f * Time.deltaTime;
        }
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
                // Destroy(GameObject.FindWithTag("Enemies"));
                MenuPanel.SetActive(true);
                GameObject.Find("MenuManager").gameObject.SetActive(false);
                StopInc();
                Move.mover.DeathAnim();
                // higherScore = BestScoreScript.BestScoreWrite();//changed for web gl
                // bestScoreText.text = BestScoreScript.BestScoreRead();
                GameMenuScript.menu.music.Pause();
                Invoke("PlayDeathSound", 1f);
                // if(higherScore == true){
                if(int.Parse(PlayerPrefs.GetString("HighScore")) < time){
                    PlayerPrefs.SetString("HighScore", time.ToString());
                    bestScoreText.text = time.ToString();
                    Invoke("PlayAchieveSound", 2.5f);
                } 
                
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
    void PlayDeathSound(){
        deathSound.Play();
    }

    void PlayAchieveSound(){
        dingSound.Play();
        bestScoreAnimator.SetTrigger("shakeBestScore");
        bestScoreString.color = Color.green;
        bestScoreText.color = Color.green;
        Invoke("higherScoreValueChange", 1.5f);
    }

    void higherScoreValueChange(){
        bestScoreString.color = Color.white;
        bestScoreText.color = Color.white;
        higherScore = false;
    }
}
