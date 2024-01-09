using Pathfinding;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của quái vật
    public GameObject flyEnemyPrefab; // Prefab của quái vật

    public float spawnRadius = 100f; // Bán kính sinh quái vật
    public int soluongquai;
    private float spawnCD = 5f; 
    void Start()
    {
            
    }
    private void Update()
    {
        spawnCD -= Time.deltaTime;
        if (spawnCD < 0)
        {
            spawnCD = 5f;
            SpawnMonsterNearPlayer();
        }
    }
    void SpawnMonsterNearPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player"); // Tìm player bằng tag "Player"
        
        if (player != null)
        {
            Vector3 randomOffset = Random.insideUnitCircle * spawnRadius; // Sinh vị trí ngẫu nhiên trong bán kính spawnRadius
            Vector3 spawnPosition = player.transform.position + randomOffset + new Vector3(20,20,0); // Vị trí sinh là vị trí của player cộng với offset
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // Sinh quái vật tại vị trí và góc quay nhất định\
            AIDestinationSetter aIDestinationSetterenemy = enemy.GetComponent<AIDestinationSetter>();
            aIDestinationSetterenemy.target = player.transform;



            Vector3 randomOffset1 = Random.insideUnitCircle * spawnRadius; // Sinh vị trí ngẫu nhiên trong bán kính spawnRadius
            Vector3 spawnPosition1 = player.transform.position + randomOffset1 + new Vector3(20, 20, 0); // Vị trí sinh là vị trí của player cộng với offset
            GameObject flyEnemy = Instantiate(flyEnemyPrefab, spawnPosition1, Quaternion.identity);
            AIDestinationSetter aIDestinationSetterflyEnemy = flyEnemy.GetComponent<AIDestinationSetter>();
            aIDestinationSetterflyEnemy.target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player not found!"); // Hiển thị cảnh báo nếu không tìm thấy player
        }
    }
}

