using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sGame : MonoBehaviour
{
    /// AI
    public GameObject Prey;
    public GameObject Predator;
    public string chaseAI;
    public float PredatorSpeed;
    public float PreySpeed;
    private Transform TPrey;
    private Transform TPredator;
    private Vector3 PPrey;
    private Vector3 PPredator;

    /// Camera
    public GameObject Camera;
    public KeyCode camUp;
    public KeyCode camDown;
    public KeyCode camLeft;
    public KeyCode camRight;
    public KeyCode camZoomOut;
    public KeyCode camZoomIn;
    public float camMoveSpeedMod;
    public float camDrag;
    private float HS;
    private float VS;
    private float ZS;

    // Start is called before the first frame update
    void Start()
    {
        TPrey = Prey.transform;
        TPredator = Predator.transform;
        PPrey = TPrey.position;
        PPredator = TPredator.position;
    }

    // Update is called once per frame
    void Update()
    {
        /// Camera
        {
            // Declare variables
            float LR = 0;
            float UD = 0;
            float ZIO = 0;
            bool noInput = true;

            // Get input
            if (Input.GetKey(camDown))
            {
                UD += .1f;
                noInput = false;
            }
            if (Input.GetKey(camUp))
            {
                UD -= .1f;
                noInput = false;
            }
            if (Input.GetKey(camRight))
            {
                LR -= .1f;
                noInput = false;
            }
            if (Input.GetKey(camLeft))
            {
                LR += .1f;
                noInput = false;
            }
            if (Input.GetKey(camZoomIn))
            {
                ZIO -= .025f;
                noInput = false;
            }
            if (Input.GetKey(camZoomOut))
            {
                ZIO += .025f;
                noInput = false;
            }

            // Update speeds
            VS -= UD;
            HS -= LR;
            ZS += ZIO;

            // Vertical
            if (VS < -camDrag)
            {
                VS += camDrag;
            }
            else if (VS > camDrag)
            {
                VS -= camDrag;
            }
            else if (noInput)
            {
                VS = 0;
            }

            // Horisontal
            if (HS < -camDrag)
            {
                HS += camDrag;
            }
            else if (HS > camDrag)
            {
                HS -= camDrag;
            }
            else if (noInput)
            {
                HS = 0;
            }

            // Zoom
            if (ZS < -camDrag)
            {
                ZS += camDrag / 2;
            }
            else if (ZS > camDrag)
            {
                ZS -= camDrag / 2;
            }
            else if (noInput)
            {
                ZS = 0;
            }
            Debug.Log(ZS);
            Camera.transform.position += new Vector3(HS * camMoveSpeedMod, ZS * camMoveSpeedMod, VS * camMoveSpeedMod);
        }

        /// Chase AI V 1
        if (chaseAI == "1")
        {
            if (PPrey.x > PPredator.x)
            {
                TPredator.Translate(Vector3.right * PredatorSpeed);
            }
            else if (PPrey.x < PPredator.x)
            {
                TPredator.Translate(Vector3.left * PredatorSpeed);
            }
            /*
            if (PPrey.z > PPredator.z)
            {
                TPredator.Translate(Vector3.right * PredatorSpeed);
            }
            else if (PPrey.x > PPredator.x)
            {
                TPredator.Translate(Vector3.right * PredatorSpeed);
            }
            */
        }
    }
}
