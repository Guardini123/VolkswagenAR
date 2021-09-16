using UnityEngine;

public class DistanceMark : MonoBehaviour
{
    [SerializeField] Transform target;

    [SerializeField] Material focus;
    [SerializeField] Material standart;

    [SerializeField] LocalTaskCompleted task;
    [SerializeField] int id;

    [Header("Расстояние (м), на котором задание считается выполненным")]
    public float distanceCompleted;

    bool change = false;
    float distance;

    public void DistanceChange()
    {
        distance = Vector3.Distance(transform.position, target.position);
        //Debug.Log(distance);
        if (distance < distanceCompleted)
        {
            if (change)
            {
                GetComponent<Renderer>().material = focus;
                target.GetComponent<Renderer>().material = focus;
                task.PartTaskCompleted(id, change);
                change = false;
            }
        }
        else
        {
            if (!change)
            {
                GetComponent<Renderer>().material = standart;
                target.GetComponent<Renderer>().material = standart;
                task.PartTaskCompleted(id, change);
                change = true;
            }
        }
    }

    public void RestartDistance()
    {
        GetComponent<Renderer>().material = standart;
        target.GetComponent<Renderer>().material = standart;
    }
}
