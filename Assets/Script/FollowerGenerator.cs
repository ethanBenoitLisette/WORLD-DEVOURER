using UnityEngine;
using System.Collections;

public class FollowerGenerator : MonoBehaviour
{
    public GameObject followerPrefab;
    public Transform player;
    public float generationInterval = 10f;
    public int maxFollowers = 5;

    private void Start()
    {
        InvokeRepeating("GenerateFollower", 0f, generationInterval);
    }

    void GenerateFollower()
    {
        if (player != null)
        {
            int followerCount = GameObject.FindGameObjectsWithTag("Follower").Length;

            if (followerCount < maxFollowers)
            {
                Vector3 spawnPosition = GenerateRandomSpawnPosition();
                GameObject newFollower = Instantiate(followerPrefab, spawnPosition, Quaternion.identity);
                newFollower.GetComponent<Follower>().player = player;
            }
        }
    }

    Vector3 GenerateRandomSpawnPosition()
    {
        float randomX = Random.Range(player.position.x - 10f, player.position.x + 10f);
        float randomY = Random.Range(player.position.y - 10f, player.position.y + 10f);

        return new Vector3(randomX, randomY, 0f);
    }
}
