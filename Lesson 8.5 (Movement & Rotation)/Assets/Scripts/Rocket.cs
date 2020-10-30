using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] bool canGo = true;
    [SerializeField] float speed = 10;
    [SerializeField] Transform[] checkpoints;
    [SerializeField] Transform currentCheckpoint;

    int i = 0;
    
    void Update()
    {
        
        transform.Rotate(0, 0, 2);

        if (canGo)
        {
            transform.position = Vector3.MoveTowards(transform.position, checkpoint(), speed * Time.deltaTime);

                            
        }
    }

    Vector3 checkpoint()
    {
        

        if (transform.position == currentCheckpoint.transform.position)
        {
            
            if (i == 3)
                i = 0;
            else
                ++i;

            currentCheckpoint = checkpoints[i];
            transform.LookAt(currentCheckpoint);
            return checkpoints[i].transform.position;
        }
            

        return currentCheckpoint.transform.position;
    }


}
