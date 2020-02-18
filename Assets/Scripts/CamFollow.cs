using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject camBase;
    private Vector3 offset;
    float distance;
    Vector3 playerPrevPos, playerMoveDir;

    void Start()
    {
        transform.position = camBase.transform.position;
        transform.LookAt(player.transform.position);
    }

    void Update()
    {
        transform.position = camBase.transform.position;
        transform.LookAt(player.transform.position);
    }
}
