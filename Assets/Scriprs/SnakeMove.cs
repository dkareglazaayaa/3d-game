using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnakeMove : MonoBehaviour
{
    public float snakeSpeed = 0.04f;
    //private Rigidbody rb;

    private Animator animator;
    public AnimationClip snakeX;
    public AnimationClip snake_X;
    public AnimationClip snake_Z;
    public AnimationClip snakeZ;

    private bool Xpos = false;
    private bool Xneg = false;
    private bool Zpos = false;
    private bool Zneg = false;

    private float offset;
    private int time = 0;
    public float obstacleRange = 5.0f;

    private float minX;
    private float maxX;
    private float minZ;
    private float maxZ;
    // Start is called before the first frame update
    void Start()
    { 
        GameObject obj = GameObject.Find("Land");
        var collider =obj.GetComponent<Collider>();
        //Edit, thanks to Arttu's comment!
        minX =  -collider.bounds.size.x;
        maxX =  collider.bounds.size.x;

        minZ = -collider.bounds.size.z;
        maxZ =  collider.bounds.size.z;
        
        Debug.Log(minX);
        Debug.Log(maxX);

        Debug.Log(minZ);
        Debug.Log(maxZ);

        offset = snakeSpeed * Time.deltaTime;
       // rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int way = 0;
        time++;
        if (Xpos == false && Xneg == false && Zpos == false && Zneg == false)
        {
            way = Random.Range(1, 5);
            time = 0;
        }
        else if (time == 400)
        {
            way = Random.Range(1, 5);
            time = 0;
            Xpos = false;
            Xneg = false;
            Zpos = false;
            Zneg = false;
     
        }

        if (transform.position.x > maxX)
        {
            time = 0;
            way = 0;
            Xpos = false;
            XnegRotate();
        }
        if (transform.position.x < minX)
        {
            time = 0;
            way = 0;
            Xneg = false;
            XposRotate();
        }
        if (transform.position.z > maxZ)
        {
            time = 0;
            way = 0;
            Zpos = false;
            ZnegRotate();
        }
        if (transform.position.z < minZ)
        {
            time = 0;
            way = 0;
            Zneg = false;
            ZposRotate();
        }
        
        switch (way)
        {
            case 1: // -Z
                Xpos = true;
                break;
            case 2:
                Zpos = true; ;// Z
                break;
            case 3: // X
                Xneg = true;
                break;
            case 4: // -X
                Zneg = true;
                break;
            default:
                Debug.Log("def");
                break;
        }
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray,0.75f,out hit))
        {
            
            if (hit.collider.CompareTag("Object"))
            {

                if (hit.distance < obstacleRange)
                {
                    if (Xpos == true)
                    {
                        Xpos = false;
                        XnegRotate(); 

                    }
                    if (Xneg == true)
                    {
                        Xneg = false;
                        XposRotate();

                    }
                    if (Zpos == true)
                    {
                        Zpos = false;
                        ZnegRotate();

                    }
                    if (Zneg == true)
                    {
                        Zneg = false;
                        ZposRotate();
                    }
                }
            }
        }
        if (Xpos == true)
        {
            XposRotate();
        }
        if (Zpos == true)
        {
            ZposRotate();
        }
        if (Zneg == true)
        {
            ZnegRotate();
        }
        if (Xneg == true)
        {
            XnegRotate();
        }
    }
    public void ZnegRotate()
    {
        animator.Play(snake_Z.name);
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = 180;
        transform.rotation = Quaternion.Euler(rotationVector);
        transform.Translate(0, 0, -offset, Space.World);
    }
    public void ZposRotate()
    {
        animator.Play(snakeZ.name);
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = 0;
        transform.rotation = Quaternion.Euler(rotationVector);
        transform.Translate(0, 0, offset, Space.World);
    }
    public void XposRotate()
    {
        animator.Play(snakeX.name);
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = 90;
        transform.rotation = Quaternion.Euler(rotationVector);
        transform.Translate(offset, 0, 0, Space.World);
    }
    public void XnegRotate()
    {
        animator.Play(snake_X.name);
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = 270;
        transform.rotation = Quaternion.Euler(rotationVector);
        transform.Translate(-offset, 0, 0, Space.World);
    }
}
