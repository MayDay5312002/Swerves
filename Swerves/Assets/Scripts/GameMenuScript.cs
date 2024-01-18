using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public static GameMenuScript menu;
    public GameObject obj;
    public GameObject objEnemy;
    [SerializeField] private AudioSource clickSound;
    public AudioSource music;

    public GameObject negTwo;
    void Awake(){
        music = GameObject.Find("Canvas").GetComponent<AudioSource>();
        if(menu == null)
            menu = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape)){
            if(GameObject.FindWithTag("Player").GetComponent<Move>().canMove == true){
                music.Pause();
                GameObject.FindWithTag("Player").GetComponent<Move>().canMove = false;
                objEnemy.SetActive(false);
                // Destroy(GameObject.FindWithTag("Enemies"));
                obj.SetActive(true);
                GameManagerScript.manager.StopInc();
                if(GameManagerScript.manager.time >= 2){
                    GameManagerScript.manager.time -= 2;//-2 seconds for each pause
                    negTwo.SetActive(true);
                }
                GameManagerScript.manager.scoreText.text = GameManagerScript.manager.time.ToString();
                Move.mover.animator.SetBool("Run", false);
                Move.mover.animator.SetTrigger("idled");
                SpawnScript.spawner.CancelInvokes();//Everytime escape is pressed and if there is a spawn invoke, then that spawn invoke will be canceled
                
            }
            else{
                music.Play();
                GameObject.FindWithTag("Player").GetComponent<Move>().canMove = true;
                objEnemy.SetActive(true);
                obj.SetActive(false);
                GameManagerScript.manager.StartInc();
                negTwo.SetActive(false);
                
            }
        }
    }
    public void OnRetry(){
        clickSound.Play();
        Invoke("Retries",0.191f);
    }
    public void OnResume(){
        clickSound.Play();
        if(GameManagerScript.manager.lives > 0){
            music.Play();
            GameObject.FindWithTag("Player").GetComponent<Move>().canMove = true;
            objEnemy.SetActive(true);
            obj.SetActive(false);
            GameManagerScript.manager.StartInc();
        }
        else{
            //add something here letting know the gamer that you cannot continue because he/she is dead
        }
    }

    public void OnQuit(){
        clickSound.Play();
        Invoke("Quits",0.191f);
    }

    void Retries(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void Quits(){
        SceneManager.LoadScene(0);
    }

    
}
