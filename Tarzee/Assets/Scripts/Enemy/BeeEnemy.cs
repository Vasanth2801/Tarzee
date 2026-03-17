using UnityEngine;

public class BeeEnemy : MonoBehaviour
{
    [Header("Point References")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    Transform currentPoint;
    Vector3 initialScale;
    [SerializeField] private float speed;
    [SerializeField] private float arrivalThreshold = 0.25f;

    void Start()
    {
        currentPoint = pointB;
        initialScale = transform.localScale;
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        Vector3 targetPos = currentPoint.position;
        transform.position = Vector3.MoveTowards(this.transform.position, targetPos, speed);

        if(Vector3.Distance(transform.position, targetPos) <=  arrivalThreshold)
        {
            currentPoint = currentPoint == pointA ? pointB : pointA;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pointA.position, 0.05f);
        Gizmos.DrawWireSphere(pointB.position, 0.05f);
        Gizmos.DrawLine(pointA.position, pointB.position);
    }
}