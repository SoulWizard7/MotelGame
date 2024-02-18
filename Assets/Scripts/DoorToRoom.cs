using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorToRoom : MonoBehaviour
{
    public Room Room;
    private BoxCollider2D Collider;
    private Vector3 ColliderOffset;

    public Vector3 EnterOffset;
   

    // Start is called before the first frame update
    void Start()
    {
        Collider = gameObject.GetComponent<BoxCollider2D>();
        ColliderOffset = new Vector3(Collider.offset.x, Collider.offset.y, 0);
        Room.Door = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MoveToRoom(GameObject Player){        
        Player.transform.position = Room.transform.position + Room.ColliderOffset + Room.EnterOffset;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("DoorToRoomTrigger");
        if(other.CompareTag("Player")){
            PlayerMovement pm = other.GetComponent<PlayerMovement>();
            pm.cameraFollow.SetCameraTarget(Room.transform);
            pm.cameraFollow.SetCameraPosition();

            MoveToRoom(other.gameObject);
        }
    }
    
}
