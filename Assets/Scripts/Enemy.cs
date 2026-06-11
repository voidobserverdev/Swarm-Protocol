using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, moveSpeed * Time.deltaTime);
    }
}
