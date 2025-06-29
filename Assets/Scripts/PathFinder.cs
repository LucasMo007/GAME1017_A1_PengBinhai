using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    EnemySpawner enemySpawner;
    [SerializeField]WaveConfigSo waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    
     void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();//FindObjectOfType is used to find the object of the class EnemySpawner in game scene


    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
    }

   
    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
