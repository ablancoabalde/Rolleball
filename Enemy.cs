using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private GameObject enemigo;


    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        enemigo = GameObject.Find("Enemy");
        // Desactivar el frenado automático permite un movimiento continuo
        // entre puntos (es decir, el agente no disminuye la velocidad ya que
        // se acerca a un punto de destino).
        agent.autoBraking = false;
       
        GotoNextPoint();
    }
	
	
	void Update () {
        // Elija el siguiente punto de destino cuando el agente reciba
        // cerca del actual.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            
        GotoNextPoint(); 
        else
            enemigo.transform.position = new Vector3(-4.26F, 5.0164F, 7.018F);

    }

    void GotoNextPoint()
    {
        // Devuelve si no se han configurado puntos
        if (points.Length == 0) 
            
        return;

        // Configurar el agente para ir al destino seleccionado actualmente.
        agent.destination = points[destPoint].position;

        // Elegir el siguiente punto de la matriz como destino,
        // ciclando al inicio si es necesario.
        destPoint = (destPoint +1) % points.Length;
    }

}
