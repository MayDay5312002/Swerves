using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTutorial : MonoBehaviour
{   
    Animator animator;
    public GameObject jumpText;
    public GameObject slideText;
    public Text moveTutorial;
    public Text jumpTutorial;
    public Text slideTutorial;
    public Text slideTutorial2;
    public Text slideTutorial3;
    int hit = 0;
    void Awake(){
        animator = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Horizontal") && hit++ == 0){
            moveTutorial.color = Color.green;
            jumpText.SetActive(true);
        }
        if(Input.GetButtonDown("Jump") && hit++ == 1){
            jumpTutorial.color = Color.green;
            slideText.SetActive(true);
        }
        if((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && hit == 2)
            slideTutorial.color = Color.green;
            


    }
    
}
