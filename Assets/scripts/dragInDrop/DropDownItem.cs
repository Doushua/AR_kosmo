using UnityEngine;

public class DropDownItem : MonoBehaviour
{
    public GameObject itemTemplate { get; private set; }

    public void Construct(GameObject instant)
    {
        itemTemplate = instant;
    }
}
