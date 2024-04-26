using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SwipeController : MonoBehaviour,IEndDragHandler
{ 

    [SerializeField] int maxPage;
    [SerializeField] Image[] barImages;
    [SerializeField] Sprite barClose, barOpen;
    [SerializeField] Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;
    [SerializeField] float tweenTime;
    [SerializeField] LeanTweenType tweenType;
    [SerializeField] Button previousButton,nextButton;
    float dragTreshold;
    int currentPage;
    Vector3 targetPosition;

    private void Awake()
    {
        currentPage = 1;
        targetPosition = levelPagesRect.localPosition;
        dragTreshold = Screen.width / 15;
        UpdateBar();
        UpdateArrowButtons();
    }

    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPosition += pageStep;
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentPage>1)
        {
            currentPage--;
            targetPosition -= pageStep;
            MovePage();
        }
    }

    void MovePage()
    {
        levelPagesRect.LeanMoveLocal(targetPosition, tweenTime).setEase(tweenType);
        UpdateBar();
        UpdateArrowButtons();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.position.x-eventData.pressPosition.x)>dragTreshold)
        {
            if (eventData.position.x > eventData.pressPosition.x)  Previous();
            else  Next();
        }
        else MovePage();
    }

    void UpdateBar()
    {
        foreach (var bar in barImages)
        {
            bar.sprite = barClose;
        }
        barImages[currentPage - 1].sprite = barOpen;
    }

    void UpdateArrowButtons()
    {
        previousButton.interactable = true;
        nextButton.interactable = true;
        if (currentPage==1)
        {
            previousButton.interactable = false;
        }
        else if (currentPage==maxPage)
        {
            nextButton.interactable = false;
        }
    }
}
