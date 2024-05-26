using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModels : MonoBehaviour
{
    public int modelIndex = 0;
    string StrikePoints = "StrikePoints";
    [SerializeField] protected List<Transform> models;
    [SerializeField] protected List<Transform> strikePoints;

    protected virtual void Start()
    {
        LoadModel();
        int index = LoadForSaveGame();
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
        if (index >= models.Count) index = models.Count - 1;
        modelIndex = index;
        models[index].transform.gameObject.SetActive(true);

        LoadStrikeModel();

    }

    protected virtual int LoadForSaveGame()
    {
        return 0;
    }

    protected virtual void LoadStrikeModel()
    {
        strikePoints.Clear();
        Transform currentModels = CurentModel();
        Transform strikePointsHolder = currentModels.Find(StrikePoints);
        if (strikePointsHolder == null) return;
        foreach(Transform point in strikePointsHolder)
        {
            strikePoints.Add(point);
        }
    }

    public virtual Transform CurentModel()
    {
        return models[modelIndex];
    }

    public virtual List<Transform> GetStrikePoints()
    {
        return strikePoints;
    }
}
