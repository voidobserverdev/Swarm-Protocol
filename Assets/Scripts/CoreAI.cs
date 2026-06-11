using UnityEngine;

public class CoreAI : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private Transform firePoint;

    public WeaponData currentWeapon;
    private float attackTimer;

    public enum CoreState
    {
        Idle,
        Tracking,
        Firing
    }

    public CoreState currentState;

    void Update()
    {
        switch (currentState)
        {
            case CoreState.Idle:
                SearchForTarget();
                break;
            case CoreState.Tracking:
                AimAtTarget();
                break;
            case CoreState.Firing:
                ExecuteAttack();
                break;
        }
    }

    void SearchForTarget()
    {
        // 1. Draw an invisible radar bubble using the current weapon's range
        Collider[] hits = Physics.OverlapSphere(transform.position, currentWeapon.weaponRange);

        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        // 2. Loop through every single object the bubble touched
        foreach (Collider hit in hits)
        {
            // 3. Only care about objects tagged "Enemy"
            if (hit.CompareTag("Enemy"))
            {
                // 4. Calculate if this enemy is closer than the last one we checked
                float distanceToEnemy = Vector3.Distance(transform.position, hit.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = hit.gameObject;
                }
            }
        }

        // 5. If our loop found a valid enemy, lock on and start Tracking!
        if (closestEnemy != null)
        {
            target = closestEnemy;
            currentState = CoreState.Tracking;
        }
    }

    void AimAtTarget()
    {
        transform.LookAt(target.transform);
        currentState = CoreState.Firing;
    }

    void ExecuteAttack()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            GameObject currentProjectile = objectPool.GetProjectile();
            currentProjectile.transform.position = firePoint.transform.position;
            currentProjectile.transform.rotation = firePoint.transform.rotation;

            currentProjectile.GetComponent<Renderer>().material.color = currentWeapon.projectileColor;

            attackTimer = currentWeapon.fireRate;
        }

        if (!target.activeInHierarchy)
        {
            currentState = CoreState.Idle;
        }
    }
}
