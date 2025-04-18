using System.Linq;
using UnityEngine;
using UnityEngine.VFX;
public class ActivateExplosion : MonoBehaviour
{

    public ParticleSystem[] particleToPlay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach (var ps in particleToPlay)
            {
                if(ps != null)
                {
                    ps.Play();
                }
            }
        }
    }
}
