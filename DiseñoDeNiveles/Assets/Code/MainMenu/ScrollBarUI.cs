using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ScrollBarUI : MonoBehaviour , ISelectHandler
{
    private ScrollRect scrollRect;
    private float scrollPosition = 1f;
    // Start is called before the first frame update
    void Start()
    {
        scrollRect = GetComponentInParent<ScrollRect>(true);
        int childCount = scrollRect.content.transform.childCount - 1;
        int childIndex = transform.GetSiblingIndex();
        childIndex = childIndex < ((float)childCount / 2f) ? childIndex - 1 : childIndex;
        scrollPosition = 1 - ((float)childIndex / childCount); 
    }

    public void OnSelect(BaseEventData eventData)
    {
        if(scrollRect)
            scrollRect.verticalScrollbar.value = scrollPosition;

    }

}
