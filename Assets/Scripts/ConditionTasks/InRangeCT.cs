using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class InRangeCT : ConditionTask {

		public float detectRadius = 5f;
		public BBParameter<Transform> targetPos;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			Collider[] detectedColliders = Physics.OverlapSphere(agent.transform.position, detectRadius);
			foreach (var hitCollider in detectedColliders)
            {
				if (hitCollider != null)
                {
					if (hitCollider.tag != "Seed")
                    {
						targetPos.value = hitCollider.transform;
						return true;
					}
                }
            }
			return false;
		}
	}
}