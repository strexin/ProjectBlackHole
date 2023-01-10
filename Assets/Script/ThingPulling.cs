using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingPulling : MonoBehaviour
{
    [SerializeField] private float pullSpeed;
    [SerializeField] private float pullDivided;
    private Vector3 dist;

    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = (gameObject.transform.position - player.transform.position);
        player.transform.position += (dist.normalized * pullSpeed) / pullDivided;
    }
}
