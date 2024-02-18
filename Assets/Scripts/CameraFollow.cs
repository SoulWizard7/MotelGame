using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerMovement Player;
    public Transform target;
    public float lerpSpeed = 1.0f;
    private Vector3 offset;
    private Vector3 targetPos;
    
    private bool bCameraFollow = true;

    private void Start()
    {
        if (target == null) return;
        if (!bCameraFollow) return;

        offset = transform.position - target.position;
    }

    private void Update()
    {
        if (target == null) return;

        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    }
    public void SetCameraFollow(bool newCameraFollow, bool snapToTargetPos){
        bCameraFollow = newCameraFollow;
        if(snapToTargetPos){
            transform.position = target.transform.position;
        }
    }

    public void SetCameraPosition(){
        transform.position = target.transform.position;
    }
    public void SetCameraTarget(Transform newTarget){
        target = newTarget;
    }
    public void SetCameraTargetToPlayer(){
        target = Player.transform;        
    }
}
