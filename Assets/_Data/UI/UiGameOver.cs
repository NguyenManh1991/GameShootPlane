
using TMPro;
using UnityEngine;

public class UiGameOver : MonoBehaviour
{

    public Transform text;
    public Transform button;
    void Awake()
    {
        LoadtextGameOver();
    }
    private void FixedUpdate()
    {
        UpDateUi();
    }

    protected virtual void LoadtextGameOver()
    {
        text = transform.Find("TextGameOver");
        button = transform.Find("ButtonRePlay");
    }


    protected virtual void UpDateUi()
    {
        if (GameOver.Instance.IsGameOver())
        {
            text.gameObject.SetActive(true);
            button.gameObject.SetActive(true);
            return;
        }

        text.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
    }

    public virtual void RePlay()
    {
        GameOver.Instance.RePlay();
    }
}
