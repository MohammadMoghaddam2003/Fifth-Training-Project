using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public Transform EndPosition;

    [Range(5f,20f)]
    public float Speed = 5;



    void FixedUpdate()
    {
        transform.Translate(-Speed * Time.fixedDeltaTime,0,0);

        if (transform.position.x < -24.9f)
        {
            transform.position = new Vector3(EndPosition.position.x,-4.37279f,0);
        }
    }
}
