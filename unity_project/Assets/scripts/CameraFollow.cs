using UnityEngine;
using System.Collections;
public class CameraFollow : MonoBehaviour
{
    Vector3 Velocity = Vector3.zero;
    public float smoothtime = .15f;
    public GameObject player;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void Update()
    {
        //transform.position = player.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref Velocity, smoothtime);
    }
}