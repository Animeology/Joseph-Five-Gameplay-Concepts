using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlyphSpawner : MonoBehaviour
{
    public GameObject glyphPrefab;
    public float SpawnTimer = 0.01f;
    public GameObject playerGO;
    public float rainHeight = 0;
    public float initialDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNextGlyph());
    }
    
    void SpawnGlyph()
    {
        Vector3 rainPos = playerGO.transform.position;
        rainPos.y += rainHeight;

        GameObject.Instantiate(
            glyphPrefab, 
            rainPos, 
            transform.rotation
        );
    }


    IEnumerator SpawnNextGlyph()
    {
        yield return new WaitForSeconds(initialDelay);
        while (true)
        {
            SpawnGlyph();
            yield return new WaitForSeconds(SpawnTimer);
        }
    }
}
