using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    private Vector2 velocity;
    public float xTime;
    public float yTime;

    [SerializeField]
    private GameObject player;

  
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, xTime);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, yTime);

        transform.position = new Vector3(posX, posY, transform.position.z);
    }
}
