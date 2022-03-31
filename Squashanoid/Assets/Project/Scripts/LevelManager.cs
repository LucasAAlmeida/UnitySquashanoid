using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [Range(0.1f, 2f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int currentScore;
    [SerializeField] TextMeshProUGUI scoreText;

    int blocksCount;
    int pointsPerBlock = 100;

    public static bool IsInitialized
    {
        get { return Instance != null; }
    }

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void OnBlockCreated()
    {
        blocksCount++;
    }

    public void OnBlockBroken()
    {
        blocksCount--;
        if (blocksCount <= 0) {
            var sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
            if (sceneBuildIndex < 2) {
                SceneManager.LoadScene(sceneBuildIndex + 1);
            } else {
                SceneManager.LoadScene(0);
            }
        }
        currentScore += pointsPerBlock;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }
}
