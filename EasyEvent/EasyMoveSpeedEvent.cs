using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Тип измеряемой скорости
/// </summary>
public enum SpeedType // Создаем выбор типа измеряемой скорости для инспектора.
{
    AnySpeed, // Любая скорость.
    XSpeed, // Вычисляем скорость только по оси X.
    YSpeed, // Вычисляем скорость только по оси Y.
    ZSpeed // Вычисляем скорость только по оси Z.
}
/// <summary>
/// Тип сравнения значений скорости
/// </summary>
public enum ComparisonType // Создаем выбор типа сравнения значений скорости для инспектора.
{
    Larger, // Больше.
    Less // Меньше.
}
public class EasyMoveSpeedEvent : MonoBehaviour
{
    Vector3 LastPosition; // Последняя позиция объекта. Нужна, для вычета из текущей и из полученной разницы вычесления скорости.
    float CurrentSpeed; // Текущая позиция объекта.

    [Tooltip("Тип измеряемой скорости. \nЛюбая скорость / по оси X / по оси Y / по оси Z")]
    public SpeedType speedType = SpeedType.AnySpeed;
    [Tooltip("Скорость, которая требуется для срабатывания события")]
    public float SpeedToEvent;
    [Tooltip("Тип сравнения текущей скорости и SpeedToEvent.\nБольше или меньше")]
    public ComparisonType comparisonType = ComparisonType.Larger;
    [Tooltip("События, выполняющиеся при выполнении заданных параметров")]
    public UnityEvent Events; // События
    public bool isEventActivate; // Проверка активированно ли событие.

    [Tooltip("Печатать текущую скорость в консоль")]
    public bool debugPrintCurrentSpeed;

    void Start()
    {

    }
    private void FixedUpdate()
    {
        if (speedType == SpeedType.AnySpeed) // Если тип измеряемой скорости = любая скорость,
        {
            CurrentSpeed = (transform.position - LastPosition).magnitude * 10; // Вычисляем текущую скорость объекта. (домножаем на 10 для удобства, иначе слишком маленькие значения)
            LastPosition = transform.position; // Приравниваем переменную последней позиции к текущей позиции. (В следующем кадре она станет предыдущей позицией)
            _event(); // Запускаем метод, в котором прописаны действия, которые одинаковы для всех случаев запуска события.
        }

        if(speedType == SpeedType.XSpeed) // Если тип измеряемой скорости = измерение скорости только по X, то выполняем следующие действия.
        {
            CurrentSpeed = (transform.position.x - LastPosition.x) * 10; // Вычисляем текущую скорость объекта. (домножаем на 10 для удобства, иначе слишком маленькие значения)
            LastPosition = transform.position; // Приравниваем переменную последней позиции к текущей позиции. (В следующем кадре она станет предыдущей позицией)
            _event(); // Запускаем метод, в котором прописаны действия, которые одинаковы для всех случаев запуска события.
        }

        if (speedType == SpeedType.YSpeed) // Если тип измеряемой скорости = измерение скорости только по Y, то выполняем следующие действия.
        {
            CurrentSpeed = (transform.position.y - LastPosition.y) * 10; // Вычисляем текущую скорость объекта. (домножаем на 10 для удобства, иначе слишком маленькие значения)
            LastPosition = transform.position; // Приравниваем переменную последней позиции к текущей позиции. (В следующем кадре она станет предыдущей позицией)
            _event(); // Запускаем метод, в котором прописаны действия, которые одинаковы для всех случаев запуска события.
        }

        if (speedType == SpeedType.ZSpeed) // Если тип измеряемой скорости = измерение скорости только по Z, то выполняем следующие действия.
        {
            CurrentSpeed = (transform.position.z - LastPosition.z) * 10; // Вычисляем текущую скорость объекта. (домножаем на 10 для удобства, иначе слишком маленькие значения)
            LastPosition = transform.position; // Приравниваем переменную последней позиции к текущей позиции. (В следующем кадре она станет предыдущей позицией)
            _event(); // Запускаем метод, в котором прописаны действия, которые одинаковы для всех случаев запуска события.
        }

        if (debugPrintCurrentSpeed)
        {
            print("Current speed " + CurrentSpeed);
        }
    }


    void _event() // Метод запуска события.
    {
        if (comparisonType == ComparisonType.Larger) // Если тип сравнения текущей скорости = больше, выполняем следующие действия.
        {
            if (CurrentSpeed > SpeedToEvent) // Если текущая скорость больше скорости которая требуется для запуска события,
            {
                if (!isEventActivate) // Если событие еще не запущено,
                {
                    Events.Invoke(); // Запускаем событие.
                    isEventActivate = true; // Записываем, что событие запущено.
                    print(CurrentSpeed);
                }
            }
            if (isEventActivate) // Когда событие запущено,
            {
                if (CurrentSpeed < SpeedToEvent /*- 0.3f*/) // Сравниваем скорость, если она меньше той, которая нужна для события, значит можно запускать событие снова.
                {
                    isEventActivate = false; // Пишем, что событие не активно, что бы оно могло запуститься снова при достижении нужной скорости.
                }
            }
        }
        if (comparisonType == ComparisonType.Less) // Если тип сравнения текущей скорости = меньше,
        {
            if (CurrentSpeed < SpeedToEvent) // Если текущая скорость меньше скорости которая требуется для запуска события,
            {
                if (!isEventActivate) // Если событие еще не запущено,
                {
                    Events.Invoke(); // Запускаем событие.
                    isEventActivate = true; // Записываем, что событие запущено.
                    //print("!!!");
                }
            }
            if (isEventActivate) // Когда событие запущено,
            {
                if (CurrentSpeed < SpeedToEvent /*+ 0.3f*/) // Сравниваем скорость, если она больше той, которая нужна для события, значит можно запускать событие снова.
                {
                    isEventActivate = false; // Пишем, что событие не активно, что бы оно могло запуститься снова при достижении нужной скорости.
                }
            }
        }
    }
}