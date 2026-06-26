using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace MindlessMods {
    public class LoadMod : MonoBehaviour {

        public CurrentModInfo currentModInfo;
        public string ModMakerSceneName = "ModMaker";
        public int selectedModIndex = 1;

        public bool modRoom = false;

        public void ChangeModIndex(int index) {
            selectedModIndex = index;
        }

        public void LoadMyMod() {
            CurrentModInfo modItem = Instantiate(currentModInfo, null);
            modItem.selectedModIndex = selectedModIndex;
            DontDestroyOnLoad(modItem);
            CreateModRoom();
        }     
        
        IEnumerator LoadYourAsyncScene()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(ModMakerSceneName);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

        }

        private void CreateModRoom()
        {
            if (PhotonNetwork.IsConnected)
                PhotonNetwork.Disconnect();
            PhotonNetwork.OfflineMode = true;
            modRoom = true;
            PhotonNetwork.CreateRoom($"Mod Room {selectedModIndex}");
            Debug.Log("Loaded: Mod " + selectedModIndex);
            StartCoroutine(LoadYourAsyncScene());
        }

        public static bool IsModRoom(){
            return FindAnyObjectByType<LoadMod>().modRoom;
        }

    }
}

