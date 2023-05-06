using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollition : MonoBehaviour
{
    Cube cube;
    [SerializeField] private AudioClip collisionSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        cube = GetComponent<Cube>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Cube otheCube = collision.gameObject.GetComponent<Cube>();
        
        // cherck if contacted with other cube
        if(otheCube != null && cube.CubeID > otheCube.CubeID)
        {
            // check if both cubes have same number
            if(cube.CubeNumber == otheCube.CubeNumber)
            {
                Vector3 contactPoint = collision.contacts[0].point;

                /*//play spund
                audioSource.PlayOneShot(collisionSound);*/

                // check if cubes number less then max number is CubeSpawner.
                if (otheCube.CubeNumber < CubeSpawner.Instance.maxCubNumber)
                {
                    //play spund
                    audioSource.PlayOneShot(collisionSound);

                    // spawn a new cube as a result
                    Cube newCube = CubeSpawner.Instance.Spawn(cube.CubeNumber * 2, contactPoint + Vector3.up * 1.6f);
                    //push the new cube up and forward
                    float pushForce = 2.5f;
                    newCube.CubeRigidbody.AddForce(new Vector3(0, .3f, 1f) * pushForce, ForceMode.Impulse);

                    // add some torque
                    float randomValue = Random.Range(-20f, 20f);
                    Vector3 randonDirection = Vector3.one * randomValue;
                    newCube.CubeRigidbody.AddTorque(randonDirection);
                }

                // the explosion should addect surrounded cubes too
                Collider[] surroundedCubes = Physics.OverlapSphere(contactPoint, 2f);
                float explosionForce = 400f;
                float explosionRadius = 1.5f;

                foreach(Collider coll in surroundedCubes)
                {
                    if(coll.attachedRigidbody != null)
                    {
                        coll.attachedRigidbody.AddExplosionForce(explosionForce, contactPoint, explosionRadius);
                    }

                    // Todo explosion FX
                    FX.Instance.PlayCubeExplosionFX(contactPoint, cube.CubeColor);

                    // Destroy the two cubes
                    CubeSpawner.Instance.DestroyCube(cube);
                    CubeSpawner.Instance.DestroyCube(otheCube);
                }
            }
        }
    }
}
