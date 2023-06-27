using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject[] RoomList;
    public GameObject wall;

    int RoomMax = 2;
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RoomMaker(Transform doorTr)
    {
        if (RoomMax >= i)
        {
            int i = Random.Range(0, RoomList.Length);
            Instantiate(RoomList[i], doorTr.position, doorTr.rotation);
            Debug.Log("¸¸µê");
        }
    }
    public void WallMaker(Transform doorTr)
    {
        GameObject walls = Instantiate(wall, doorTr.position,doorTr.rotation);
        walls.name = "º®".ToString();
    }
}
