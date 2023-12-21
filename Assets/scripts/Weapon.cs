using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePos;
    public GameObject tialua;
    public float Tocdoban = 0.2f;
    public float bulletForce;

    private float tocdoban;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateGun();
        tocdoban -= Time.deltaTime;
        if (Input.GetMouseButton(0) && tocdoban <0)
        {
            Fire();
        }
    }

    void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);    
        transform.rotation = rotation;
        Vector3 currentScale = transform.localScale;
        if (transform.eulerAngles.z >90 &&  transform.eulerAngles.z < 270)
        {
            if(currentScale.y > 0)
            {
                transform.localScale = new Vector3(currentScale.x, -currentScale.y, currentScale.z);
            }
            
        }
        else
        {
            if(currentScale.y < 0)
            {
                transform.localScale = new Vector3(currentScale.x, -currentScale.y, currentScale.z);
            }
         
        }
    }
    void Fire()
    {
        tocdoban = Tocdoban;
        GameObject bulletTmp = Instantiate(bullet, firePos.position, quaternion.identity);
        Instantiate(tialua, firePos.position, transform.rotation, transform);
        Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }
}
