﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;

    public float horizontalBoundary = 22;

    public GameObject hayBalePrefab; // 1
    public Transform haySpawnpoint; // 2
    public float shootInterval; // 3
    private float shootTimer; // 4

    public Transform ModelParent; 

    public GameObject BlueModelPrefab;
    public GameObject YellowModelPrefab;
    public GameObject RedModelPrefab;

    void Start()
    {
        LoadModel();
    }
    private void LoadModel()
    {
        Destroy(ModelParent.GetChild(0).gameObject); // 1

        switch (GameSettings.hayMachineColor) // 2
        {
            case HayMachineColor.Blue:
                Instantiate(BlueModelPrefab, ModelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(YellowModelPrefab, ModelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(RedModelPrefab, ModelParent);
                break;
        }
    }
    // Update is called once per frame
    private void Update()
    {
        UpdateMovement();
        UpdateShooting();
    }

    private void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // 1

        if (horizontalInput < 0 && transform.position.x > -horizontalBoundary) // 1
        {
            transform.Translate(transform.right * -movementSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0 && transform.position.x < horizontalBoundary) // 2
        {
            transform.Translate(transform.right * movementSpeed * Time.deltaTime);
        }
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            ShootHay();
        }
    }

    private void ShootHay()
    {
        Instantiate(hayBalePrefab, haySpawnpoint.position, Quaternion.identity);
        SoundManager.Instance.PlayShootClip();
    }
}