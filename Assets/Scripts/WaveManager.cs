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
            GameObject newEnemy = pool.GetEnemy();

            if (newEnemy != null)
            {
                Vector2 randomPoint = Random.insideUnitCircle.normalized * spawnRadius;
                newEnemy.transform.position = new Vector3(randomPoint.x, 0, randomPoint.y);
            }

            timer = 0f;
        }
    }
}