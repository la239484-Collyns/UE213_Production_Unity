using UnityEngine;

public class RandomMaterialApplier : MonoBehaviour
{
    public Material[] materials;
    public Renderer targetRenderer;

    void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        if (targetRenderer == null)
        {
            targetRenderer = GetComponentInChildren<Renderer>();
        }

        if (materials.Length > 0 && targetRenderer != null)
        {
            Material randomMat = materials[Random.Range(0, materials.Length)];
            targetRenderer.material = randomMat;
        }
    }
}
