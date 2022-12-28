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
        Invoke("Starts", 0.191f);
    }

    public void OnQuits(){
        clickSound.Play();
        Invoke("Quits", 0.191f);
    }
    void Quits(){
        Application.Quit();
    }

    void Starts(){
        SceneManager.LoadScene(1);
    }
}
