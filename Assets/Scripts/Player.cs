using UnityEngine;

public class Player : MonoBehaviour
{

    public float xPosition;
    public float zPosition;

    public Rigidbody rb;

    void Start()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update was called");
    }
}
