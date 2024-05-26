using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public string holderName = "spawnHolder";
    public Transform holder;
    public List<Transform> form = new();
  
    void Start()
    {
        LoadHolder();
        LoadForm();
        HideAll();
    }
    protected virtual void LoadForm()
    {
        foreach (Transform form in transform)
        {
            this.form.Add(form);
        }
    }

    protected virtual void LoadHolder()
    {
        holder = GameObject.Find(holderName).transform;
    }

    public virtual Transform Spawn(string holderName, Vector3 spawnPosition)
    {
        Transform form = GetFormByName(holderName);
        Transform newForm = Instantiate(form);

        newForm.transform.position = spawnPosition;
        newForm.transform.SetParent(holder);
        return newForm;
    }

    public virtual Transform GetFormByName(string holderName)
    {
        foreach (var form in form)
        {
            if (form.name == holderName) return form;

        }  
        return null;
    }
    protected virtual void HideAll()
    {
        foreach (var form in form)
        {
            form.gameObject.SetActive(false);
        }
    }
}
