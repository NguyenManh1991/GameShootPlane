
using TMPro;
using UnityEngine;

public class TextLevelUp : MonoBehaviour
{
    public TextMeshProUGUI textGameUpdateLv;
    void Start()
    {
        LoadtextGameUpdateLv();
    }
    private void FixedUpdate()
    {
        UpdatetextGameUpdateLv();
    }

    protected virtual void LoadtextGameUpdateLv()
    {
        textGameUpdateLv = GetComponent<TextMeshProUGUI>();
    }


    protected virtual void UpdatetextGameUpdateLv()
    {
        int level = GameLevel.Instance.CurrentLevel();
        textGameUpdateLv.text = "Level "  +  level;
    }
}
