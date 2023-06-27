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

        dir = dir.normalized; // ���⸸ ������� ���� �ܼ�ȭ��Ű��

        dir = Camera.main.transform.TransformDirection(dir); //  ĳ���� ���� ȸ���� ���缭 �̵������� ���� ���ͷ� ����

        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        CC.Move(dir * moveSpeed * Time.deltaTime);
    }

}
