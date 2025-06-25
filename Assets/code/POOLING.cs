using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 10;

    private List<GameObject> pool;

    void Awake()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            pool.Add(enemy);
        }
    }

    public GameObject GetEnemy()
    {
        foreach (GameObject enemy in pool)
        {
            if (!enemy.activeInHierarchy)
                return enemy;
        }

        // Optional: tambahkan jika pool habis
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(false);
        pool.Add(newEnemy);
        return newEnemy;
    }
}
