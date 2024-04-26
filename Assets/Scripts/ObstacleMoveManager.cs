using System.Collections;
using UnityEngine;

public class ObstacleMoveManager : MonoBehaviour
{
    [SerializeField] float objectSpeed;
    Vector3 targetPos;

    [SerializeField] GameObject ways;
    [SerializeField] Transform[] wayPoints;

    int pointIndex, pointCount, speedMultiplier=1, direction = 1;

    [SerializeField] int waitDuration;


    private void Awake()
    {        
        wayPoints= new Transform[ways.transform.childCount];
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }

    private void Start()
    {
        pointCount=wayPoints.Length;
        pointIndex = 1;
        targetPos= wayPoints[pointIndex].transform.position;

    }

    private void Update()
    {
        var step=speedMultiplier*objectSpeed*Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        if (transform.position==targetPos)
        {
            NextPoint();
        }
    }

    void NextPoint()
    {
        if (pointIndex==pointCount-1)
        {
            direction = -1;
        }
        if (pointIndex == 0)
        {
            direction = 1;
        }

        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
        StartCoroutine(WaitForNextPoint());
    }

    IEnumerator WaitForNextPoint()
    {
        speedMultiplier = 0;
        yield return new WaitForSeconds(waitDuration);
        speedMultiplier = 1;
    }


}
