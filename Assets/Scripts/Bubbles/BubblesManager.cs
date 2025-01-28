using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BubbleManager : MonoBehaviour
{
    [SerializeField] private float minSpawnInterval = 1f;
    [SerializeField] private float maxSpawnInterval = 3f;
    [SerializeField] private float bubbleLifetime = 4f;
    [SerializeField] private GameObject bubblePrefab;
    [SerializeField] private RectTransform spawnArea;

    //Bounds for spawning bubbles (in world space)
    public Vector2 spawnAreaMin = new Vector2(-5, -5);

    public Vector2 spawnAreaMax = new Vector2(5, 5);
    
    private void Start()
    {
        StartCoroutine(SpawnBubbles());
    }

    private IEnumerator SpawnBubbles()
    {
        while (true)
        {
            float spawnDelay = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnDelay);

            SpawnBubble();
        }
    }

    private void SpawnBubble()
    {
        if (bubblePrefab == null)
        {
            Debug.LogWarning("Bubble prefab is not assigned");
            return;
        }
        
        // Generate a random position within the spawn area
        Vector2 randomPos = new Vector2(
            Random.Range(spawnArea.rect.xMin, spawnArea.rect.xMax),
            Random.Range(spawnArea.rect.yMin, spawnArea.rect.yMax)
        );

        Vector3 worldPos = spawnArea.TransformPoint(randomPos);

        // Instantiate the bubble and schedule its destruction
        GameObject bubble = Instantiate(bubblePrefab, spawnArea);
        bubble.transform.position = worldPos;
        Destroy(bubble, bubbleLifetime);
    }
}