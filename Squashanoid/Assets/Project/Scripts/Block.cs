using UnityEngine;

public class Block : MonoBehaviour
{
    // Config params
    [SerializeField] AudioClip destroySound;
    [SerializeField] GameObject sparkleVFX;
    [SerializeField] int maxHits = 2;
    [SerializeField] Sprite[] blockSprites;

    // Cached refs
    LevelManager level;

    // Status variables
    int timesHit = 0;

    private void Start()
    {
        level = FindObjectOfType<LevelManager>();
        if (CompareTag("BreakableBlock")) {
            level.OnBlockCreated();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("BreakableBlock")) {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit < maxHits) {
            GetComponent<SpriteRenderer>().sprite = blockSprites[timesHit];
        } else {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
        Instantiate(sparkleVFX, transform.position, transform.rotation);
        Destroy(gameObject);
        level.OnBlockBroken();
    }
}
