using UnityEngine;

public class Waypointer : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] bool isCircular = true;
    [SerializeField] float speed = 1f;
    
    int currentPointId = 0;

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentPointId].transform.position) < .1f)
        {
            bool isLastPoint = currentPointId >= waypoints.Length - 1;
            if (isLastPoint && !isCircular) enabled = false;

            currentPointId = isLastPoint ? 0 : currentPointId + 1;
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentPointId].transform.position, speed * Time.deltaTime);
    }
}