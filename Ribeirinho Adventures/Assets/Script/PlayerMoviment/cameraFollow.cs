using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float FollowSpeed = 10f;
    public float YOffSet = 2.5f;
    public Transform target;

    void Start()
    {
        
    }

  
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y + YOffSet,-5f);
        transform.position = Vector3.Slerp(transform.position, newPos,FollowSpeed*Time.deltaTime);
    }
}
