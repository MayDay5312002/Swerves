using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class MenuTutorial : MonoBehaviour
{
    public static MenuTutorial menuer;
    public bool canEscape;
    public GameObject menu;
    public bool menuState = false;
    public AudioSource clickSound;
    void Awake(){
        menuer = this;
        canEscape = File.Exists("erocs.txt");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && canEscape){
            if(!menuState){
                menu.gameObject.SetActive(true);
                menuState = true;
                GameObject.FindWithTag("Player").GetComponent<MoveTutorial>().canMove = false;
                GameObject.FindWithTag("Player").GetComponent<MoveTutorial>().animator.SetTrigger("idled");
                GameObject.FindWithTag("Player").GetComponent<MoveTutorial>().animator.SetBool("Run", false);
                GameObject.FindWithTag("Player").GetComponent<MoveTutorial>().animator.SetBool("Idle", true);

            }
            else{
                menu.gameObject.SetActive(false);
                menuState = false;
                MoveTutorial.mover.canMove = true;
            }
        }
    }
    public void OnStart(){
        clickSound.Play();
        if(!File.Exists("erocs.txt")){//if file does not exist
            CreateFile();//creates a file before starting the actual game so it wont "ERROR" best score.
        }
        else{
            if(new FileInfo("erocs.txt").Length == 0){// file does exist but empty.
                CreateFile();
            }
        }
        SceneManager.LoadScene(1);
    }
    public void OnQuit(){
        clickSound.Play();
        if(!File.Exists("erocs.txt")){//if file does not exist
            CreateFile();//creates a file before starting the actual game so it wont "ERROR" best score.
        }
        else{
            if(new FileInfo("erocs.txt").Length == 0){// file does exist but empty.
                CreateFile();
            }
        }
        SceneManager.LoadScene(0);
    }

    public void CreateFile(){
        StreamWriter writer = new StreamWriter("erocs.txt", false);
        writer.WriteLine("0");
        writer.Close();
    }
}
