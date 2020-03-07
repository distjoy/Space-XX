using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBg : MonoBehaviour
{
    // Start is called before the first frame update
    private float _speed = 200;
    public GameObject firstStars, secondStars;
    void Start()
    {


    //   firstStars.transform.position = new Vector3(firstStars.transform.position.x, 765f, firstStars.transform.position.z);
    }

    // Update is called once per frame
    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (firstStars.transform.position.y <= -3400)
        {
            firstStars.transform.position = new Vector3(firstStars.transform.position.x, 4906, firstStars.transform.position.z);
        }
        if (secondStars.transform.position.y <= -3400)
        {
            secondStars.transform.position = new Vector3(secondStars.transform.position.x, 4906, secondStars.transform.position.z);
        }
        firstStars.transform.Translate(Vector3.down * _speed * 1.5f * Time.deltaTime);
        secondStars.transform.Translate(Vector3.down * _speed * 1.5f * Time.deltaTime);
        
    }
}
