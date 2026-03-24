using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TileController : MonoBehaviour
{
    [SerializeField] private TileType tileType;
    public bool isInstante;
}
