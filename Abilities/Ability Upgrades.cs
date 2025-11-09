using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using WeaponPacks;
using System;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace AncientMonkey;

public class UpgradeAbilities : BloonsTD6Mod
{
    public static void UpgradeAbilityPanel(RectTransform rect, Tower tower)
    {
        if (mod.abUpgradeActive == false)
        {
            mod.abUpgradeActive = true;
            mod.panelOpen = true;
            MenuUi.upgradeMenu.Hide();

            // Ability Upgrade Panel
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 0, 0, 2500, 1200), VanillaSprites.MainBgPanel);
            MenuUi.abUpgradeMenu = panel.AddComponent<MenuUi>();
            panel.AddText(new Info("upgradeAb", 0, 600, 1000, 100), "Upgrade Abilities", 100);
            ModHelperScrollPanel scrollPanel = panel.AddScrollPanel(new Info("UpgradeScroll", 0, -50, 2500, 1100), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelHighlightTab, 15, 50);

            foreach (var ability in ModContent.GetContent<AbilityTemplate>())
            {
                if (ability.enabled == true && ability.AbilityRarity == AbilityTemplate.Rarity.Common)
                {
                    scrollPanel.AddScrollContent(AbilityUpgrades(tower, ability));
                }
            }

            foreach (var ability in ModContent.GetContent<AbilityTemplate>())
            {
                if (ability.enabled == true && ability.AbilityRarity == AbilityTemplate.Rarity.Rare)
                {
                    scrollPanel.AddScrollContent(AbilityUpgrades(tower, ability));
                }
            }

            ModHelperButton exit = panel.AddButton(new Info("exit", 1250, 600, 135), VanillaSprites.RedBtn, new Action(() => {
                tower.SetSelectionBlocked(false);
                panel.Hide();
                mod.panelOpen = false;
                if (mod.isSelected == true)
                {
                    MenuUi.CreateUpgradeMenu(rect, tower);
                }
            }));
            exit.AddText(new Info("x", 0, 0, 135, 135), "X", 80);
        }
        else
        {
            MenuUi.abUpgradeMenu.Show();
            mod.panelOpen = true;
        }
    }

    public static ModHelperPanel AbilityUpgrades(Tower tower, AbilityTemplate ability)
    {
        string[] sprites = [
            VanillaSprites.PortraitContainerParagon,
            VanillaSprites.GreyInsertPanel,
            VanillaSprites.BlueInsertPanel,
        ];

        var panel = ModHelperPanel.Create(new Info("AbilityContent" + ability.AbilityName, 2400, 150), sprites[ability.SandboxIndex]);
        ModHelperImage image = panel.AddImage(new Info("image", 90, 75, 140, 140, new Vector2()), ability.CustomIcon);
        image.Image.LoadSprite(ability.Icon);
        panel.AddText(new Info("abilityText", 580, 75, 800, 140, new Vector2()), ability.AbilityName, 80, Il2CppTMPro.TextAlignmentOptions.Left);
        panel.AddText(new Info("abilityText", 1500, 75, 600, 140, new Vector2()), $"${ability.upgradeCost}", 80, Il2CppTMPro.TextAlignmentOptions.Left);
        ModHelperButton upgradeAbilityBtn = panel.AddButton(new Info("upgradeAbilityBtn", 2020, 75, 400, 120, new Vector2()), VanillaSprites.GreenBtnLong, new Action(() => {
            InGame game = InGame.instance;

            if (game.GetCash() >= ability.upgradeCost && ability.stackIndex >= 1)
            {
                game.AddCash(-ability.upgradeCost);
                tower.worth += MathF.Round(ability.upgradeCost * 0.7f);
                ability.Upgrade(tower);
                ability.stackIndex -= 1;
                MenuUi.abUpgradeMenu.GetComponentFromChildrenByName<ModHelperScrollPanel>("UpgradeScroll").
                    GetComponentFromChildrenByName<ModHelperPanel>("AbilityContent" + ability.AbilityName).
                    GetComponentFromChildrenByName<ModHelperText>("StackText").Text.text = $"{ability.stackIndex}";

                foreach (var abilityTemplate in ModContent.GetContent<AbilityTemplate>())
                {
                    if (abilityTemplate.CodeName == ability.upgradeName)
                    {
                        abilityTemplate.stackIndex += 1;
                    }
                }
            }
        }));
        upgradeAbilityBtn.AddText(new Info("upgradeAbilityTxt", 0, 0, 400, 120), "Upgrade", 60);
        panel.AddText(new Info("StackText", 2310, 75, 140, 140, new Vector2()), $"{ability.stackIndex}", 80);

        return panel;
    }
}