using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Player player;
    public int minDamage;
    public int maxDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            player = collision.GetComponent<Player>();
            InvokeRepeating("DamegePlayer", 0, 1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = null;
            CancelInvoke("DamagePlayer");
        }
    }

    void DamegePlayer()
    {
        int damage = UnityEngine.Random.Range(minDamage, maxDamage);
        player.TakeDamage(damage);
        //Debug.Log("Player take damage" + damage);
    }
}
