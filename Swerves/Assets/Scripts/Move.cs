using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Move mover;
    public Move move;
    public Animator animator;
    Material material;
    public bool canMove = true;
    Material[] materials = new Material[3];
    public float xInput;
    public int numJump = 0;

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
        
        if(move == null){
            move = this;
        }
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
                if(GetComponent<Rigidbody2D>().velocity.y < 0)
                    GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 310f));
                numJump++;
            }
            if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)){
                animator.SetTrigger("Slide");
            }
            material.mainTextureOffset += new Vector2(xInput * 4 * Time.deltaTime, 0);
            materials[0].mainTextureOffset += new Vector2(xInput * 8 * Time.deltaTime, 0);
            materials[1].mainTextureOffset += new Vector2(xInput * 8 * Time.deltaTime, 0);
            materials[2].mainTextureOffset += new Vector2(xInput * 8 * Time.deltaTime, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D col){
        animator.SetBool("Airborned", false);
        numJump = 0;
    }
    void OnCollisionExit2D(Collision2D col){
        animator.SetBool("Airborned", true);
    }
}
