using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    public Vector3 target;
    private int waypointIndex = 0;

    [SerializeField] private Enemy enemy;
    public GameManager manager;
    public GameObject obj;
    public Vector3 offset;
    float minRandom = -1f;
    float maxRandom = 1f;
    Vector3 dir;
    float posOffset;


    private void Start()
    {
        enemy = GetComponent<Enemy>();
        //emy = GetComponentInParent<Enemy>()
        target = Waypoints.points[0];
        manager = FindObjectOfType<GameManager>();
        //When u spawn the enmy carry the offset instead of random
        offset = new Vector3((Random.Range(-minRandom, -maxRandom)), 0f, 0f);
        posOffset = Random.Range(-minRandom, -maxRandom);
        transform.GetChild(0).localPosition = new Vector3(posOffset, 0f, 0f);
        
    }

    private void Update()
    {
        dir = target - transform.position;
        //transform.LookAt(target);
        Vector3 lookDirection = target - transform.position;
        lookDirection.Normalize();

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 3.5f * Time.deltaTime);
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        

        if (Vector3.Distance(transform.position, target) <= 0.1f)
        {
            GetNextWaypoint();
        }

        
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.points[waypointIndex];
        //target = new Vector3(Waypoints.points[waypointIndex].x + offset.x, Waypoints.points[waypointIndex].y, Waypoints.points[waypointIndex].z);
        
        
      

        /*
        float check = target.x;
        float random = (Random.Range(minRandom, maxRandom));

        //offset = new Vector3((Random.Range(minRandom, maxRandom)), 0f, 0f);
        offset = new Vector3((Random.Range(minRandom, maxRandom)), 0f, 0f);

        if(random + target.x > check)
        {
            offset = new Vector3((Random.Range(-minRandom, -maxRandom)), 0f, 0f);
            target += offset;
        }

        else if (random + target.x < check)
        {
            offset = new Vector3((Random.Range(minRandom, maxRandom)), 0f, 0f);
            target += offset;
        }
        */
    }

    void EndPath()
    {
        manager.HeartAnim();
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(target, 2f);
        
    }
}
