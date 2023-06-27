using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    float gravity = -20f;
    float yVelocity = 0;
    CharacterController CC;

    public float rotSpeed = 200f;

    float mx;

    private void Start()
    {
        CC = GetComponent<CharacterController>();

    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }


    void Rotate()
    {
        float mouse_X = Input.GetAxis("Mouse X");

        mx += mouse_X * rotSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, mx, 0);
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0, v);

        dir = dir.normalized; // 방향만 잡기위해 값을 단순화시키기

        dir = Camera.main.transform.TransformDirection(dir); //  캐릭터 현재 회전에 맞춰서 이동방향을 월드 벡터로 맞춤

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        CC.Move(dir * moveSpeed * Time.deltaTime);
    }

}
