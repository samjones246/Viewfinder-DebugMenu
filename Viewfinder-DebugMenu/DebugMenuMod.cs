using Il2Cpp;
using MelonLoader;
using UnityEngine;

namespace Viewfinder_DebugMenu
{
    public class DebugMenuMod: MelonMod
    {
        private bool isDebugMenuActive = false;
        public override void OnLateUpdate()
        {
            GameObject debugMenuParent = GameObject.Find("Debug Menu");
            if (debugMenuParent == null) return;

            GameObject debugMenu = debugMenuParent.transform.GetChild(0).gameObject;
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if (!isDebugMenuActive)
                {
                    debugMenu.SetActive(true);
                }
                isDebugMenuActive = !isDebugMenuActive;
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                DebugOverlayController controller = GameObject.Find("Debug Overlay").GetComponent<DebugOverlayController>();
                controller.SetOpen(!controller.IsOpen());
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                DebugFlyMode controller = debugMenuParent.GetComponent<DebugFlyingToggle>().debugFlyMode;
                controller.SetFlyingEnabled(!controller.GetFlyingEnabled());
            }
            if (Input.GetKeyDown(KeyCode.F6))
            {
                RuntimeLevelManagement controller = GameObject.Find("Level Menu (UI Builder)").GetComponent<RuntimeLevelManagement>();
                if (controller.showing)
                {
                    controller.Hide();
                } else
                {
                    controller.Show();
                }
            }
            if (Input.GetKeyDown(KeyCode.End))
            {
                Component.FindObjectOfType<Transporter>()?.FinishLevel();
            }
        }
    }
}