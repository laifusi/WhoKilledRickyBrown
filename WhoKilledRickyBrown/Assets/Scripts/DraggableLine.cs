using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DraggableLine : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] DraggableLine linePrefab;
    public GameObject deleteButton;

    [HideInInspector] public bool successfulDrop;
    [HideInInspector] public DraggableLine originalLine;

    DraggableLine copyLine;
    TMP_Text copyText;
    Canvas canvas;
    RectTransform myRT;
    Transform newParent;
    TMP_Text myText;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        myRT = GetComponent<RectTransform>();
        deleteButton.SetActive(false);
        myText = GetComponent<TMP_Text>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (successfulDrop)
            return;

        copyLine = Instantiate(linePrefab, canvas.transform);
        copyLine.GetComponent<RectTransform>().sizeDelta = myRT.sizeDelta;
        copyText = copyLine.GetComponent<TMP_Text>();
        copyLine.originalLine = this;
        copyText.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (successfulDrop)
            return;

        copyLine.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (successfulDrop)
            return;

        copyText.raycastTarget = true;
        if (newParent != null)
        {
            copyLine.transform.SetParent(newParent);
            copyLine.successfulDrop = true;
            copyLine.deleteButton.SetActive(true);
            copyLine.ActivateDeleteButton();
            newParent = null;
            successfulDrop = true;
            RepaintLine(0.5f);
        }
        else
        {
            Destroy(copyLine.gameObject);
        }
    }

    public void SetNewParent(Transform parent)
    {
        newParent = parent;
    }

    public void ActivateDeleteButton()
    {
        deleteButton.SetActive(true);
    }

    public void ReactivateOriginalPosition()
    {
        originalLine.successfulDrop = false;
        originalLine.RepaintLine(1f);
        Destroy(gameObject);
    }

    public void RepaintLine(float alpha)
    {
        myText.alpha = alpha;
    }
}
