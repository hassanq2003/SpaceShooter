using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    WaveConfigS0 waveConfigS0;
    EnemySpawner enemySpawner;
    List<Transform> wayPoints;
    int wayPointindex = -1;

    void Awake()
    {
        enemySpawner=FindObjectOfType<EnemySpawner>();
    }

    // Start is called before the first frame update
    void Start()

    {   waveConfigS0=enemySpawner.returnCurrentWave();
        wayPoints = waveConfigS0.GetWayPoints();
        if (wayPoints.Count > 0)
        {
            wayPointindex = 0;
            transform.position = wayPoints[wayPointindex].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (wayPointindex < wayPoints.Count)
        {
            Vector3 targetPosition = wayPoints[wayPointindex].position;
            float delta = waveConfigS0.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                wayPointindex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
