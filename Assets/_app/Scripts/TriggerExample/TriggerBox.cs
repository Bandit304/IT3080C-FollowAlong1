using System.Threading;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    [SerializeField]
    [Header("Counter")]
    private int _count;

    public void OnTriggerEnter(Collider other) {
        if (other.tag == "Interactor")
            Debug.Log(other.transform.name + " has entered box");
    }
    
    public void OnTriggerExit(Collider other) {
        Debug.Log(other.transform.name + " has exited box");
    }

    public void OnCollisionEnter(Collision other) {
        CountUp();
        Debug.Log(other.transform.name + " collided with box");
    }

    public void OnCollisionExit(Collision other) {
        Debug.Log(other.transform.name + " stopped colliding with box");
    }

    public void CountUp() => _count++;
}
