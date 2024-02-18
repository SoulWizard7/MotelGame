using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : MonoBehaviour
{
    public TilemapRenderer tilemapRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D player){
        if(player.tag == "Player"){
            tilemapRenderer.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D player){
        if(player.tag == "Player"){
            tilemapRenderer.enabled = true;
        }
    }
}
