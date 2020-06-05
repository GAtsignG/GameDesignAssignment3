using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandToTrigger : MonoBehaviour
{
    public GameObject boxA;
    public GameObject boxB;

    public GameObject triA;
    public GameObject triB;

    bool aStand;
    bool bStand;
    int mode;
    // Start is called before the first frame update
    void Start()
    {
        mode = 0;
        aStand = false;
        bStand = false;
    }

    // Update is called once per frame
    void Update()
    {
         Debug.Log("Trigger A" + aStand + " Trigger B " + bStand);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (gameObject.name == "BoxTrigger1" && c.name == "MalePlayer")
        {
            aStand = true;         
            if (mode == 2)
            {
                boxA.GetComponent<Rigidbody2D>().gravityScale = 1;
                Debug.Log("Drop a");
                bStand = false;
                triA.GetComponent<StandToTrigger>().mode = 0;
            }
            if (!bStand)
            {
                triB.GetComponent<StandToTrigger>().mode = 1;
                //first red light                
            }                            
        }

        if (gameObject.name == "BoxTrigger2" && c.name == "MalePlayer")
        {

            bStand = true;
            if (mode == 1)
            {
                boxB.GetComponent<Rigidbody2D>().gravityScale = 1;
                Debug.Log("Drop b");
                aStand = false;
                triB.GetComponent<StandToTrigger>().mode = 0;
            }
            if (!aStand)
            {
                triA.GetComponent<StandToTrigger>().mode = 2; //first yellow light     
            }
            

        }

    }
}
