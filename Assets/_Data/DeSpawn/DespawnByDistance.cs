using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DespawnByDistance : DeSpawn
{
    public float despawnLimit = 20f;
    public float distance = 0f;
    public string camName = "Main Camera";
    public Transform mainCam;

    private void Start()
    {
        LoadCam();
    }
    private void FixedUpdate()
    {
        DespawnByDistancing();
    }
    protected virtual void LoadCam()
    {
        mainCam = GameObject.Find(camName).transform;
    }
    public virtual void DespawnByDistancing()
    {
        distance = Vector3.Distance(transform.position, mainCam.transform.position);
        if (distance > despawnLimit) DeSpawning();

    }
}
