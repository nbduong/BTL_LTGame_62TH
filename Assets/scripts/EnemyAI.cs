using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool ishootable = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeWtbFire;
    private float fireCooldown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if( fireCooldown < 0)
        {
            fireCooldown = timeWtbFire;
            EnemyFireBullet();
        }
    }

    void EnemyFireBullet()
    {
        var bulletTmp = Instantiate(bullet , transform.position,Quaternion.identity);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        Vector3 playerPos = FindAnyObjectByType<Player>().transform.position;
        Vector3 direction = playerPos - transform.position;
        rb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
    }
}
