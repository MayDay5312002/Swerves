using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Move move;
    public Animator animator;
    Material material;
    Material[] materials = new Material[2];

    public int numJump = 0;
    // Start is called before the first frame update
    void Start()
    {
        material = GameObject.Find("Quad").GetComponent<Renderer>().material;
        materials[0] = GameObject.Find("Quad1").GetComponent<Renderer>().material;
        materials[1] = GameObject.Find("Quad2").GetComponent<Renderer>().material;
        if(move == null){
            move = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
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
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300f));
            numJump++;
        }
        if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)){
            animator.SetTrigger("Slide");
        }
        material.mainTextureOffset += new Vector2(xInput * 4 * Time.deltaTime, 0);
        materials[0].mainTextureOffset += new Vector2(xInput * 8 * Time.deltaTime, 0);
        materials[1].mainTextureOffset += new Vector2(xInput * 8 * Time.deltaTime, 0);
    }
    void OnCollisionEnter2D(Collision2D col){
        animator.SetBool("Airborned", false);
        numJump = 0;
    }
    void OnCollisionExit2D(Collision2D col){
        animator.SetBool("Airborned", true);
    }
}
