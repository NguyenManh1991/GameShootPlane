
using System.Collections.Generic;
using UnityEngine;


public class MoveByPath : MonoBehaviour
{
    [Header("By Path")]
    public Transform checkpointsPath;
    public float checkPointDistance = Mathf.Infinity;
    public int checkPointIndex = 0;
    public bool pathFinish = false;
    public float speed = 2f;
    public List<Transform> checkpoints;
    protected virtual void Start()
    {
        LoadCheckpoints();
    }
    private void Update()
    {
        MoveToNextCheckPoint();
        Moving();
    }
    protected virtual void LoadCheckpoints()
    {
        checkpointsPath = GameObject.Find(transform.parent.name + "_Path").transform;
        foreach (Transform checkpoint in checkpointsPath)
        {
            checkpoints.Add(checkpoint);
        }

    }
    protected virtual void Moving()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, CurrentCheckPoint().position, step);

    }

    protected virtual Transform CurrentCheckPoint()
    {
        return checkpoints[checkPointIndex];
    }

    protected virtual void MoveToNextCheckPoint()
    {
        checkPointDistance = Vector3.Distance(transform.parent.position, CurrentCheckPoint().position);
        if (checkPointDistance <= 0) checkPointIndex++;
        if (checkPointIndex >= checkpoints.Count) 
        { 
            checkPointIndex = checkpoints.Count - 1;
            pathFinish = true;  
            
        }
    }

    protected virtual bool IsTheEndOfPath()
    {
        return pathFinish;
    }
}
