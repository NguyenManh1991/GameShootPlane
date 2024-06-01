
using TMPro;
using UnityEngine;

public class UiGoldUpdate : MonoBehaviour
{
    public TextMeshProUGUI textGold;
    void Start()
    {
        LoadTextGold();
    }
    private void FixedUpdate()
    {
        UpdateTextGold();
    }
    protected virtual void LoadTextGold()
    {
        textGold = GetComponent<TextMeshProUGUI>();
    }
    protected virtual void UpdateTextGold()
    {
        Score gold = ScoreManager.instance.Get(ScoreType.GoldCount.ToString());
        int goldValue = 0;
        if (gold != null) goldValue = gold.value;
        textGold.text = goldValue.ToString() + "G";
    }
}
