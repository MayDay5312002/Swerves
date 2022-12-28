using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Move mover;
    public Animator animator;
    Material material;
    public bool canMove = true;
    Material[] materials = new Material[3];
    public float xInput;
    public int numJump = 0;
    [SerializeField] AudioSource walkSound;
    [SerializeField] AudioSource landSound;

    

    void Awake(){
        if(mover == null){
            mover = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        material = GameObject.Find("Quad").GetComponent<Renderer>().material;
        materials[0] = GameObject.Find("Quad1").GetComponent<Renderer>().material;
        materials[1] = GameObject.Find("Quad2").GetComponent<Renderer>().material;
        materials[2] = GameObject.Find("Quad3").GetComponent<Renderer>().material;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            xInput = Input.GetAxisRaw("Horizontal");
            if(xInput > 0){
                animator.SetBool("Idle", false);
                animator.SetBool("Run", true);
                transform.localScale = new Vector3(1, 1,0);
            }
            if(xInput < 0){
                animator.SetBool("Idle", false);
                animator.SetBool("Run", true);
                transform.localScale = new Vector3(-1, 1, 0);
            }
            if(xInput == 0){
                animator.SetBool("Idle", true);
                animator.SetBool("Run", false);
            }
            if(Input.GetButtonDown("Jump") && numJump < 2){
                animator.SetTrigger("Jump");
                if( numJump != 0){
                    if(GetComponent<Rigidbody2D>().velocity.y < 0){
                        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
                    }
                    else{
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 150f));
                    }
                }
                else{
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 450f));
                }
                numJump++;
            }
            if((Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) && animator.GetBool("Airborned") == false && xInput != 0){
                animator.SetTrigger("Slide");

                
            }
            material.mainTextureOffset += new Vector2(xInput * 4 * Time.deltaTime, 0);
            materials[0].mainTextureOffset += new Vector2(xInput * 8 * Time.deltaTime, 0);
            materials[1].mainTextureOffset += new Vector2(xInput * 8 * Time.deltaTime, 0);
            materials[2].mainTextureOffset += new Vector2(xInput * 8 * Time.deltaTime, 0);
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("SLide") && xInput == 0){//checks if the current state animation which is named in /.IsName("NAME")/ is playing
                Invoke("SlideCancel", 0.2f);
                
            }

        }
        
    }
    void OnCollisionEnter2D(Collision2D col){
        animator.SetBool("Airborned", false);
        numJump = 0;
        landSound.Play();
    }
    void OnCollisionExit2D(Collision2D col){
        animator.SetBool("Airborned", true);
    }
    public void DeathAnim(){
        animator.SetTrigger("Death");
        
    }

    void SlideCancel(){
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("SLide") && xInput == 0)//checks if the current state animation which is named in /.IsName("NAME")/ is playing
            animator.SetTrigger("idled");
    }

    public void WalkingSound(){
        walkSound.Play();
    }
    
}
