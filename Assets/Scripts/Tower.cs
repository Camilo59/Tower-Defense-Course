using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform towerHead;
    public Transform enemy;

    public List<Transform> enemyList;

    [Header("Attack Details")]
    public float attackRange = 3;
    public float attackCooldown;
    private float lastTimeAttacked;

    [Header("Bullet Details")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 3f;


    void Update()
    {
        if (enemy == null)
        {
            FindRandomEnemy();
            return;
        }

        if (Vector3.Distance(enemy.position, transform.position) <= attackRange)
        {
            towerHead.LookAt(enemy);

            if (ReadyToAttack())
            {
                CreateBullet();
            }
        }

    }

    private void FindRandomEnemy()
    {
        if (enemyList.Count <= 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, enemyList.Count);
        enemy = enemyList[randomIndex];
        enemyList.RemoveAt(randomIndex);
    }

    private void CreateBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, towerHead.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody>().linearVelocity = enemy.position - towerHead.position;
    }

    private bool ReadyToAttack()
    {
        if (Time.time > lastTimeAttacked + attackCooldown)
        {
            lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
