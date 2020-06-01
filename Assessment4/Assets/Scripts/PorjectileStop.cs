using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorjectileStop : MonoBehaviour
{
    public Transform endPosition;
    bool finished;
    void Start()
    {
        finished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == endPosition.position)
        {
            finished = true;
        }

        if (finished)
        {
           transform.position = Vector3.zero;
        }
    }
}
