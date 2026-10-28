using UnityEngine;
using System.Collections;

public class Tunnel : MonoBehaviour
{
    private Transform destination;

    public bool isTunnel1;
    public float distance = 0.2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isTunnel1 ==false){
            destination = GameObject.FindGameObjectWithTag("Tunnel1").GetComponent<Transform>();
        }
        else{
            destination = GameObject.FindGameObjectWithTag("Tunnel2").GetComponent<Transform>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Vector2.Distance(transform.position, other.transform.position) > distance && other.CompareTag("Player")){
            other.transform.position = new Vector2(destination.position.x, destination.position.y);
        }
    }
}
