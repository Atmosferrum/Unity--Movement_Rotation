using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] runners;
    [SerializeField] GameObject stick;
    [SerializeField] float passDistance = 0.5f;
    [SerializeField] bool forward = true;
    [SerializeField] float speed = 5f;

    float distance;
    int i;

    GameObject currentRunner;
    GameObject nextRunner;

    private void Start()
    {
        currentRunner = runners[0];

        stick.transform.parent = currentRunner.transform;

        if (forward)
            i = 1;
        else
            i = 4;

        nextRunner = runners[i];
    }

    private void Update()
    {
        currentRunner.transform.position = Vector3.MoveTowards(currentRunner.transform.position, nextRunner.transform.position, Time.deltaTime * speed);
        currentRunner.transform.LookAt(nextRunner.transform);

        distance = Vector3.Distance(currentRunner.transform.position, nextRunner.transform.position);

        if(distance <= passDistance)
        {
            if (forward)
            {
                if (i == 4)
                    i = 0;
                else
                    ++i;

                Tag(i);
            }
            else
            {
                if (i == 0)
                    i = 4;
                else
                    --i;

                Tag(i);
            }
        }   
    }

    void Tag(int i)
    {
        currentRunner = nextRunner;
        nextRunner = runners[i];
        stick.transform.parent = currentRunner.transform;
        stick.transform.localPosition = new Vector3(0, 1.5f, 0);
    }
}
