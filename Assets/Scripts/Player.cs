using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider; // hitbox
    private Vector3 moveDelta; // change in position between this and next frame
    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called every frame *use fixedUpdate if this breaks stuff, but Update looks smoother
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal"); // -1 if left, 1 if right, 0 if no button pressed
        float y = Input.GetAxisRaw("Vertical"); // -1 if down, 1 if up, 0 if no button pressed
        // reset moveDelta
        moveDelta = new Vector3(x, y, 0);

        // make sprite face right or left depending on direction
        if (moveDelta.x > 0) {
            transform.localScale = Vector3.one;
        } else if (moveDelta.x < 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // check for hit in y direction by casting box there first - if box returns null, we can move there
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actors", "Blocking"));
        if (hit.collider == null) {
            // move!
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        // check for hit in x direction by casting box there first - if box returns null, we can move there
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actors", "Blocking"));
        if (hit.collider == null) {
            // move!
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

        
    }
}
