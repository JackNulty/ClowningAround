using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescaler : MonoBehaviour
{
    [Header("Settings")]
    public Vector2 scale;
    public Vector2 colliderOffset;
    [Header("References")]
    public SpriteRenderer sprite;

    public BoxCollider2D collider;
    private void OnValidate()
    {
        sprite.size = new Vector2(scale.x, scale.y);
        collider.size = new Vector2(scale.x - colliderOffset.x, scale.y - colliderOffset.y);
    }
}
