using System.Collections.Generic;
using UnityEngine;

public class RotateObjScript : MonoBehaviour
{
    Camera cam;
    Vector3 target;

    #region Rotation
    int turnNumber = 0;
    float startAnglePoint = 0;
    float anglePoint = 0;
    float oldDelta = 0;
    float delta = 0;

    [Header("Стартовый угол")]
    [SerializeField] float startAngleWheel = 0;
    float angleWheel = 0;

    [Header("Связан с объектами")]
    [SerializeField] RotateObjScript[] RelatedObj;
    [Header("Отношение скоростей вращения")]
    [SerializeField] float denominator = 2;
    List<DistanceMark> DistanceList = new List<DistanceMark>();
    #endregion

    #region Sprite
    [Header("Sprite")]
    [SerializeField] Sprite right;
    [SerializeField] Sprite left;
    SpriteRenderer spriteRenderer;
    float oldAngleWheel = 0;
    int dirSprite = 0;
    int countSpriteUpdate = 0;
    #endregion 

    private void Awake()
    {
        cam = Camera.main;
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        foreach (Transform child in transform)
        {
            if(child.GetComponent<DistanceMark>() != null)
                DistanceList.Add(child.GetComponent<DistanceMark>());
        }
    }

    private void OnMouseDown()
    {
        target = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
        target = new Vector3(target.x, target.y, transform.position.z);

        startAnglePoint = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        startAngleWheel = transform.localEulerAngles.z;

        oldAngleWheel = startAngleWheel;
        oldDelta = 0;
        turnNumber = 0;
        dirSprite = 0;
        countSpriteUpdate = 0;

        for (int i = 0; i < RelatedObj.Length; i++)
            RelatedObj[i].UpdateStartAngle();
    }

    void OnMouseDrag()
    {
        if (!Input.GetMouseButton(0))
            return;

        // ищем угол на который сместился курсор с момента нажатия
        target = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
        target = new Vector3(target.x, target.y, transform.localPosition.z);

        anglePoint = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;

        delta = anglePoint - startAnglePoint;

        if (delta > 180)
            delta -= 360;
        else if (delta < -180)
            delta += 360;

        // считаем обороты
        if ((delta > 90) && (oldDelta < -90))
            turnNumber--;
        else if ((delta < -90) && (oldDelta > 90))
            turnNumber++;

        oldDelta = delta;

        // ищем и задаем поворот колеса
        angleWheel = turnNumber * 360 + delta + startAngleWheel;
        transform.localEulerAngles = new Vector3(0, 0, angleWheel);

        // направление поворота - изменить спрайт
        UpdateSprite(angleWheel);


        // обновить поворот связанных колес
        for (int i = 0; i < RelatedObj.Length; i++)
            RelatedObj[i].UpdateRotRelatedObj((turnNumber * 360 + delta) / denominator);

        // найти новое расстояние между метками
        for (int i = 0; i < DistanceList.Count; i++)
            DistanceList[i].DistanceChange();
    }

    public void UpdateStartAngle()
    {
        startAngleWheel = transform.localEulerAngles.z;
        oldAngleWheel = startAngleWheel;
    }

    public void UpdateRotRelatedObj(float _angleWheel)
    {
        angleWheel = _angleWheel + startAngleWheel;
        transform.localEulerAngles = new Vector3(0, 0, angleWheel);

        UpdateSprite(angleWheel);

        for (int i = 0; i < DistanceList.Count; i++)
            DistanceList[i].DistanceChange();
    }

    void UpdateSprite(float currentAngle)
    {
        countSpriteUpdate++;
        if (countSpriteUpdate == 30)
        {
            if (oldAngleWheel < currentAngle)
            {
                spriteRenderer.sprite = left;
                spriteRenderer.transform.localEulerAngles = new Vector3(0, 0, -90);
            }
            else if (oldAngleWheel == currentAngle)
            { }
            else
            {
                spriteRenderer.sprite = right;
                spriteRenderer.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
            countSpriteUpdate = 0;
            oldAngleWheel = currentAngle;
        }
    }

    public void RestartPos()
    {
        Debug.Log("Become command restart position " + gameObject.name);
        transform.localEulerAngles = Vector3.zero;

        if (RelatedObj.Length > 1)
        {
            foreach (RotateObjScript obj in RelatedObj)
                obj.RestartPos();
        }

        for (int i = 0; i < DistanceList.Count; i++)
             DistanceList[i].RestartDistance();
    }
}
