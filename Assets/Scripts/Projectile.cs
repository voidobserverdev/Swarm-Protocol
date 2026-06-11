using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lifeTime = 3f;

    void Update()
    {
        transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
