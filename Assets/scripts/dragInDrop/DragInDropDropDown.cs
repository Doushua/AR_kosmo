using TMPro;
using UnityEngine;

public class DragInDropDropDown : TMP_Dropdown
{
    private int count = 0;
    public GameObject[] itemsPrefab;
    
    protected override DropdownItem CreateItem(DropdownItem itemTemplate)
    {
        if (itemTemplate.gameObject.TryGetComponent(out DropDownItem item))
        {
            item.Construct(itemsPrefab[count]);
            count++;
        }
        
        return base.CreateItem(itemTemplate);
    }

    protected override void DestroyDropdownList(GameObject dropdownList)
    {
        count = 0;
        base.DestroyDropdownList(dropdownList);
    }
}
