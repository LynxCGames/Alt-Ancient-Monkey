using System;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api;
using UnityEngine;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using TaskScheduler = BTD_Mod_Helper.Api.TaskScheduler;
using Il2CppAssets.Scripts.Unity.UI_New;

namespace AncientMonkey.Menus;

public static class AncientButton
{
    private static ModHelperPanel panel;
    private static ModHelperButton image;

    private static void OpenEditorPanel()
    {
        ModGameMenu.Open<AncientPanel>();
    }
    public static void CreatePanel(GameObject screen)
    {
        panel = screen.AddModHelperPanel(new Info("AncientButton")
        {
            Anchor = new Vector2(1, 0),
            Pivot = new Vector2(1, 0)
        });
        var animator = panel.AddComponent<Animator>();
        animator.runtimeAnimatorController = Animations.GlobalButtonAnimation;
        animator.speed = .75f;

        image = panel.AddButton(new Info("AncientButton", -4390, 500, 420, 420, new Vector2(1, 0), new Vector2(0.5f, 0)), VanillaSprites.PrimaryMonkeyIcon, new Action(OpenEditorPanel));
        image.AddText(new Info("Text", 0, -125, 425, 200), "Ancient Settings", 70f);
    }
    private static void HideButton()
    {
        panel.GetComponent<Animator>().Play("PopupSlideOut");
        TaskScheduler.ScheduleTask(() => panel.SetActive(false), ScheduleType.WaitForFrames, 13);
    }
    private static void Init()
    {
        var screen = CommonForegroundScreen.instance.transform;
        var ModSavePanel = screen.FindChild("AncientButton");
        if (ModSavePanel == null)
        {
            CreatePanel(screen.gameObject);
        }
    }
    public static void Show()
    {
        Init();
        panel.SetActive(true);
        panel.GetComponent<Animator>().Play("PopupSlideIn");
    }

    public static void Hide()
    {
        var screen = CommonForegroundScreen.instance.transform;
        var ModSavePanel = screen.FindChild("AncientButton");
        if (ModSavePanel != null)
        {
            HideButton();
        }
    }
}