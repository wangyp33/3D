using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    private int oneDiskScore = 10;

    private SceneController scene;

    void Awake()
    {
        scene = SceneController.getInstance();
        scene.setScoreController(this);
    }
    

    public void hitDisk()
    {
        scene.setScore(scene.getScore() + oneDiskScore);
    }

    public void hitGround(int input)
    {
        scene.setScore(scene.getScore());
    }
}