using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType
{
    EnemyBullet,
    PlayerBullet
}

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 40;
    [SerializeField] private int rotate = 0;

    private BulletType type;
    private float speed;

    //TODO: -
    //    [SerializeField] private GameObject collisionParticle;
    public int GetDamage { get { return damage; } }

    public void Config(BulletType bulletType, float velocity)
    {
        type = bulletType;

        if (type == BulletType.EnemyBullet)
            speed = -velocity;
        else
            speed = velocity;

        gameObject.tag = type.ToString();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        if (rotate > 0)
        {
            gameObject.transform.Rotate(0f, 0f, rotate * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collisionParticle.SetActive(true);
        Destroy(gameObject);
    }
}
