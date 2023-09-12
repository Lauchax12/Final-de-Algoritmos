using UnityEngine;

public class GroundRepeat : MonoBehaviour
{

    private float spriteWidth;
    void Start()
    {
        BoxCollider2D groundCollider = GetComponent<BoxCollider2D>();
        spriteWidth = groundCollider.size.x;
    }

    void Update()
    {
        if(transform.position.x < -spriteWidth)
        {
            ResetPosition();



        }

    }
    private void ResetPosition()
    {
        transform.Translate(new Vector3(2 * spriteWidth, 0f, 0f));
    }
}
