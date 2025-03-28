using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelector : MonoBehaviour
{
    public GameObject cardPrefab; // Ïðåôàá êàðòû
    public Transform content; // Êîíòåéíåð äëÿ êàðò
    public string[] cardNames; // Íàçâàíèÿ êàðò
    public ScrollRect scrollRect; // Ññûëêà íà ScrollRect

    void LoadCards()
    {
        if (cardPrefab == null)
        {
            Debug.LogError("Card Prefab íå íàçíà÷åí!");
            return;
        }

        if (content == null)
        {
            Debug.LogError("Content íå íàçíà÷åí!");
            return;
        }

        foreach (var cardName in cardNames)
        {
            GameObject card = Instantiate(cardPrefab, content);

            // Ïîïðîáóåì ïîëó÷èòü êîìïîíåíò Text
            Text cardText = card.GetComponentInChildren<Text>();
            if (cardText != null)
            {
                cardText.text = cardName; // Óñòàíàâëèâàåì íàçâàíèå êàðòû, åñëè êîìïîíåíò íàéäåí
            }
            else
            {
                Debug.LogWarning("Êîìïîíåíò Text íå íàéäåí íà êàðòî÷êå: " + cardName);
            }

            Button button = card.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnCardSelected(cardName)); // Äîáàâëÿåì îáðàáîò÷èê íàæàòèÿ
            }

            // Äîáàâëÿåì îáðàáîò÷èêè ñîáûòèé äëÿ íàâåäåíèÿ ìûøè
            EventTrigger eventTrigger = card.AddComponent<EventTrigger>();
            EventTrigger.Entry entryPointerEnter = new EventTrigger.Entry();
            entryPointerEnter.eventID = EventTriggerType.PointerEnter;
            entryPointerEnter.callback.AddListener((data) => { OnPointerEnter(card); });
            eventTrigger.triggers.Add(entryPointerEnter);

            EventTrigger.Entry entryPointerExit = new EventTrigger.Entry();
            entryPointerExit.eventID = EventTriggerType.PointerExit;
            entryPointerExit.callback.AddListener((data) => { OnPointerExit(card); });
            eventTrigger.triggers.Add(entryPointerExit);
        }

        // Óñòàíàâëèâàåì ïîçèöèþ Scroll View, ÷òîáû ïåðâûé ýëåìåíò áûë â öåíòðå
        CenterScrollView();
    }

    void Update()
    {
        // Ïðîâåðÿåì, ïðîêðó÷èâàåòñÿ ëè êîëåñèêî ìûøè
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            // Ïðîêðó÷èâàåì ScrollRect â çàâèñèìîñòè îò ââîäà
            scrollRect.verticalNormalizedPosition += scrollInput;
        }
    }

    void CenterScrollView()
    {
        if (content.childCount > 0)
        {
            // Ïîëó÷àåì RectTransform ïåðâîãî ýëåìåíòà
            RectTransform firstCardRect = content.GetChild(0).GetComponent<RectTransform>();

            // Ïîëó÷àåì âûñîòó êîíòåíòà è âûñîòó êàðòî÷êè
            float contentHeight = content.GetComponent<RectTransform>().rect.height;
            float cardHeight = firstCardRect.rect.height;

            // Âû÷èñëÿåì öåëåâóþ ïîçèöèþ äëÿ öåíòðèðîâàíèÿ
            float targetPosition = (cardHeight / 2) - (contentHeight / 2);
            float scrollPosition = firstCardRect.anchoredPosition.y + targetPosition;

            // Óñòàíàâëèâàåì ïîçèöèþ ïðîêðóòêè
            scrollRect.content.anchoredPosition = new Vector2(scrollRect.content.anchoredPosition.x, scrollPosition);
        }
    }

    void OnCardSelected(string cardName)
    {
        Debug.Log("Âûáðàíà êàðòà: " + cardName);
    }

    void OnPointerEnter(GameObject card)
    {
        // Óâåëè÷èâàåì ðàçìåð êàðòî÷êè
        card.transform.localScale = new Vector3(1.7f, 1.7f, 1f);

        // Ñìåùàåì êàðòî÷êó âëåâî íà 10 åäèíèö (ìîæåòå èçìåíèòü ýòî çíà÷åíèå ïî ñâîåìó óñìîòðåíèþ)
        card.transform.localPosition += new Vector3(-180f, 0f, 0f);
    }

    void OnPointerExit(GameObject card)
    {
        // Âîçâðàùàåì ðàçìåð êàðòî÷êè
        card.transform.localScale = new Vector3(1f, 1f, 1f);

        // Âîçâðàùàåì êàðòî÷êó íà èñõîäíóþ ïîçèöèþ
        card.transform.localPosition -= new Vector3(-180f, 0f, 0f);
    }
}