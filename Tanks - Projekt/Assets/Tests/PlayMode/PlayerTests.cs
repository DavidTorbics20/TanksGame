using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PlayerTests : MonoBehaviour
{
    [OneTimeSetUp]
    public void LoadScene()
    {
        SceneManager.LoadScene("LocalGame");
        // yield return new WaitForSecondsRealtime(5f);
    }

    [UnityTest]
    public IEnumerator PlayerOneMovementForward()
    {
        var player = new GameObject().AddComponent<PlayerOneMovement>();

        Vector3 start_position;
        Vector3 new_position;

        //tests forward movement
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        start_position = new Vector3(0, 0, 0);
        player.CalculateMovement(10, 100, 1);
        yield return new WaitForSecondsRealtime(0.1f);
        new_position = player.transform.position;
        Assert.Greater(new_position.y, start_position.y, "Forward movement error");
    }

    [UnityTest]
    public IEnumerator PlayerOneMovementBackwrd()
    {
        var player = new GameObject().AddComponent<PlayerOneMovement>();

        Vector3 start_position;
        Vector3 new_position;

        //tests forward movement
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        start_position = new Vector3(0, 0, 0);
        player.CalculateMovement(10, 100, -1);
        yield return new WaitForSecondsRealtime(0.1f);
        new_position = player.transform.position;
        Assert.Greater(start_position.y, new_position.y, "Backward movement error");
    }

    [UnityTest]
    public IEnumerator PlayerTwoMovement()
    {
        var player = new GameObject().AddComponent<PlayerTwoMovement>();

        Vector3 start_position;
        Vector3 new_position;

        //tests forward movement
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        start_position = new Vector3(0, 0, 0);
        player.CalculateMovement(10, 100, 1);
        yield return new WaitForSecondsRealtime(0.1f);
        new_position = player.transform.position;
        Assert.Greater(new_position.y, start_position.y, "Forward movement error");
    }

    [UnityTest]
    public IEnumerator PlayerTwoMovementBackward()
    {
        var player = new GameObject().AddComponent<PlayerTwoMovement>();

        Vector3 start_position;
        Vector3 new_position;

        //tests forward movement
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        start_position = new Vector3(0, 0, 0);
        player.CalculateMovement(10, 100, -1);
        yield return new WaitForSecondsRealtime(0.1f);
        new_position = player.transform.position;
        Assert.Greater(start_position.y, new_position.y, "Backward movement error");
    }

    [UnityTest]
    public IEnumerator PlayerOneSpinLeft()
    {
        var player = new GameObject().AddComponent<PlayerOneMovement>();

        Quaternion start_rotation;
        Quaternion end_rotation;

        start_rotation = player.transform.rotation;
        player.transform.rotation = Quaternion.Euler(player.CalculateRotation(10, 4, 1), 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        end_rotation = player.transform.rotation;
        Assert.Greater(end_rotation.x, start_rotation.x, "Rotation to left error");

        start_rotation = end_rotation;
        player.transform.rotation = Quaternion.Euler(player.CalculateRotation(10, 4, -1), 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        end_rotation = player.transform.rotation;
        Assert.Less(end_rotation.x, start_rotation.x, "Rotation to right error");
    }

    [UnityTest]
    public IEnumerator PlayerOneSpinRight()
    {
        var player = new GameObject().AddComponent<PlayerOneMovement>();

        Quaternion start_rotation;
        Quaternion end_rotation;

        start_rotation = player.transform.rotation;
        player.transform.rotation = Quaternion.Euler(player.CalculateRotation(10, 4, -1), 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        end_rotation = player.transform.rotation;
        Assert.Less(end_rotation.x, start_rotation.x, "Rotation to right error");
    }

    [UnityTest]
    public IEnumerator PlayerTwoSpinLeft()
    {
        var player = new GameObject().AddComponent<PlayerTwoMovement>();

        Quaternion start_rotation;
        Quaternion end_rotation;

        start_rotation = player.transform.rotation;
        player.transform.rotation = Quaternion.Euler(player.CalculateRotation(10, 4, 1), 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        end_rotation = player.transform.rotation;
        Assert.Greater(end_rotation.x, start_rotation.x, "Rotation to left error");

        start_rotation = end_rotation;
        player.transform.rotation = Quaternion.Euler(player.CalculateRotation(10, 4, -1), 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        end_rotation = player.transform.rotation;
        Assert.Less(end_rotation.x, start_rotation.x, "Rotation to right error");
    }

    [UnityTest]
    public IEnumerator PlayerTwoSpinRight()
    {
        var player = new GameObject().AddComponent<PlayerTwoMovement>();

        Quaternion start_rotation;
        Quaternion end_rotation;

        start_rotation = player.transform.rotation;
        player.transform.rotation = Quaternion.Euler(player.CalculateRotation(10, 4, -1), 0, 0);
        yield return new WaitForSecondsRealtime(0.1f);
        end_rotation = player.transform.rotation;
        Assert.Less(end_rotation.x, start_rotation.x, "Rotation to right error");
    }
}
