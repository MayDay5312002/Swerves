using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public static Explosion explosioner;
    public AudioSource exploSound;
    void Awake(){
        if(explosioner == null)
            explosioner = this;
        exploSound = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Explode()
    {
        exploSound.Play();
    }
}
