using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Tests
{
    public class LocalGameCanvasTests
    {
        [OneTimeSetUp]
        public void LoadScene()
        {
            SceneManager.LoadScene("LocalGameLobby");
        }

        [UnityTest]
        public IEnumerator ScoreboardButtonPressTest()
        {
            // var buttonGameObject = GameObject.Find("ScoreboardScrolldownButton");
            // var button = buttonGameObject.GetComponent<Button>();
            var button = new GameObject().AddComponent<ScoreboardHider>();

            bool bool1 = false;
            bool bool2 = false;
            button.RevertBool(bool1, bool2);
            yield return new WaitForSecondsRealtime(0.1f);
            //Assert.IsTrue(false, "make it be true");
            Assert.IsTrue(button.showScoreboard, "Button inverter not working");
            Assert.IsTrue(button.showScoreboardBtn, "Button inverter not working");
        }

        [UnityTest]
        public IEnumerator InputFieldTest()
        {
            GameObject.Find("POI").GetComponent<InputField>().text = "nameOne";
            GameObject.Find("PTI").GetComponent<InputField>().text = "nameTwo";
            yield return null;
            Assert.IsNotEmpty(GameObject.Find("Canvas").GetComponent<LocalGameCanvasController>().inputOne.text, "nameOne is empty");
            Assert.IsNotEmpty(GameObject.Find("Canvas").GetComponent<LocalGameCanvasController>().inputTwo.text, "nameTwo is empty");
        }
    }
}
