using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBehavior : MonoBehaviour
{
    public Vector3 startScale;
    public Vector3 endScale;

    public float  Scale_Time = 10.0f;
    private float timer=0;

    private bool isStartScale = false;


    private float deltaY;
    // Start is called before the first frame update
    void Start()
    {
        
        deltaY = Random.Range(-110, 110);
        transform.localScale = startScale;
        isStartScale = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer++;
        if (timer == Scale_Time)
        {
            if (isStartScale)
            {
                transform.localScale = endScale;
                isStartScale = false;
            }
            else if(!isStartScale)
            {
                transform.localScale = startScale;        
                isStartScale = true;
            }
            timer = 0;
        }
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y += deltaY* Time.deltaTime;
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
