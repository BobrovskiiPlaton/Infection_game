using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float _speed;
    [SerializeField] private GameObject _inventory;
    public Transform player;

    // Update is called once per frame
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        GetInput();
        //UseInventory();
    }

    void GetInput()
    {
        Vector3 inputDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Jump"));
        inputDir.Normalize();
        Vector3 velocity = (transform.forward * inputDir.y + transform.right * inputDir.x + transform.up * inputDir.z) * _speed;
        transform.position += velocity * Time.deltaTime; 
    }

    /*void UseInventory()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _inventory.SetActive(!_inventory.activeSelf);
        }
    }*/
}
