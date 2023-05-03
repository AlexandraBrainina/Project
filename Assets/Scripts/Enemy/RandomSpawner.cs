using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class RandomSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject sunflowerPrefab;
        [SerializeField] private GameObject hyacinthPrefab;

        [SerializeField] private float sunflowerTime = 3.5f;
        [SerializeField] private float hyacinthTime = 10f;


        private void Start()
        {
            StartCoroutine(EnemySpawn(sunflowerTime, sunflowerPrefab));
            StartCoroutine(EnemySpawn(hyacinthTime, hyacinthPrefab));
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