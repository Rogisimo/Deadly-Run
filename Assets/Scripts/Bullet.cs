using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool canCollide = false;

    private void Start() {
        StartCoroutine(StartColliding());
    }

    IEnumerator StartColliding(){
        yield return new WaitForSeconds(0.1f);
        canCollide = true;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag != "Bullet" && !other.gameObject.name.Contains("Shooter") && canCollide){
            Destroy(this.gameObject);
        }
    }
}
