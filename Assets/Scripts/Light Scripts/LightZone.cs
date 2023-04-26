using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LightZone : MonoBehaviour
{
    public GameObject lightObject;
    public GameObject darkObject;

    bool zoneIsDark = true;

    void OnEnable()
    {
        lightObject.SetActive(false);
        darkObject.SetActive(true);
        TotalCount++;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (zoneIsDark)
            {
                lightObject.SetActive(true);
                darkObject.SetActive(false);
                zoneIsDark = false;
                LitCount++;
            }
        }
    }

    public static int TotalCount { get; private set; }
    public static int LitCount { get; private set; }
    public static int DarkCount => TotalCount - LitCount;

    // consume for progress indicator
    public static float Progress01 => (float)LitCount / (float)TotalCount;

    // consume for exit condition
    public static bool AllAreLit => LitCount == TotalCount;
}
