using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class characterManager : MonoBehaviour
 { 
     Vector3 movementDirection;
     [SerializeField] float speed;
     Vector3 characterPosition;
     int RoadIndex=0;
     int RoadSpace=3;
     bool alive = true;
     int score = 0;
     [SerializeField] AudioClip[] characterClips;
     private AudioSource audioSource;
     private Animator animator;
     // Start is called before the first frame update
     void Start()
     {
        animator = GetComponent <Animator>();
        audioSource = GetComponent <AudioSource>();
     }

     // Update is called once per frame
     void Update()
     { 
        if (alive)
         {
            movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 1);
            this.transform .Translate(movementDirection * Time. deltaTime * speed);

            characterPosition=this.transform.position;
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
             if(RoadIndex >-1)
             RoadIndex--;
            }
                 if(Input.GetKeyDown(KeyCode.RightArrow))
            {
             if(RoadIndex <1)
             RoadIndex++;
            }
        transform.position=new Vector3(RoadIndex * RoadSpace,characterPosition.y,characterPosition.z);
         }
}
private void OnCollisionEnter(Collision collision)
{
  if(collision. transform. CompareTag("enemy"))
  {
   alive = false;
   audioSource.clip = characterClips[1];
   audioSource. Play();
  }
}
private void OnTriggerEnter (Collider other)
{
   if (other. transform. CompareTag("coin"))
   {
        score++;
        Debug. Log("Score:" + score);
        Destroy(other.gameObject);
        audioSource. clip = characterClips[0];
        audioSource. Play();
       // animator. SetTrigger (name, Time.deltaTime);
   }
}
 }