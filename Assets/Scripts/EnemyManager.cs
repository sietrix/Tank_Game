using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] GameObject tankEnemyPrefab;
    [SerializeField] float time; // numero de veces que llamaremos al invokerepeating

    void Start()
    {
        InvokeRepeating("CreateTankEnemy", time, time);
    }

   void CreateTankEnemy()
    {
        int n = Random.Range(0, positions.Length); // coloco los tanques en posiciones aleatorias
        Instantiate(tankEnemyPrefab, positions[n].position, positions[n].rotation);
    }
}
