using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : Singleton<SceneLoader>
{
    public async UniTask OpenSceneAsync(int sceneIndex)
    {
        DOTween.KillAll();

       
            // Slider componentini almak
            Slider loadingBarSlider = TransitionSceneManager.Instance.progressBarSlider;
            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneIndex);
            loadSceneAsync.allowSceneActivation = false; // Sahne otomatik geçişi durdurulur
            while (!loadSceneAsync.isDone)
            {
                // Progress %90'da durabilir; bu yüzden normalized yaparız.
                float progress = Mathf.Clamp01(loadSceneAsync.progress / 0.9f);
                loadingBarSlider.value = progress; // İlerleme durumunu slidera uygula

                if (loadSceneAsync.progress >= 0.9f)
                {
                    // İlerleme tamamlandığında sahne aktif edilir
                    await UniTask.Delay(500); // Opsiyonel: Bekleme süresi
                    loadingBarSlider.value = 1f;
                    loadSceneAsync.allowSceneActivation = true;
                    await UniTask.Yield(this.GetCancellationTokenOnDestroy());
                }
            }
        }
    

    public void Reload()
    {
       
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(1);
        DOVirtual.DelayedCall(2f, () =>  OpenSceneAsync(currentSceneIndex).Forget());  
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
        DOVirtual.DelayedCall(2f, () =>  OpenSceneAsync(0).Forget());  
    }

    public void OpenMiniGame(int buildIndex)
    {
        SceneManager.LoadScene(1);
        DOVirtual.DelayedCall(2f, () =>  OpenSceneAsync(buildIndex).Forget());  
    }
}
