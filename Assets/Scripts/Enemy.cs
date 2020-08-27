using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed = 5;
    [SerializeField] private float attackRate = 5;
    [SerializeField] private int HP = 100;

    private List<Vector3> waypointChildsPosition;
    private bool configureIsSet = false;
    private int waypointIndex = 0;
    private float speed;

    // Update is called once per frame
    void Update()
    {
        if (configureIsSet)
        {
            Move();
        }
    }

    public void Config(EnemysWave enemysWave)
    {
        speed = enemysWave.EnemySpeed;
        waypointChildsPosition = enemysWave.Waypoint.GetChildsPosition(enemysWave.Distance, enemysWave.Direction);
        gameObject.transform.position = waypointChildsPosition[waypointIndex];
        waypointIndex++;
        configureIsSet = true;

        StartCoroutine(Attack());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == BulletType.PlayerBullet.ToString())
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();

            if (bullet == null)
                Debug.LogError("Bullet haven't Component - 'Bullet'");

            Damaged(bullet.GetDamage);
        }
    }

    private void Damaged(int damag)
    {
        HP -= damag;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (waypointIndex < waypointChildsPosition.Count)
        {
            Vector3 newPosition = waypointChildsPosition[waypointIndex];
            float speedThisFrame = speed * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position,
                                                     newPosition,
                                                     speedThisFrame);
            if (transform.position == newPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(0f, 1f));

        for (; ; )
        {
            GameObject newBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            // TODO: -
            newBullet.GetComponent<Bullet>().Config(BulletType.EnemyBullet, bulletSpeed);

            yield return new WaitForSeconds(10/Random.Range(attackRate/2, attackRate));
        }
    }
}
