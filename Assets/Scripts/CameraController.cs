using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Camera offset = camera position - player position
        this.offset = transform.position - new Vector3(this.player.transform.position.x, 0.0f, this.player.transform.position.z);
    }

    // LateUpdate is called once per frame at the end of the frame
    void LateUpdate()
    {
        // Dimension of the Player Ball
        Vector3 playerSize = new Vector3(
            this.player.transform.localScale.x,
            this.player.transform.localScale.y,
            this.player.transform.localScale.z * 2
            );
        // Camera positione = player position + offset
        transform.position = new Vector3(
            this.player.transform.position.x,
            0.0f + playerSize.y,
            this.player.transform.position.z - playerSize.z // camera is front of the player, so z need to be decremented
            ) + this.offset;
    }
}
