using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 --> bottom
    // 2 --> top
    // 3 --> left
    // 4 --> right

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    private int roomAmount;
    private int roomUpAmount;
    private int roomDownAmount;
    private int roomLeftAmount;
    private int roomRightAmount;

    private Vector3 balance = new Vector3(-3.5f, -4.5f, 0f);

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        roomAmount = Random.Range(16, 24);
        roomUpAmount = Random.Range(2, Mathf.FloorToInt(roomAmount/4));
        roomDownAmount = Random.Range(2, Mathf.FloorToInt((roomAmount - roomUpAmount) / 3));
        roomLeftAmount = Random.Range(2, Mathf.FloorToInt((roomAmount - roomUpAmount - roomDownAmount) / 2));
        roomRightAmount = Random.Range(2, Mathf.FloorToInt(roomAmount - roomUpAmount - roomDownAmount - roomLeftAmount));
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                //spawn room with bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position + balance, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //spawn room with top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position + balance, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //spawn room with left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position + balance, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //spawn room with right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position + balance, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    /*void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                //spawn room with bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position + balance, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //spawn room with top door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position + balance, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //spawn room with left door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position + balance, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //spawn room with right door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position + balance, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
