using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour, IOpenable
{
    [SerializeField] private Transform door;
    [SerializeField] private float closingSpeed;

    private bool isClosed;
    private bool isClosing;
    private bool isOpen;
    private bool isOpening;

    private Coroutine openCoroutine;
    private Coroutine closeCoroutine;

    private float _currentScale;
    private float currentScale
    {
        get => _currentScale;

        set
        {
            _currentScale = value;
            Vector3 scale = door.localScale;
            scale.y = value;

            door.localScale = scale;
        }
    }

    private void Awake()
    {
        currentScale = 1f;
        isClosed = true;
    }

    public void Close()
    {
        if (isClosing || isClosed) return;

        if (openCoroutine != null)
        {
            StopCoroutine(openCoroutine);
            isOpening = false;
            openCoroutine = null;
        }

        closeCoroutine = StartCoroutine(CloseCO());
    }

    public void Open()
    {
        if (isOpening || isOpen) return;

        if (closeCoroutine != null)
        {
            StopCoroutine(closeCoroutine);
            isClosing = false;
            closeCoroutine = null;
        }

        openCoroutine = StartCoroutine(OpenCO());
    }

    IEnumerator CloseCO()
    {
        isOpen = false;
        isClosing = true;
        door.gameObject.SetActive(true);
        do
        {
            currentScale += closingSpeed * Time.deltaTime;

            yield return null;
        } while (currentScale < 1);

        currentScale = 1;


        isClosed = true;


        isClosing = false;
    }

    IEnumerator OpenCO()
    {
        isClosed = false;
        isOpening = true;
        do
        {
            currentScale -= closingSpeed * Time.deltaTime;

            yield return null;
        } while (currentScale > 0);

        currentScale = 0;

        door.gameObject.SetActive(false);


        isOpening = false;
        isOpen = true;
    }
}
