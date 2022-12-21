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
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameObject.FindWithTag("Player").GetComponent<Move>().canMove == true){
                GameObject.FindWithTag("Player").GetComponent<Move>().canMove = false;
                objEnemy.SetActive(false);
                Destroy(GameObject.FindWithTag("Enemies"));
                obj.SetActive(true);
            }
            else{
                GameObject.FindWithTag("Player").GetComponent<Move>().canMove = true;
                objEnemy.SetActive(true);
                obj.SetActive(false);
            }
        }
    }
    public void OnRetry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnResume(){
        GameObject.FindWithTag("Player").GetComponent<Move>().canMove = true;
        objEnemy.SetActive(true);
        obj.SetActive(false);
    }

    public void OnQuit(){
        SceneManager.LoadScene(0);
    }
}
