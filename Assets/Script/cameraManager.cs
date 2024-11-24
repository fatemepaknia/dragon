using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    
     public Transform target; // هدف (کاراکتر) که دوربین باید آن را دنبال کند
     public float smoothSpeed = 0.125f; // سرعت نرم حرکت دوربین
     public float offsetZ = 10f; // فاصله دوربین از کاراکتر در محور Z

    // Start is called before the first frame update


    // Update is called once per frame
    void LateUpdate()
    {
        float desiredZ = target.position.z + offsetZ;
        
        // موقعیت دوربین با استفاده از فیلتر نرم در محور Z محاسبه می‌شود
        Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, desiredZ);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // موقعیت دوربین به موقعیت صاف شده تغییر می‌کند
        transform.position = smoothedPosition;

        // اگر می‌خواهید دوربین همیشه به سمت هدف نگاه کند
        transform.LookAt(target);
    }
}
