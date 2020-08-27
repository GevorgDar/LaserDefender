using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private List<EnemysWave> enemysWaves;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        for (; ; )
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
    }

    IEnumerator SpawnAllWaves()
    {
        for (int i = 0; i < enemysWaves.Count; i++)
        {
            yield return new WaitForSeconds(enemysWaves[i].TimeBeforeWave);
            yield return StartCoroutine(SpawnAllEnemysInSpawn(enemysWaves[i]));
        }
    }

    IEnumerator SpawnAllEnemysInSpawn(EnemysWave enemysWave)
    {
        for (int i = 0; i < enemysWave.NumberOfEnemys; i++)
        {
            GameObject enemy = Instantiate(enemysWave.Enemy, transform.position, Quaternion.identity);
            enemy.GetComponent<Enemy>().Config(enemysWave);

            yield return new WaitForSeconds(enemysWave.TimeBetweenSpawns);
        }
    }
}
