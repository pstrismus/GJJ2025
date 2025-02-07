using System.Collections.Generic;
using UnityEngine;

public class GostergeMove : MonoBehaviour
{
    [SerializeField] List<RectTransform> uiElements; 
    [SerializeField] float moveSpeed = 50f; 
    private float resetPosY = -32.7411f; 
    private float thresholdPosY = 65.58012f;   

    void Update()
    {
        MoveElements();
        CheckAndReorder();
    }

    void MoveElements()
    {
        foreach (var element in uiElements)
        {
            element.anchoredPosition += Vector2.up * moveSpeed * Time.deltaTime;
        }
    }

    void CheckAndReorder()
    {
        if (uiElements.Count > 0 && uiElements[0].anchoredPosition.y >= thresholdPosY)
        {
            RectTransform firstElement = uiElements[0];

            uiElements.RemoveAt(0);
            uiElements.Add(firstElement);

            Vector2 newPos = firstElement.anchoredPosition;
            newPos.y = resetPosY;
            firstElement.anchoredPosition = newPos;
        }
    }
}
