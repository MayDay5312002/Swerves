using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStarts(){
        clickSound.Play();
        //if(BestScoreScript.CheckFileExist()){//changed for webGL
        if(PlayerPrefs.HasKey("HighScore")){
        SceneManager.LoadScene(1);
        }
        else{
            SceneManager.LoadScene(2);
        }

    }

    public void OnQuits(){
        clickSound.Play();
        Invoke("Quits", .20f);
    }

    public void OnTutorial(){
        clickSound.Play();
        SceneManager.LoadScene(2);
    }
    void Quits(){
        Application.Quit();
    }

    // void Starts(){
    //     SceneManager.LoadScene(1);
    // }

    
}
