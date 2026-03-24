using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DragInDropSystem : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private InputActionProperty positionI;
    [SerializeField] private GameObject instant;
    [SerializeField] private Vector2 position;

    public void BeginDrag(BaseEventData eventData)
    {
        if (eventData.selectedObject.TryGetComponent(out DropDownItem item))
        {
            positionI.action.Enable();
            
            instant = Instantiate(item.itemTemplate);
        }
        
    }

    public void EndDrag()
    {
        position = positionI.action.ReadValue<Vector2>();

        if (instant != null)
        {
            var ray = Camera.main.ScreenPointToRay(position);
            if (Physics.Raycast(ray, out var hit, 10, layerMask))
            {
                if (hit.collider.TryGetComponent(out TileController tile))
                    tile.isInstante = true;
            }
        }
        positionI.action.Disable();
    }

    public void OnDrag()
    {
        position = positionI.action.ReadValue<Vector2>();

        if (instant != null)
        {
            var ray = Camera.main.ScreenPointToRay(position);
            if (Physics.Raycast(ray, out var hit, 10,  layerMask))
            {
                if(hit.collider.TryGetComponent(out TileController tile))
                {
                    if (!tile.isInstante)
                    {
                        instant.transform.position = hit.collider.gameObject.transform.position;
                    }
                }
            }
        }
    }
}
