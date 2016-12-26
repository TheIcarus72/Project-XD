using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform targetOne;                                    // target to aim for
		public Transform targetTwo;                                    // target to aim for
		public GameObject gameControl;
		GameController gameController;


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
			gameController = gameControl.GetComponent<GameController>();
        }


        private void Update()
        {
			if(gameController.inOptions == false){
				if (targetOne != null)
					agent.SetDestination(targetOne.position);
				else if(targetTwo != null)
					agent.SetDestination(targetTwo.position);
			} else if (gameController.inOptions == true){
				if (targetTwo != null)
					agent.SetDestination(targetTwo.position);
				else if(targetOne != null)
					agent.SetDestination(targetOne.position);
			}

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }

    }
}
