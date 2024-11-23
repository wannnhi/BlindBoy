using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public void InitializeAllHeroStats()
    {
        HeroStats[] heroStatsList = FindObjectsOfType<HeroStats>();
        foreach (var heroStats in heroStatsList)
        {
            heroStats.Initialize();
        }
    }
}
