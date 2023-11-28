using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhysicsPickup : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private TextMeshProUGUI rareText;
    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCam;
    [SerializeField] private Transform PickupTarget;
    [SerializeField] private float PickupRange;
    [SerializeField] private ScoreMenu scoreMenu;
    [SerializeField] private NoteDisplayer note;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickUp;
    [SerializeField] private AudioClip drop;
    [SerializeField] private AudioClip rareAudio;
    [SerializeField] private Animator shelf;
    [SerializeField] private Animator book;
    [SerializeField] private AudioSource libraryAudio;

    [Header("Etc")]
    private Rigidbody CurrentObject;
    public bool isFading = false;
    public bool iCanSeeNote = false;

    private RigidbodyConstraints initialConstraints;

    void Start()
    {
        initialConstraints = RigidbodyConstraints.None;
    }

    void Update()
    {
        RaycastHit HitInfo = new RaycastHit();

        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonUp(0))
        {
            if (CurrentObject)
            {
                CurrentObject.constraints = initialConstraints;
                CurrentObject.useGravity = true;
                CurrentObject = null;
                audioSource.PlayOneShot(drop);
                return;
            }

            Ray CameraRay = PlayerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out HitInfo, PickupRange, PickupMask))
            {
                if (HitInfo.transform.CompareTag("Rare1"))
                {
                    Destroy(HitInfo.transform.gameObject);
                    rareText.gameObject.SetActive(true);
                    isFading = true;
                    scoreMenu.artifact1Collected = true;
                }
                else if (HitInfo.transform.CompareTag("Rare2"))
                {
                    Destroy(HitInfo.transform.gameObject);
                    rareText.gameObject.SetActive(true);
                    isFading = true;
                    scoreMenu.artifact2Collected = true;
                }
                else if (HitInfo.transform.CompareTag("TutorialRare"))
                {
                    Destroy(HitInfo.transform.gameObject);
                    rareText.gameObject.SetActive(true);
                    isFading = true;
                }
                else if (HitInfo.transform.CompareTag("Note"))
                {
                    if (!note.iCanSeeIt)
                    {
                        note.ShowNote();
                        note.iAmBedroom = true;
                        note.isANote = true;
                    }
                }
                else if(HitInfo.transform.CompareTag("Note2"))
                {
                    if(!note.iCanSeeIt)
                    {
                        note.ShowNote();
                        note.iAmBedroom = false;
                        note.isANote = true;
                    }
                }
                else if(HitInfo.transform.CompareTag("Paper"))
                {
                    if(!note.iCanSeeIt)
                    {
                        note.ShowPaper();
                        note.isANote = false;
                    }
                }
                else if(HitInfo.transform.CompareTag("Book1"))
                {
                    if(!note.iCanSeeIt)
                    {
                        note.ShowBook();
                    }
                }
                else if(HitInfo.transform.CompareTag("Book2"))
                {
                    if(!note.iCanSeeIt)
                    {
                        note.ShowBook2();
                    }
                }
                else if(HitInfo.transform.CompareTag("Book3"))
                {
                    if(!note.iCanSeeIt)
                    {
                        note.ShowBook3();
                    }
                }       
                else if(HitInfo.transform.CompareTag("LegendaryBook"))
                {
                    shelf.SetBool("isMoving", true);
                    book.SetBool("isBooking", true);
                    libraryAudio.enabled = true;
                }                         

                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;

                initialConstraints = CurrentObject.constraints;

                CurrentObject.constraints = RigidbodyConstraints.FreezeRotation;

                if(HitInfo.transform.CompareTag("Rare1") || HitInfo.transform.CompareTag("Rare2"))
                {
                    audioSource.PlayOneShot(rareAudio);
                }
                else
                {
                    audioSource.PlayOneShot(pickUp);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
        }
    }

}