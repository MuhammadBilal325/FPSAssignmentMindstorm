using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    [SerializeField] private float triggerRadius;
    private bool printed = false;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //Check if the player is within triggerRadius, use SqrMagnitude to avoid doing sqrRoot operations to calculate distance since it is faster
        //Keep a bool so we only print the Obstacle message once every time the player gets into range
        if (Vector3.SqrMagnitude(transform.position - Player.Instance.transform.position) < triggerRadius * triggerRadius) {
            if (!printed) {
                Debug.Log("osbtacle: " + this.gameObject.name + " is within radius !");
                printed = true;
            }
        }
        else {
            printed = false;
        };
    }

    public void OnHit() {
        Debug.Log("obstacle: " + this.gameObject.name + " shot!");
    }
}
