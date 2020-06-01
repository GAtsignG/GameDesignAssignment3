using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIMovement : MonoBehaviour
{
    public Transform[] waypoints;    
    int way = 0;
    public float speed = 0.05f;
    int moveToIndex = 0;
    int randIndex;
    bool finished;

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
        finished = false;
    }
    void Update()
    {

            if (moveToIndex < waypoints.Length)
           {
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
           }

           if (moveToIndex == waypoints.Length)
           {
            moveToIndex = 0; //loop
           }
        
    }

    
       void OnTriggerEnter2D(Collider2D c)
    {
        if (c.name == "MalePlayer")
        {
            //Destroy(c.gameObject);
            //Instantiate(explosion,transform.position,transform.rotation);
            //Destroy(gameObject);
            SceneManager.LoadSceneAsync(2);
        }

    }
}
