using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using scripts.events;

public class RoomSpawner : MonoBehaviour
{
    private Object[] roomPrefabs;
    private Transform _transform;
    private Vector2 newRoomLocation;
    // Start is called before the first frame update
    void Start()
    {
        roomPrefabs = Resources.LoadAll("Prefabs/Rooms");
        _transform = GetComponent<Transform>();
        newRoomLocation = _transform.position + 
            new Vector3(20, 0, 0);
            
        Events.OnRoomChange.AddListener(onRoomEnter);
    }
    
    void onRoomEnter() {
        Instantiate(getRandomRoom(), newRoomLocation, Quaternion.identity);
    }

    Object getRandomRoom() {
        return roomPrefabs[Random.Range(0, roomPrefabs.Length)];
    }
}
