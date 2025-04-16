using System;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectibleType type;
    public float heightOffset;
    public Int32 beat;
    public float offset;
    public int Value;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

#if UNITY_EDITOR
    private void OnValidate() => UnityEditor.EditorApplication.delayCall += _OnValidate;

    private void _OnValidate()
    {
        UnityEditor.EditorApplication.delayCall -= _OnValidate;
        if (this == null) return;

        if (transform.parent != null)
        {
            CollectibleCreator creator = transform.parent.GetComponent<CollectibleCreator>();
            if (creator != null)
            {
                creator.updateCollectible(this);
            }
        }
    }
#endif

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (type == CollectibleType.Coin || type == CollectibleType.Obstacles)
            {
                ScoreManager.instance.Addpoint(Value);
                Destroy(gameObject);
            }
            else if (type == CollectibleType.PowerUp)
            {
                PowerUp.instance.Change();
                Destroy(gameObject);
            }
        }
    }
}


public enum CollectibleType { 
    Coin,
    PowerUp,
    Obstacles
};
