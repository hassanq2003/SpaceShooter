using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WaveConfigS0 currentwave;
    bool isLooping=true;
    [SerializeField]List<WaveConfigS0> waveConfigS0;
    [SerializeField]float TimebetweenWaves=0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public WaveConfigS0 returnCurrentWave()
    {
        return currentwave;
    }
    IEnumerator SpawnEnemiesWaves()
    {   do{
        foreach(WaveConfigS0 waves in waveConfigS0)
        {   currentwave=waves;
            for(int i=0;i<currentwave.GetEnemyCount();++i)
                {
                Instantiate(currentwave.GetEnemyPrefabs(i),currentwave.GetStartingWayPoint().position,Quaternion.identity,transform);
                yield return new WaitForSeconds(currentwave.GetRandomSpawnTime());
                }
            yield return new WaitForSeconds(TimebetweenWaves);
        }
        }while(isLooping);
    }

}
