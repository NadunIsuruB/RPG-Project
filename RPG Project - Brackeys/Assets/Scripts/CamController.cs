using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Vector3 offSet;

    public GameObject Player;

    float _yaw;

    void Start()
    {
        offSet = transform.position - Player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = Player.transform.position + offSet;
        transform.LookAt(Player.transform.position, Vector3.up);
        transform.RotateAround(Player.transform.position, Vector3.up, _yaw);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _yaw++;
            Debug.Log("Left");
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("right");
            _yaw--;
        }

    }
}
