
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
 
    public GameObject player;
    public GameObject referencia;
    private Vector3 distancia;

    // Use this for initialization
    void Start()
    {
        distancia = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
       distancia=Quaternion.AngleAxis (Input.GetAxis("Mouse X")* 2, Vector3.up)*distancia;

        transform.position = player.transform.position + distancia;
        transform.LookAt(player.transform.position);

        // Referencia para que los controles no cambien
        Vector3 copiaRotacion = new Vector3(0, transform.eulerAngles.y,0);
        referencia.transform.eulerAngles = copiaRotacion;
    }




}