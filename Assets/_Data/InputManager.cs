using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public Vector2 mousePos;

    private void Awake()
    {
        InputManager.Instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LoadMousePos();

    }

    protected virtual void LoadMousePos()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);
    }
}
