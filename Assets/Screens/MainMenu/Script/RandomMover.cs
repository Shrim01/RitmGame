using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMover : MonoBehaviour
{
    public float moveSpeed = 1f; // Скорость движения
    public float rotationSpeed = 50f; // Скорость вращения
    private Vector2 direction;

    void Start()
    {
        // Задаем случайное направление
        direction = Random.insideUnitCircle.normalized;
    }

    void Update()
    {
        // Двигаем объект
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Вращаем объект
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        // Проверяем столкновение с границами экрана
        if (transform.position.x < -Screen.width / 2 || transform.position.x > Screen.width / 2 ||
            transform.position.y < -Screen.height / 2 || transform.position.y > Screen.height / 2)
        {
            // Отталкиваем в случайном направлении
            direction = Random.insideUnitCircle.normalized;
            // Перемещаем объект немного внутрь экрана, чтобы избежать застревания
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -Screen.width / 2 + 1, Screen.width / 2 - 1),
                                              Mathf.Clamp(transform.position.y, -Screen.height / 2 + 1, Screen.height / 2 - 1));
        }
    }
}