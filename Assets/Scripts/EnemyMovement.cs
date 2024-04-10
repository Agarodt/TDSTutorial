using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{       
        bool chase;
   
		public Transform[] targets;

		public float delay = 0;

		int index;

		IAstarAI agent;

		float switchTime = float.PositiveInfinity;

        GameObject Player;

        Transform playerPos;

        FOV fov;

		EnemyHP HP;






		void Awake () 
        {
			agent = GetComponent<IAstarAI>();
			HP = GetComponent<EnemyHP>();

		}

        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            fov = GetComponent<FOV>();
        }

		void Update () 
        {
		    if(!HP.dead)
			{
			if (Player == null)
			{
				Player = GameObject.FindGameObjectWithTag("Player");
			}
			
            chase = fov.chase;
            playerPos = Player.transform;

            if (!chase)
            {
			if (targets.Length == 0) return;

			bool search = false;

			if (agent.reachedEndOfPath && !agent.pathPending && float.IsPositiveInfinity(switchTime)) {
				switchTime = Time.time + delay;
			}

			if (Time.time >= switchTime) {
				index = index + 1;
				search = true;
				switchTime = float.PositiveInfinity;
			}

			index = index % targets.Length;
			agent.destination = targets[index].position;

			if (search) agent.SearchPath();
            }
            if (chase)
            {
                agent.destination = playerPos.position;
            }
			}

			if (HP.dead)
			{
				agent.destination = transform.position;
			}
		}
			

	
		}

      
   
	

