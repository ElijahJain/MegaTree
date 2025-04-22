using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class MoveRandomAT : ActionTask {

		public BBParameter<NavMeshAgent> gardNMA;
		public float moveRange = 5f;
		private float arriveDistance = 0.5f;
		private Vector3 targetPos;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			Vector3 randomPos = Random.insideUnitSphere * moveRange + agent.transform.position;
			NavMeshHit hit;
			targetPos = agent.transform.position;
			if (NavMesh.SamplePosition(randomPos, out hit, moveRange, NavMesh.AllAreas))
            {
				targetPos = hit.position;
            }
			gardNMA.value.SetDestination(targetPos);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (Vector3.Distance(agent.transform.position, targetPos) <= arriveDistance)
            {
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}