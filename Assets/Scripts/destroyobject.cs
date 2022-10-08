using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyobject : MonoBehaviour
{
    public void OnCollisionEnter(Collision hit)
    {

        if (hit.gameObject.CompareTag("Untagged")|| hit.gameObject.CompareTag("obstacles1"))
        {
            hit.gameObject.SetActive(false);
        }
    }
}
