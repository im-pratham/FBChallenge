using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticle : MonoBehaviour, IHitable {

	public ParticleSystem particle;

	public void Hit() 
	{
		particle.Play ();
	}
}
