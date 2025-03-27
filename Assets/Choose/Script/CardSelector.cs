using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelector : MonoBehaviour
{
    public GameObject cardPrefab; // Префаб карты
    public Transform content; // Контейнер для карт
    public string[] cardNames; // Названия карт

    void LoadCards()
    {
        if (cardPrefab == null)
        {
            Debug.LogError("Card Prefab не назначен!");
            return;
        }

        if (content == null)
        {
            Debug.LogError("Content не назначен!");
            return;
        }

        foreach (var cardName in cardNames)
        {
            GameObject card = Instantiate(cardPrefab, content);

            // Попробуем получить компонент Text
            Text cardText = card.GetComponentInChildren<Text>();
            if (cardText != null)
            {
                cardText.text = cardName; // Устанавливаем название карты, если компонент найден
            }
            else
            {
                Debug.LogWarning("Компонент Text не найден на карточке: " + cardName);
            }

            Button button = card.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnCardSelected(cardName)); // Добавляем обработчик нажатия
            }

            // Добавляем обработчики событий для наведения мыши
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
    }

    void OnCardSelected(string cardName)
    {
        Debug.Log("Выбрана карта: " + cardName);
    }

    void OnPointerEnter(GameObject card)
    {
        card.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f); // Увеличиваем размер
    }

    void OnPointerExit(GameObject card)
    {
        card.transform.localScale = new Vector3(1f, 1f, 1f); // Возвращаем размер
    }
}