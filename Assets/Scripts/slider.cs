using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slider : MonoBehaviour
{
    public Vector3 pos1;
    public Vector3 pos2;
    public float speed;

    void FixedUpdate()
    {
        gameObject.GetComponent<Transform>().localPosition = Vector3.Lerp(pos1, pos2,Mathf.PingPong(Time.deltaTime*speed,1f));
    }
}
