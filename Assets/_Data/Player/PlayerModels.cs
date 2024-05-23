using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModels : MonoBehaviour
{
    public List<Transform> models;
    public int index = 0;

    protected virtual void Start()
    {
        LoadModel();
        index = LoadForSaveGame();
        ModelActive(index);


    }

    protected virtual void LoadModel()
    {
        foreach (Transform model in transform)
        {
            models.Add(model);
        }
    }

    protected virtual void HideAll()
    {
        foreach (Transform model in models)
        {
            model.gameObject.SetActive(false);
        }
    }

    public virtual void ModelActive(int index)
    {
        HideAll();
        if(index >= models.Count) index=models.Count-1;
        models[index].transform.gameObject.SetActive(true);

    }

    protected virtual int LoadForSaveGame()
    {
        return 0;
    }
}
