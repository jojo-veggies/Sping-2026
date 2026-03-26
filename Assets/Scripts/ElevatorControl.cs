using System.Collections;
using Unity.Collections;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    //An array with two points- the two that the elevator will move between.
    [SerializeField] private GameObject[] movePoints;
    //How fast the elevator will move.
    [SerializeField] private float speed;
    //Where the array currently is.
    private int currentIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //If the elevator currently hasn't reached a point, keeps going. If it has, moves forward or resets the array,
        //then flips the way it moves.
        if (Vector3.Distance(transform.position, movePoints[currentIndex].transform.position) < 0.1f)
        {
            currentIndex++;
            //resets the array once it goes through everything
            if (currentIndex >= movePoints.Length) { currentIndex = 0; }
            

        }
        //Moves the elevator to the point it needs to.
        transform.position = Vector3.MoveTowards(transform.position, movePoints[currentIndex].transform.position,
            speed * Time.deltaTime);
    }

    
}
