using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevel : Level
{
    public static GameLevel Instance;
    [Header("Game")]
    public float timer = 0;
    public float secondPerLevel = 10f;
    public float checkNumber;
    private void Awake()
    {
        if (GameLevel.Instance != null) Debug.LogError("Only one GameLevel allow", gameObject);
        GameLevel.Instance = this;
        //Set screen size for Standalone
#if UNITY_STANDALONE
        Screen.SetResolution(564, 960, false);
        Screen.fullScreen = false;
#endif
    }
    protected virtual void Start()
    {
        InvokeRepeating("LevelUp", 2f, 1f);
    }
    protected virtual void LevelUp()
    {
        timer += 1f;
        checkNumber = timer / secondPerLevel;
        level = Mathf.CeilToInt(checkNumber);
    }

}
