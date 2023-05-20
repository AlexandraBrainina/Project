using UnityEngine;
using System.Collections.Generic;
using System.Collections;


[CreateAssetMenu(menuName = "Enemy Data", fileName = "New Enemy Data")]
public class EnemyData : ScriptableObject

{
    public int enemyHealth;
    public GameObject enemyPrefab;
    public float spawnInterval;
}