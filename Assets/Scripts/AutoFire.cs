using UnityEngine;

public class AutoFire : MonoBehaviour
{
    public float detectionRange = 10f; 
    public float fireRate = 1f; 
    public Transform firePoint; 
    public GameObject bulletPrefab; 

    private float nextTimeToFire = 0f;
    private GameObject nearestEnemy;

    void Update()
    {

        nearestEnemy = FindNearestEnemy();

        if (nearestEnemy != null)
        {

            Vector2 direction = nearestEnemy.transform.position - transform.position;

            if (direction.x > 0) 
            {
                transform.localScale = new Vector3(1, 1, 1); 
            }
            else if (direction.x < 0) 
            {
                transform.localScale = new Vector3(-1, 1, 1); 
            }

           
            if (Time.time >= nextTimeToFire)
            {
                Shoot(direction.normalized); 
                nextTimeToFire = Time.time + 1f / fireRate;
            }
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= detectionRange)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        return nearestEnemy;
    }

    void Shoot(Vector2 direction)
    {
       
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        BulletMove bulletScript = bullet.GetComponent<BulletMove>();
        bulletScript.SetDirection(direction);
    }
}
