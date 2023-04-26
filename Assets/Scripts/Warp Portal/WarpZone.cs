using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class WarpZone : MonoBehaviour
{
    // Public Properties
    public Color PortalTint = new Color(0, 0, 0, 0);
    public WarpZone Destination;

    bool isPortalActive = true;

    AudioSource m_audioSource;

    void OnEnable()
    {
        // Reference the sprite tinting to sprite renderer
        this.GetComponent<SpriteRenderer>().color = PortalTint;
        m_audioSource = GetComponent<AudioSource>();
    }

    const string playerTag = "Player";
    void OnTriggerEnter2D(Collider2D collision)
    {
        // tag is "WarpZone"
        if(collision.tag == "Player")
        {
            if(isPortalActive)
            {
                if(Destination != null)
                {
                    Destination.TeleportPlayerToMe(
                        collision.transform
                    );
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Enables the WarpZone destination
        isPortalActive = true;
    }

    public void TeleportPlayerToMe(Transform player)
    { 
        // Set isPortalActive to false
        isPortalActive = false;

        m_audioSource.Play();

        player.transform.position = this.transform.position;
    }
}
