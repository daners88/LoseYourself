﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> obstacleSpots;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Spheres temp = other.GetComponent<Spheres>();

        if(temp != null)
        {

        }
    }
}
