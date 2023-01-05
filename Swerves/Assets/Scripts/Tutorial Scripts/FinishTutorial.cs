using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishTutorial : MonoBehaviour
{   
    Animator animator;
    public GameObject nextTutorial;
    public GameObject jumpText;
    public GameObject slideText;
    public Text moveTutorial;
    public Text jumpTutorial;
    public Text slideTutorial;
    public Text slideTutorial2;
    public Text slideTutorial3;
    public int hit = 0;
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
        if(Input.GetButtonDown("Horizontal") && hit == 0){
            moveTutorial.color = Color.green;
            jumpText.SetActive(true);
            hit++;
        }
        if(Input.GetButtonDown("Jump") && hit == 1){
            jumpTutorial.color = Color.green;
            slideText.SetActive(true);
            hit++;
        }
        if(hit == 2 && GameObject.FindWithTag("Player").GetComponent<MoveTutorial>().animator.GetCurrentAnimatorStateInfo(0).IsName("SLide")){
            slideTutorial.color = Color.green;
            hit++;
        }
        if(slideTutorial.color == Color.green && jumpTutorial.color == Color.green && moveTutorial.color == Color.green && hit == 3){
            Invoke("NextTutorial", 2.5f);
            Invoke("DestroyFirstTutorial", 2f);
            hit++;
        }


    }
    void DestroyFirstTutorial(){
        jumpText.SetActive(false);
        slideText.SetActive(false);
        gameObject.SetActive(false);
    }

    void NextTutorial(){
        nextTutorial.SetActive(true);
    }
    
}
