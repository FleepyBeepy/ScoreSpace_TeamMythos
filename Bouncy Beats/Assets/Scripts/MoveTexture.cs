using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveTexture : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollSpeed;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveThis = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(0, moveThis);
    }
}
