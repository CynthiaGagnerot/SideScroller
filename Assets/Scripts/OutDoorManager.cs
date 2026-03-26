using UnityEngine;

public class OutDoorManager : MonoBehaviour
{
    public Levier callingDoor;
    public float MyCoordinateX;
    public float MyCoordinateY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (callingDoor.Proxi == true)
        {
            
        }
    }
}
