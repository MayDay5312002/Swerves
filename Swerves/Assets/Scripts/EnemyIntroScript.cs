using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIntroScript : MonoBehaviour
{
    AudioSource exploSound;
    Animator animator;
    void Awake(){
        exploSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-10f * Time.deltaTime, 0, 0);
        if(transform.position.x < -50)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){
        animator.SetTrigger("Explode");
        exploSound.Play();
        transform.GetChild(0).gameObject.SetActive(false);
    }
    

    
}
