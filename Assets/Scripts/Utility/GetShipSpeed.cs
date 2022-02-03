using UnityEngine;

public class GetShipSpeed : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private SOFMODParameterData shipSpeedData;
    public float shipSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        shipSpeed = rb.velocity.magnitude;
        shipSpeedData.FloatValue = shipSpeed;
    }
}
