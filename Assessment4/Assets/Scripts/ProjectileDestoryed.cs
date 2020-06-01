using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestoryed : MonoBehaviour
{
    public Transform endPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform + " and " + endPosition);
        if (transform.position == endPosition.position)
        {
            // Debug.Log("Projectile get destroyed");
            // var clones = GameObject.FindGameObjectsWithTag ("clone"); 
            // foreach (var clone in clones){ Destroy(clone); }
            
        }
        
    }
}
