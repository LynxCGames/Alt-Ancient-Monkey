using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using WeaponPacks;

namespace AncientMonkey;

public class WeaponSandbox : BloonsTD6Mod
{
    public static void WpnSandboxPanel(RectTransform rect, Tower tower)
    {
        mod.panelOpen = true;

        if (mod.weaponActive == false)
        {
            mod.weaponActive = true;

            // Weapon Select Panel
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 0, 0, 2500, 1850), VanillaSprites.MainBGPanelBlue);
            MenuUi.weaponSandboxMenu = panel.AddComponent<MenuUi>();

            ModHelperScrollPanel scrollPanel = panel.AddScrollPanel(new Info("scrollPanel", 0, 0, 2500, 1850), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelBlue, 15, 50);
            ModHelperButton exit = panel.AddButton(new Info("exit", 1200, 900, 135), VanillaSprites.RedBtn, new System.Action(() => {
                tower.SetSelectionBlocked(false);
                panel.Hide();
                mod.panelOpen = false;
                if (mod.isSelected == true)
                {
                    MenuUi.CreateUpgradeMenu(rect, tower);
                }
            }));
            ModHelperText x = exit.AddText(new Info("x", 0, 0, 135, 135), "X", 80);

            ModHelperButton resetBtn = panel.AddButton(new Info("reset", 1200, 750, 135), VanillaSprites.GreenBtn, new System.Action(() => {
                var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
                foreach (var weapons in towerModel.GetAttackModels())
                {
                    if (weapons.name != towerModel.GetAttackModel().name)
                    {
                        towerModel.RemoveBehavior(weapons);
                    }
                }
                foreach (var weapons in towerModel.GetBehaviors<TowerCreateTowerModel>())
                {
                    towerModel.RemoveBehavior(weapons);
                }
                foreach (var weapons in towerModel.GetBehaviors<OrbitModel>())
                {
                    towerModel.RemoveBehavior(weapons);
                }
                foreach (var weapons in towerModel.GetBehaviors<PerRoundCashBonusTowerModel>())
                {
                    if (!weapons.name.Contains("ExtrasMoneyGenerate"))
                    {
                        towerModel.RemoveBehavior(weapons);
                    }
                }
                foreach (var weapons in towerModel.GetBehaviors<SpikeParagonDamageZoneModel>())
                {
                    towerModel.RemoveBehavior(weapons);
                }
                foreach (var weapons in towerModel.GetBehaviors<PreEmptiveStrikeLauncherModel>())
                {
                    towerModel.RemoveBehavior(weapons);
                }
                tower.UpdateRootModel(towerModel);
            }));
            ModHelperImage resetImage = resetBtn.AddImage(new Info("Image", 0, 0, 110, 110), VanillaSprites.RestartIcon);

            ModHelperPanel gildPanel = panel.AddPanel(new Info("Panel_", 0, -1050, 900, 160), VanillaSprites.MainBGPanelBlue);
            ModHelperText gildedTxt = gildPanel.AddText(new Info("gildedTxt", -220, 0, 400, 120), "Disabled", 60);
            ModHelperButton gildSelect = gildPanel.AddButton(new Info("gildSelect", 220, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
                mod.isGilded = !mod.isGilded;
                if (mod.isGilded) { gildedTxt.Text.text = "Enabled"; }
                else { gildedTxt.Text.text = "Disabled"; }
            }));
            ModHelperText gildedBtnTxt = gildSelect.AddText(new Info("gildedBtnTxt", 0, 0, 400, 120), "Gilded", 60);

            for (int i = 1; i < 10; i++)
            {
                foreach (var weapon in ModContent.GetContent<WeaponTemplate>())
                {
                    if (weapon.SandboxIndex == i && weapon.enabled)
                    {
                        scrollPanel.AddScrollContent(CreateSandboxWpn(rect,weapon, tower));
                    }
                }
            }
        }
        else
        {
            MenuUi.weaponSandboxMenu.Show();
            mod.panelOpen = true;
        }
    }

    public static ModHelperPanel CreateSandboxWpn(RectTransform rect, WeaponTemplate weapon, Tower tower)
    {
        Il2CppSystem.Random rnd = new();
        string[] sprites = [
            VanillaSprites.PortraitContainerParagon,
            VanillaSprites.GreyInsertPanel,
            VanillaSprites.BlueInsertPanel,
            VanillaSprites.MainBgPanelParagon,
            VanillaSprites.MainBGPanelYellow,
            VanillaSprites.MainBgPanelWhiteSmall,
            VanillaSprites.MainBGPanelSilver,
            VanillaSprites.MainBgPanelHematite,
            VanillaSprites.GreenToggleUiMain,
        ];

        var panel = ModHelperPanel.Create(new Info("WeaponContent" + weapon.WeaponName, 0, 0, 2250, 150), sprites[weapon.SandboxIndex]);
        ModHelperText weaponText = panel.AddText(new Info("weaponText", -475, 0, 800, 150), weapon.WeaponName, 70, Il2CppTMPro.TextAlignmentOptions.Left);
        ModHelperText rarityText = panel.AddText(new Info("rarityText", 175, 0, 600, 150), $"{weapon.WeaponRarity}", 70);
        ModHelperImage image = panel.AddImage(new Info("image", -1030, 0, 140, 140), weapon.CustomIcon);
        image.Image.LoadSprite(weapon.Icon);

        ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 900, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
            if (mod.isGilded == true)
            {
                MenuUi.weaponSandboxMenu.Hide();
                GildedSandboxPanel(rect, weapon, tower);
            }
            else
            {
                weapon.EditTower(tower, false, "", 0);
            }
        }));
        ModHelperText selectWpnTxt = selectWpnBtn.AddText(new Info("selectWpnTxt", 0, 0, 400, 120), "Select", 60);

        if (weapon.IsCamo)
        {
            ModHelperImage camoImg = panel.AddImage(new Info("camoImg", 460, 0, 120, 120), VanillaSprites.CamoBloonIcon);
        }
        if (weapon.IsLead)
        {
            ModHelperImage leadImg = panel.AddImage(new Info("leadImg", 580, 0, 120, 120), VanillaSprites.LeadBloonIcon);
        }

        return panel;
    }

    public static string effect = "";
    public static void GildedSandboxPanel(RectTransform rect, WeaponTemplate weapon, Tower tower)
    {
        effect = "";
        int degree = 0;

        ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 0, 0, 1800, 1300), VanillaSprites.MainBGPanelBlue);
        panel.AddText(new Info("Text", 0, 650, 1800, 100), "Gilded Customization", 100);

        // Degree Setter
        ModHelperPanel degreePanel = panel.AddPanel(new Info("GildedDegree", -450, 425, 300), VanillaSprites.UpgradeContainerParagon);
        ModHelperText degreeText = degreePanel.AddText(new Info("Degree", 300), $"{degree}", 100);
        ModHelperButton addDegree = panel.AddButton(new Info("AddDegree", -175, 425, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
            if (degree < 10) { degree += 1; }
            degreeText.Text.text = $"{degree}";
        }));
        addDegree.AddText(new Info("Add", 0, 0, 150), "+1", 80);
        ModHelperButton subDegree = panel.AddButton(new Info("SubtractDegree", -725, 425, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
            if (degree > -10) { degree -= 1; }
            degreeText.Text.text = $"{degree}";
        }));
        subDegree.AddText(new Info("Subtract", 0, 0, 150), "-1", 80);

        // Effect Setter
        ModHelperPanel effectNamePanel = panel.AddPanel(new Info("GildedEffectName", 450, 425, 600, 200), VanillaSprites.MainBgPanelParagon);
        ModHelperText effectNameText = effectNamePanel.AddText(new Info("GildedEffectText", 0, 0, 600, 200), $"{effect}", 70);
        ModHelperScrollPanel effectPanel = panel.AddScrollPanel(new Info("GildedEffects", 0, -150, 1800, 800), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelHighlightTab, 15, 50);
        for (int i = 0; i < weapon.GildedEffects.Length; i++)
        {
            foreach (var gildedTemp in ModContent.GetContent<GildedTemplate>())
            {
                if (gildedTemp.EffectName == weapon.GildedEffects[i])
                {
                    effectPanel.AddScrollContent(CreateGildedEffect(gildedTemp, effectNameText));
                }
            }
        }

        // Confirm
        ModHelperButton confirmButton = panel.AddButton(new Info("ConfirmButton", 0, -650, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
            if (effect != "")
            {
                weapon.EditTower(tower, true, effect, degree);
                panel.DeleteObject();
                MenuUi.weaponSandboxMenu.Show();
            }
        }));
        confirmButton.AddText(new Info("ConfirmTect", 0, 0, 400, 120), "Confirm", 60);
    }

    public static ModHelperPanel CreateGildedEffect(GildedTemplate gildedEffect, ModHelperText effectName)
    {
        var panel = ModHelperPanel.Create(new Info("WeaponContent" + gildedEffect.EffectName, 0, 0, 1700, 150), VanillaSprites.MainBgPanelParagon);
        panel.AddImage(new Info("EffectImage", 85, 75, 130, 130, new Vector2()), gildedEffect.Icon);
        panel.AddText(new Info("EffectText", 430, 75, 520, 140, new Vector2()), gildedEffect.EffectName, 60, Il2CppTMPro.TextAlignmentOptions.Left);
        panel.AddText(new Info("EffectDesc", 1050, 75, 620, 140, new Vector2()), gildedEffect.Description, 40, Il2CppTMPro.TextAlignmentOptions.Left);
        ModHelperButton selectButton = panel.AddButton(new Info("SelectButton", 1530, 75, 300, 120, new Vector2()), VanillaSprites.GreenBtnLong, new System.Action(() => {
            effect = gildedEffect.EffectName;
            effectName.Text.text = effect;
        }));
        selectButton.AddText(new Info("SelectTect", 0, 0, 300, 120), "Select", 60);

        return panel;
    }
}