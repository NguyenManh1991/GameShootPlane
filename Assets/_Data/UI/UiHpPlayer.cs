using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiHpPlayer : MonoBehaviour
{
    public TextMeshProUGUI textUiHpPlayer;
    void Start()
    {
        LoadtextHpPlayer();
    }
    private void FixedUpdate()
    {
        UpdatetextHpPlayer();
    }

    protected virtual void LoadtextHpPlayer()
    {
        textUiHpPlayer = GetComponent<TextMeshProUGUI>();
    }


    protected virtual void UpdatetextHpPlayer()
    {
        int hpPlayer = GameOver.Instance.GetEnemyPassed();
        textUiHpPlayer.text =hpPlayer.ToString();
    }
}
