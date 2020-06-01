using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform[] waypoints;    
    int way = 0;
    public float speed = 0.05f;
    int moveToIndex = 0;
    int randIndex;
<<<<<<< Updated upstream
=======
    bool finished;
>>>>>>> Stashed changes

    private void eMove(int index)
    {
        Vector3 newPos = Vector3.MoveTowards(gameObject.transform.position,
                waypoints[index].position,
                speed * Time.deltaTime);
        gameObject.transform.position = newPos; //move

        if (newPos == waypoints[moveToIndex].position)
        {
            moveToIndex++; //next way
        }
    }
    void Start()
    {
        randIndex = Random.Range(0, waypoints.Length);
<<<<<<< Updated upstream
    }
    void Update()
    {
        if (moveToIndex < waypoints.Length)
        {
=======
        finished = false;
    }
    void Update()
    {

            if (moveToIndex < waypoints.Length)
           {
>>>>>>> Stashed changes
            if (gameObject.name == "Mr.GreenMovement_0" &&
                gameObject.transform.position == waypoints[randIndex].transform.position)
            {
                randIndex = Random.Range(0, waypoints.Length);
            }
            if (gameObject.name == "Mr.GreenMovement_0")
            {    
                eMove(randIndex); //random move
            }
            else
            eMove(moveToIndex);          
<<<<<<< Updated upstream
        }

        if (moveToIndex == waypoints.Length)
        {
            moveToIndex = 0; //loop
        }
=======
           }

           if (moveToIndex == waypoints.Length)
           {
            moveToIndex = 0; //loop
           }
        
>>>>>>> Stashed changes
    }

    
    // void OnTriggerEnter2D(Collider2D c)
    // {
    //     if (c.name == "MalePlayer")
    //     {
    //         Destroy(c.gameObject);
    //         SceneManager.LoadSceneAsync(2);
    //     }

    // }
}
