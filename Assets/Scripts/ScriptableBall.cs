using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBall", menuName = "Ball")]
public class ScriptableBall : ScriptableObject
{
    public string name;
    [SerializeField] private bool isInteract;
    [SerializeField] private Material material;
    [SerializeField] private LayerMask layer;
    [SerializeField] private Collider collider;
        
    public Material GetMaterial
    {
        get { return material; }
        set { value = material; }
    }
    public bool GetInteractiveValue
    {
        get { return isInteract; }
        set { value = isInteract; }
    }
}
