using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject projectile;

    private Queue<GameObject> pooledEnemies = new();
    private Queue<GameObject> pooledProjectiles = new();
    public int enemiesAmount = 50;
    public int projectileAmount = 50;

    void Start()
    {
        for (int i = 0; i < enemiesAmount; i++)
        {
            GameObject enemyObject = Instantiate(enemy);
            enemyObject.SetActive(false);
            pooledEnemies.Enqueue(enemyObject);
        }
        for (int i = 0; i < projectileAmount; i++)
        {
            GameObject projectileObject = Instantiate(projectile);
            projectileObject.SetActive(false);
            pooledProjectiles.Enqueue(projectileObject);
        }
    }

    public GameObject GetEnemy()
    {
        //Take out first enemy
        GameObject currentEnemy = pooledEnemies.Dequeue();
        currentEnemy.SetActive(true);

        // Put him immediately back at the end of the line so he can be recycled again later
        pooledEnemies.Enqueue(currentEnemy);

        return currentEnemy;
    }

    public GameObject GetProjectile()
    {
        //Take out first enemy
        GameObject currentProjectile = pooledProjectiles.Dequeue();
        currentProjectile.SetActive(true);

        // Put him immediately back at the end of the line so he can be recycled again later
        pooledProjectiles.Enqueue(currentProjectile);

        return currentProjectile;
    }
}
