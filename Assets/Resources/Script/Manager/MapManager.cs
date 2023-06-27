using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject Room; // 방 모델
    private GameObject indexRoom; // 전방
    private GameObject nextRoom; // 다음방
    private GameObject wallCheckRoom;
    public GameObject hallWay; // 복도
    private GameObject hallWays;
    public GameObject Wall; // 벽
    GameObject firstRoom; // 처음방

    private Vector3 Rotation = new Vector3(0, 0, 0);

    int layerMask;
    int layerMaskhall;
    int roomNum;
    int roomAmount;
    private int distance = 6; // 레이케스트 거리
    private int roomDistance = 12; // 방 사이 거리

    Vector3 addPoint; // 레이케스트 시작 포인트
    Vector3 direction; // 방 랜덤 방향

    void StageLoading()
    {

        roomAmount = Random.Range(8, 16);

        for (int i = 0; i < roomAmount; i++)
        {
            mapCreate();
        }
        wallCheckRoom = nextRoom;
        roomNum++;
        wallCreate();
    }

    void mapCreate()
    {
        int randomDirection = Random.Range(0, 4);

        if (randomDirection == 0)
        {
            direction = new Vector3(1, 0, 0);
            Rotation = new Vector3(0f, 0f, 0f);
        }
        else if (randomDirection == 1)
        {
            direction = new Vector3(0, 0, -1);
            Rotation = new Vector3(0f, 90f, 0f);
        }
        else if (randomDirection == 2)
        {
            direction = new Vector3(-1, 0, 0);
            Rotation = new Vector3(0f, 180f, 0f);
        }
        else if (randomDirection == 3)
        {
            direction = new Vector3(0, 0, 1);
            Rotation = new Vector3(0f, 270f, 0f);
        }

        addPoint = direction * distance; // 레이케스트 시작 포인트

        RaycastHit rayHit;
        //Debug.DrawRay(indexRoom.transform.position + addPoint + new Vector3(0, 3, 0), direction * 10, new Color(0, 1, 0), 50);
        if (Physics.Raycast(indexRoom.transform.position + addPoint, direction, out rayHit, roomDistance, layerMask) == false)
        {
            roomCreate();
            wayCreate();
            wallCheckRoom = indexRoom;
            indexRoom = nextRoom;
            wayCreate(); // re-checking

            wallCreate();
        }


    }

    void wallCreate()
    {
        RaycastHit wallRaycast;
        for (int a = 0; a < 4; a++)
        {
            if (a == 0)
            {
                direction = new Vector3(1, 0, 0);
                Rotation = new Vector3(0f, 0f, 0f);
            }
            else if (a == 1)
            {
                direction = new Vector3(0, 0, -1);
                Rotation = new Vector3(0f, 90f, 0f);
            }
            else if (a == 2)
            {
                direction = new Vector3(-1, 0, 0);
                Rotation = new Vector3(0f, 180f, 0f);
            }
            else if (a == 3)
            {
                direction = new Vector3(0, 0, 1);
                Rotation = new Vector3(0f, 270f, 0f);
            }
            addPoint = direction * 8;
            Debug.DrawRay(wallCheckRoom.transform.position + addPoint + new Vector3(0, 3, 0), addPoint, new Color(1, 0, 0), 50);
            if (Physics.Raycast(wallCheckRoom.transform.position + addPoint, direction, out wallRaycast, 6, layerMask) == false)
            {
                GameObject wallss = Instantiate(Wall, wallCheckRoom.transform.position, Quaternion.Euler(Rotation));
                wallss.name = "Wall" + roomNum.ToString();
                //wallss.transform.SetParent(wallCheckRoom.transform, true);
            }
        }
    }

        void wayCreate()
        {
            RaycastHit rayHitway;
            for (int a = 0; a < 4; a++)
            {
                if (a == 0)
                {
                    direction = new Vector3(1, 0, 0);
                    Rotation = new Vector3(0f, 0f, 0f);
                }
                else if (a == 1)
                {
                    direction = new Vector3(0, 0, -1);
                    Rotation = new Vector3(0f, 90f, 0f);
                }
                else if (a == 2)
                {
                    direction = new Vector3(-1, 0, 0);
                    Rotation = new Vector3(0f, 180f, 0f);
                }
                else if (a == 3)
                {
                    direction = new Vector3(0, 0, 1);
                    Rotation = new Vector3(0f, 270f, 0f);
                }
                addPoint = direction * distance;

                //Debug.DrawRay(indexRoom.transform.position + addPoint + new Vector3(0, 3, 0), direction * 5, new Color(0, 0, 1), 50);
                if (Physics.Raycast(indexRoom.transform.position + addPoint, direction, out rayHitway, roomDistance, layerMask) == true)
                {
                    if (Physics.Raycast(indexRoom.transform.position + new Vector3(0, 3, 0), direction, out rayHitway, roomDistance, layerMaskhall) == false)
                    {
                         int randomCreate = Random.Range(0, 10);
                         if(randomCreate <= 6) 
                        {
                             hallWays = Instantiate(hallWay, indexRoom.transform.position + (direction * 6), Quaternion.Euler(Rotation));
                             hallWays.name = "Hall" + roomNum.ToString();
                            //hallWays.transform.SetParent(indexRoom.transform, true);
                         }
                    }
                }
            }
        }
        void roomCreate()
        {
            nextRoom = Instantiate(Room, indexRoom.transform.position + (direction * roomDistance), Quaternion.identity);
            roomNum++;
            nextRoom.name = "Room" + roomNum.ToString();
        }

        // Start is called before the first frame update
        void Start()
        {
            layerMask = LayerMask.GetMask("Room");
            layerMaskhall = LayerMask.GetMask("Hall");
            firstRoom = Instantiate(Room, this.transform.position, Quaternion.identity);
            firstRoom.name = "firstRoom".ToString();
            indexRoom = firstRoom;

            StageLoading();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }