﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyScript : MonoBehaviour
{
    public KeyCode keyCode;
    private float originalY;
    public float speed = 1;
    private KeyboardSoundPlayer keyboardSoundPlayer;

    public bool IsRemoved => removed;
    private bool removed;
    private MeshRenderer renderer;
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        renderer = GetComponent<MeshRenderer>();
        originalY = transform.position.y;
        keyboardSoundPlayer = GameObject.FindObjectOfType<KeyboardSoundPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyCode))
        {
            StartCoroutine(keyboardSoundPlayer.PlayKeyAudioasd());
            StartCoroutine(PressMove(originalY-0.06f));
        }
        if(Input.GetKeyUp(keyCode))
        {
            StartCoroutine(PressMove(originalY));
        }
    }

    public KeyCode Take()
    {
        renderer.enabled = false;
        canvas.gameObject.SetActive(false);
        removed = true;
        return keyCode;
    }

    public void Put()
    {
        canvas.gameObject.SetActive(true);
        removed = false;
        renderer.enabled = true;
    }

    public IEnumerator PressMove(float targetY)
    {
        float startY = transform.position.y;
        float dir = targetY < transform.position.y ? -1 : 1;

        if(targetY < transform.position.y )
        {
            while(transform.position.y > targetY)
            {
                transform.position += transform.up * Time.deltaTime * speed * dir;
            }
        }
        else
        {
            while(transform.position.y < targetY)
            {
                transform.position += transform.up * Time.deltaTime * speed * dir;
            }
        }

        yield return null;
    }
}
