using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeSpawn : MonoBehaviour
{
    public float despawnLimit = 20f;
    public float distance = 0f;
    public Transform mainCam;

    public virtual void DeSpawning()
    {
        Debug.Log("Call here");
        Destroy(transform.parent.gameObject);
    }

    private void Start()
    {
        LoadCam();
    }
    private void FixedUpdate()
    {
        DespawnByDistance(); 
    }
    protected virtual void LoadCam()
    {
        mainCam = GameObject.Find("Main Camera").transform;
    }

    public virtual void DespawnByDistance()
    {
        distance =Vector3.Distance(transform.position, mainCam.transform.position);
        if (distance > despawnLimit) DeSpawning();

    }
}
