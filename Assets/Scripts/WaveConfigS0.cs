using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveConfig", fileName = "NewWaveConfig")]
public class WaveConfigS0 : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed;
    [SerializeField]List<GameObject> enemyPrefabs;

    [SerializeField]float timeBetweenEnemySpawns=1f;
    [SerializeField]float spawnTimeVariance=0f;
    [SerializeField]float minimumSpawnTime=0.2f;


    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }
    public GameObject GetEnemyPrefabs(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float spawnTime=Random.Range(timeBetweenEnemySpawns-spawnTimeVariance,timeBetweenEnemySpawns+spawnTimeVariance);
        return Mathf.Clamp(spawnTime,minimumSpawnTime,float.MaxValue);
    }
}
