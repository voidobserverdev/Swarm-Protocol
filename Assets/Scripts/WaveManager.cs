using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private ObjectPool pool; // Drag your ObjectPool here in the Inspector
    public float spawnRate = 1.5f;
    private float timer = 0f;
    public float spawnRadius = 25f; // How far away they spawn

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            // 1. Ask the pool for an enemy
            GameObject newEnemy = pool.GetEnemy();

            // 2. If the pool gave us an enemy (meaning it wasn't empty)
            if (newEnemy != null)
            {
                // 3. Pick a random 2D point on a circle, convert it to 3D, and place the enemy there
                Vector2 randomPoint = Random.insideUnitCircle.normalized * spawnRadius;
                newEnemy.transform.position = new Vector3(randomPoint.x, 0, randomPoint.y);
            }

            timer = 0f; // Reset the clock
        }
    }
}