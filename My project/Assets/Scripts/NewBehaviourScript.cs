using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce;

    private Rigidbody2D rigidbody;
    private Transform playerTranform;
    private SpriteRenderer spriteRenderer;

    private bool isOnFloor = true;
    private int doublejump = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerTranform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;

        playerTranform.Translate(new Vector3 (moveX, 0, 0));

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            doublejump++;
            if (doublejump >= 2)
            {
                isOnFloor = false;
            }
            rigidbody.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        doublejump = 0;
        isOnFloor = true;

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
