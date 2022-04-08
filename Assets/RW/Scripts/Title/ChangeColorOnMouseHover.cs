using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeColorOnMouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MeshRenderer Model;
    public Color NormalColor;
    public Color HoverColor;
    // Start is called before the first frame update
    void Start()
    {
        Model.material.color = NormalColor;
    }

    public void OnPointerEnter(PointerEventData EventData)
    {
        Model.material.color = HoverColor;
    }

    public void OnPointerExit(PointerEventData EventDate)
    {
        Model.material.color = NormalColor;
    }
}
