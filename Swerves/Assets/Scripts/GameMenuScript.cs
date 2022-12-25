using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public GameObject obj;
    public GameObject objEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) ){
            if(GameObject.FindWithTag("Player").GetComponent<Move>().canMove == true){
                GameObject.FindWithTag("Player").GetComponent<Move>().canMove = false;
                objEnemy.SetActive(false);
                // Destroy(GameObject.FindWithTag("Enemies"));
                obj.SetActive(true);
                GameManagerScript.manager.StopInc();
                if(GameManagerScript.manager.time >= 2)
                    GameManagerScript.manager.time -= 2;//-2 seconds for each pause
                GameManagerScript.manager.scoreText.text = GameManagerScript.manager.time.ToString();
                Move.mover.animator.SetBool("Run", false);
                Move.mover.animator.SetTrigger("idled");
            }
            else{
                GameObject.FindWithTag("Player").GetComponent<Move>().canMove = true;
                objEnemy.SetActive(true);
                obj.SetActive(false);
                GameManagerScript.manager.StartInc();
            }
        }
    }
    public void OnRetry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnResume(){
        if(GameManagerScript.manager.lives > 0){
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
        SceneManager.LoadScene(0);
    }

    
}
