using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    private Animator animator;
    public AnimationClip run;
    public AnimationClip stand;
    public AnimationClip walk;
    public AnimationClip jump;
    public AnimationClip fall;
    //public AnimationClip win;


    public float WalkSpeed = 2.0f;
    public float RunSpeed = 5.0f;

    //private Rigidbody rb;
    //private CharacterController controller;
    void Start()
    {
        animator = GetComponent<Animator>();
  

        //rb = GetComponent<Rigidbody>();
        // CharacterController controller = GetComponent<CharacterController>();
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            animator.Play(walk.name);
          
            float deltaX = Input.GetAxis("Horizontal") * WalkSpeed* Time.deltaTime;
            float deltaZ = Input.GetAxis("Vertical") * WalkSpeed* Time.deltaTime;
            transform.Translate(deltaX, 0, deltaZ);

        }
        if (Input.GetKey(KeyCode.Space))
        {
            animator.Play(jump.name);
        

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.Play(run.name);

            float deltaZ = RunSpeed * Time.deltaTime;
            transform.Translate(0, 0, deltaZ);
  
        }

    }
  

}


