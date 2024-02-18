using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [HideInInspector]public DoorToRoom Door;
    [HideInInspector]public Vector3 ColliderOffset;
    private BoxCollider2D Collider;
    public Vector3 EnterOffset;
    public int roomNr;
    // Start is called before the first frame update
    void Start()
    {
        Collider = gameObject.GetComponent<BoxCollider2D>();
        ColliderOffset = new Vector3(Collider.offset.x, Collider.offset.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void MoveToOverworld(GameObject player){
        player.transform.position = Door.transform.position + Door.EnterOffset;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("RoomTrigger");
        if(other.CompareTag("Player")){
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            MoveToOverworld(other.gameObject);
            pm.cameraFollow.SetCameraTargetToPlayer();
            pm.cameraFollow.SetCameraPosition();
            
        }
    }
}
