using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // هدف (کاراکتر) که دوربین باید آن را دنبال کند
    public float smoothSpeed = 0.125f; // سرعت نرم حرکت دوربین
    public Vector3 offset; // اختلاف موقعیت بین دوربین و هدف

    void LateUpdate()
    {
        // هدف جدید برای موقعیت دوربین محاسبه می‌شود
        Vector3 desiredPosition = target.position + offset;
        // موقعیت دوربین با استفاده از فیلتر نرم (smooth) محاسبه می‌شود
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // موقعیت دوربین به موقعیت صاف شده تغییر می‌کند
        transform.position = smoothedPosition;

        // اگر می‌خواهید دوربین همیشه به سمت هدف نگاه کند
        transform.LookAt(target);
    }
}