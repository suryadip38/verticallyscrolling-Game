using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as desired
                             //private GameObject Triangle;
    [SerializeField] float lanePositionX;
    private float gameY;
    
    // Start is called before the first frame update
    void Start()
    {
        gameY = 0;
       

    }

    // Update is called once per frame
    void Update()
    {
        gameY = Time.deltaTime * speed;
        transform.position = new Vector3(transform.position.x , transform.position.y - gameY, transform.position.z);

    }
}
