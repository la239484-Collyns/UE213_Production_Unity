using TMPro;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public static PowerUp instance;
    MeshFilter Original;

    public Mesh Plane;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().sharedMesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change(){
        Original.mesh = Plane;
    }
}
