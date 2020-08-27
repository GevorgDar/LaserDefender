using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Range(1,5)]
    [SerializeField] private int playerHP = 3;
    [SerializeField] private int speed;
    [SerializeField] private float fireRate;
    [SerializeField] private int bulletSpeed;
    [SerializeField] private GameObject bullet;

    private Coroutine fireContinuously;
    private Camera mainCamera;
    private float xMin;
    private float yMin;
    private float xMax;
    private float yMax;

    public int PlayerHP { get { return playerHP; } }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        xMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        yMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        xMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMax = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireContinuously = StartCoroutine(FireContinuously());
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopCoroutine(fireContinuously);
        }
    }

    private void Move()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        float x = Mathf.Clamp(gameObject.transform.position.x + deltaX, xMin + 0.5f, xMax - 0.5f);
        float y = Mathf.Clamp(gameObject.transform.position.y + deltaY, yMin + 0.5f, yMax - 0.5f);

        gameObject.transform.position = new Vector2(x, y);
    }

    IEnumerator FireContinuously()
    {
        for (; ; )
        {
            GameObject newBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            // TODO: -
            newBullet.GetComponent<Bullet>().Config(BulletType.PlayerBullet, bulletSpeed);

            yield return new WaitForSeconds(1/fireRate);
        }
    }
}
