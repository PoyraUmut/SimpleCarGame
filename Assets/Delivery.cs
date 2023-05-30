using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 notPackageColor = new Color32(0,1,0,0);
    [SerializeField] float DestroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("bum");
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "package" && !hasPackage){
            Debug.Log("Package picked up.");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject,DestroyDelay);
        }
        if(other.tag == "customer" && hasPackage){
            Debug.Log("delivered package.");
            hasPackage = false;
            spriteRenderer.color = notPackageColor;
        }
    }
}
