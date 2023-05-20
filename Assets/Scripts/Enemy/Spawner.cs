using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        public EnemyData enemyData;

        private GameObject _prefab;
        private float _interval;

        private void Start()
        {
            _prefab = enemyData.enemyPrefab;
            _interval = enemyData.spawnInterval;
            
            StartCoroutine(EnemySpawn(_interval, _prefab));
        }
        private IEnumerator EnemySpawn(float interval, GameObject enemy)
        {
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemy,
                new Vector3(Random.Range(-55, 55), 0, Random.Range(-55, 55)), Quaternion.identity);
            StartCoroutine(EnemySpawn(interval, enemy));
        }
    }
}