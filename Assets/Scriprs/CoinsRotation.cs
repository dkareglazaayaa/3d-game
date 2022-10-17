using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsRotation : MonoBehaviour
{
    private float deltaY;

    // Start is called before the first frame update
    void Start()
    {
        deltaY = Random.Range(-100, 100);
 
    }
    // Update is called once per frame
    void Update()
    {      
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y +=deltaY*Time.deltaTime;  
        transform.rotation = Quaternion.Euler(rotationVector);

    }
}
