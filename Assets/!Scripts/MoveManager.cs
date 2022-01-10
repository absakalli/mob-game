using UnityEngine;
using UnityEngine.EventSystems;

public class MoveManager : MonoBehaviour
{
    private Vector3 delta;
    private Vector3 lastPos;
    private Rigidbody2D rb;
    public float speed;
    public bool hasEntered;

    void Start()
    {
        hasEntered = false;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        BirdsMove();
    }
    void BirdsMove()
    {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                lastPos = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                delta = Input.mousePosition - lastPos;

                if (delta.y > 0)
                {
                    rb.velocity = new Vector2(0, speed);
                }
                else if (delta.y < 0)
                {
                    rb.velocity = new Vector2(0, -speed);
                }
                else
                {
                    rb.velocity = rb.velocity * 0.6f;
                }

                lastPos = Input.mousePosition;
            }
            else
            {
                rb.velocity = rb.velocity * 0.6f;
            }                
    }
}
