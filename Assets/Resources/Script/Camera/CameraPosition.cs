using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    GameObject Player;

    public float offsetX = 0f;
    public float offsetY = 10f;
    public float offsetZ = -10f;

    public float angleX = 0f;
    public float angleY = 0f;
    public float angleZ = 0f;

    public float cameraSpeed = 10f;
    Vector3 PlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }


    void FixedUpdate()
    {
        PlayerPos = new Vector3(
            Player.transform.position.x + offsetX,
            Player.transform.position.x + offsetY,
            Player.transform.position.x + offsetZ
            );

        transform.position = Vector3.Lerp(
            transform.position, PlayerPos, Time.deltaTime * cameraSpeed);

        transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);
    }
}
