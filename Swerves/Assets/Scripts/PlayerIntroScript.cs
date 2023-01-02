using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIntroScript : MonoBehaviour
{
    AudioSource walkSound;
    // Start is called before the first frame update
    void Start()
    {
        walkSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-5f * Time.deltaTime, 0, 0);
        if(transform.position.x < -14f)
        Destroy(gameObject);
        
    }

    public void PlaySound(){
        walkSound.Play();
    }

    
}
