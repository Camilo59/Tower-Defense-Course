using UnityEngine;
using UnityEngine.InputSystem;

public class Tower : MonoBehaviour
{
    public Transform towerHead;
    public Transform enemy;

    public float attackRange = 3;
    public GameObject bulletPrefab;
    public float bulletSpeed = 3f;

    
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            GameObject newBullet = Instantiate(bulletPrefab, towerHead.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().linearVelocity = enemy.position - towerHead.position;
        }
        if (Vector3.Distance(enemy.position, transform.position) <= attackRange)
        {
            towerHead.LookAt(enemy);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
