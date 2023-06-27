using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Update is called once per frame

    UIManager UIManager;
    int itemId;
    GameObject Player;
    private void Start()
    {
        UIManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.AllClose();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            UIManager.InventoryOpen();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            UIManager.RootOpen();

        }
    }
}
