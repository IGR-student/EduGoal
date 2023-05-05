// using System.Collections;
// using System.Collections.Generic;
// using System.Collections.Specialized;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class DarkWizard : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int SpriteIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite),0.15f,0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        SpriteIndex++;

        if (SpriteIndex > sprites.Length)
        {
            SpriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[SpriteIndex];
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "OBSTACLE")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "SCORE")
        {
            FindObjectOfType<GameManager>().IncScore();
        }
    }
}
