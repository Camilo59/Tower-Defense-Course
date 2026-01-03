using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform towerHead;
    public Transform enemy;


    [Header("Attack Details")]
    public float attackRange = 3;
    public float attackCooldown;
    public float lastTimeAttacked;

    [Header("Bullet Details")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 3f;


    void Update()
    {

        if (Time.time > lastTimeAttacked + attackCooldown)
        {
            CreateBullet();
            lastTimeAttacked = Time.time;
        }



        if (enemy != null)
        {
            if (Vector3.Distance(enemy.position, transform.position) <= attackRange)
            {
                towerHead.LookAt(enemy);
            }
        }

    }

    private void CreateBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, towerHead.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().linearVelocity = enemy.position - towerHead.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
