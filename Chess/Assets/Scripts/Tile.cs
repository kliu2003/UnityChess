using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Color whenHover;
    Color whenNotHover;
    MeshRenderer tileMesh;

    void Start()
    {
        tileMesh = GetComponent<MeshRenderer>();
        whenHover = Color.cyan;
        whenNotHover = tileMesh.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
        tileMesh.material.color = whenHover;
    }
    void OnMouseExit()
    {
        tileMesh.material.color = whenNotHover;
    }
}
