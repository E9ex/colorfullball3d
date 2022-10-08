using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private Vector3 selfPosition;

    [SerializeField] private Transform player;
    
    
    private void Awake()
    {
        selfPosition = transform.position;
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.position = selfPosition + player.position;
    }
}
