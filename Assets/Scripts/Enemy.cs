using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [SerializeField] private float triggerRadius;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //Check if the player is within triggerRadius, use SqrMagnitude to avoid doing sqrRoot operations to calculate distance since it is faster
        if (Vector3.SqrMagnitude(transform.position - Player.Instance.transform.position) < triggerRadius * triggerRadius) {
            Debug.Log("enemy: " + this.gameObject.name + " is within radius, killed!");
            Destroy(this.gameObject);
        };
    }
    public void Kill() {
        Debug.Log("enemy: " + this.gameObject.name + " killed!");
        Destroy(this.gameObject);
    }
}
