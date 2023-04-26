using Platformer.Gameplay;
using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Platformer.Core.Simulation;


public class Glyphs : MonoBehaviour
{
    public float RecycleDelay = 0.1f;
    public Sprite[] glyphs;

    Collider2D coll;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChooseRandomGlyph();
        StartCoroutine(CheckDestroyGlyph());
    }

    IEnumerator CheckDestroyGlyph()
    {
        Vector2 threshold = new Vector2(0.1f, 0.1f);

        while(true)
        {
            yield return new WaitForSeconds(RecycleDelay);

            if (rb.velocity.magnitude < 0.1f)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void ChooseRandomGlyph()
    {
        spriteRenderer.sprite = glyphs[Random.Range(0, glyphs.Length)];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            coll.enabled = false;
            Destroy(this.gameObject);
        }
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            var ev = Schedule<PlayerEnemyCollision>();
            ev.player = player;
        }
    }
}
