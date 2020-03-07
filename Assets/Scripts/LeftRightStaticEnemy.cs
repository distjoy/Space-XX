using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightStaticEnemy : MonoBehaviour
{


    //world is flipped
    Vector3 direction = Vector3.right;

    private float _speed = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (transform.position.x < 249f)
            direction = Vector3.right;
        if (transform.position.x > 1224f)
            direction = Vector3.left; 
        transform.Translate(direction * _speed * 1.5f * Time.deltaTime);
    }

}
