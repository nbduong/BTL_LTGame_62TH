using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Player player;
    public int minDamage;
    public int maxDamage;
    public int health = 5;
    private int ScoreValue = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            player = collision.GetComponent<Player>();
            InvokeRepeating("DamegePlayer", 0, 1f);
        }
        if (collision.CompareTag("playerBullet"))
        {
            health--;
            Destroy(collision.gameObject); 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Player>();
            CancelInvoke("DamegePlayer");
        }
    }

    private void Update()
    {
        if (health == 0) {
            Destroy(gameObject);
            FindObjectOfType<Player>().AddScore(ScoreValue);
        }
    }
    void DamegePlayer()
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        player.TakeDamage(damage);
        //Debug.Log("Player take damage" + damage);
    }
}
