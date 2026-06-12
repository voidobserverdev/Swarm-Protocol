using UnityEngine;

public class CoreAI : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private Transform firePoint;

    public WeaponData currentWeapon;
    private float timer = 0f;

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
        Collider[] hits = Physics.OverlapSphere(transform.position, currentWeapon.weaponRange);

        float closestDistance = 1000f;
        GameObject closestEnemy = null;

        //Loop through every single object the bubble touched
        foreach (Collider hit in hits)
        {
            if (hit.gameObject.CompareTag("Enemy"))
            {
                // Get the closest enemy
                float distanceToEnemy = Vector3.Distance(transform.position, hit.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = hit.gameObject;
                }
            }
        }

        //Change state to Tracking after finding closest enemy
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
        timer += Time.deltaTime;
        if (timer >= currentWeapon.fireRate)
        {
            GameObject currentProjectile = objectPool.GetProjectile();
            currentProjectile.transform.SetPositionAndRotation(firePoint.transform.position, firePoint.transform.rotation);
            currentProjectile.GetComponent<Renderer>().material.color = currentWeapon.projectileColor;

            timer = 0f;
        }

        if (!target.activeInHierarchy)
        {
            currentState = CoreState.Idle;
        }
    }
}
