using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{

    public float forwardspeed;
    void Update()
    {
        if (variables.firsttouch==1)
        {
            transform.position += new Vector3(0, 0, forwardspeed * Time.deltaTime);   

        }
    }
}
