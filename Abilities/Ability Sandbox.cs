using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Models.Towers;
using WeaponPacks;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;

namespace AncientMonkey;

public class AbilitySandbox : BloonsTD6Mod
{
    public static void AbilitySandboxPanel(RectTransform rect, Tower tower)
    {
        mod.panelOpen = true;

        if (mod.abilityActive == false)
        {
            mod.abilityActive = true;

            // Ability Select Panel
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 0, 0, 2500, 1850), VanillaSprites.MainBGPanelBlue);
            MenuUi abilityUi = panel.AddComponent<MenuUi>();
            MenuUi.abilityMenu = abilityUi;

            ModHelperScrollPanel scrollPanel = panel.AddScrollPanel(new Info("scrollPanel", 0, 0, 2500, 1850), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelBlue, 15, 50);
            ModHelperButton exit = panel.AddButton(new Info("exit", 1200, 900, 135, 135), VanillaSprites.RedBtn, new System.Action(() => {
                tower.SetSelectionBlocked(false);
                panel.Hide();
                mod.panelOpen = false;
                if (mod.isSelected == true)
                {
                    MenuUi.CreateUpgradeMenu(rect, tower);
                }
            }));
            ModHelperText x = exit.AddText(new Info("x", 0, 0, 135, 135), "X", 80);

            ModHelperButton resetBtn = panel.AddButton(new Info("reset", 1200, 750, 135, 135), VanillaSprites.GreenBtn, new System.Action(() => {
                var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
                foreach (var ability in towerModel.GetAbilities())
                {
                    towerModel.RemoveBehavior(ability);
                }
                foreach (var ability in towerModel.GetBehaviors<SpiritOfTheForestModel>())
                {
                    towerModel.RemoveBehavior(ability);
                }
                tower.UpdateRootModel(towerModel);
            }));
            ModHelperImage resetImage = resetBtn.AddImage(new Info("Image", 0, 0, 110, 110), VanillaSprites.RestartIcon);

            for (int i = 1; i < 10; i++)
            {
                foreach (var ability in ModContent.GetContent<AbilityTemplate>())
                {
                    if (ability.SandboxIndex == i && ability.enabled)
                    {
                        scrollPanel.AddScrollContent(CreateSandboxAbility(ability, tower));
                    }
                }
            }

            foreach (var ability in ModContent.GetContent<UpgradedAbilityTemplate>())
            {
                if (ability.enabled)
                {
                    scrollPanel.AddScrollContent(CreateSandboxUpgrade(ability, tower));
                }
            }
        }
        else
        {
            MenuUi.abilityMenu.Show();
            mod.panelOpen = true;
        }
    }

    public static ModHelperPanel CreateSandboxAbility(AbilityTemplate ability, Tower tower)
    {
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

        var panel = ModHelperPanel.Create(new Info("AbilityContent" + ability.AbilityName, 0, 0, 2250, 150), sprites[ability.SandboxIndex]);
        ModHelperText abilityText = panel.AddText(new Info("abilityText", -475, 0, 800, 150), ability.AbilityName, 70, Il2CppTMPro.TextAlignmentOptions.Left);
        ModHelperText rarityText = panel.AddText(new Info("rarityText", 175, 0, 600, 150), $"{ability.AbilityRarity}", 70);
        ModHelperImage image = panel.AddImage(new Info("image", -1030, 0, 140, 140), ability.CustomIcon);
        image.Image.LoadSprite(ability.Icon);

        ModHelperButton selectAbilityBtn = panel.AddButton(new Info("selectAbilityBtn", 900, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
            AbilitySandboxSelected(ability, tower);
        }));
        ModHelperText selectAbilityTxt = selectAbilityBtn.AddText(new Info("selectAbilityTxt", 0, 0, 400, 120), "Select", 60);

        return panel;
    }

    public static ModHelperPanel CreateSandboxUpgrade(UpgradedAbilityTemplate ability, Tower tower)
    {
        var panel = ModHelperPanel.Create(new Info("AbilityContent" + ability.AbilityName, 0, 0, 2250, 150), VanillaSprites.MainBgPanelJukebox);
        ModHelperText abilityText = panel.AddText(new Info("abilityText", -475, 0, 800, 150), ability.AbilityName, 70, Il2CppTMPro.TextAlignmentOptions.Left);
        ModHelperText rarityText = panel.AddText(new Info("rarityText", 175, 0, 600, 150), "Upgrade", 70);
        ModHelperImage image = panel.AddImage(new Info("image", -1030, 0, 140, 140), ability.CustomIcon);
        image.Image.LoadSprite(ability.Icon);

        ModHelperButton selectAbilityBtn = panel.AddButton(new Info("selectAbilityBtn", 900, 0, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => {
            UpgradeSandboxSelected(ability, tower);
        }));
        ModHelperText selectAbilityTxt = selectAbilityBtn.AddText(new Info("selectAbilityTxt", 0, 0, 400, 120), "Select", 60);

        return panel;
    }

    public static void AbilitySandboxSelected(AbilityTemplate ability, Tower tower)
    {
        mod.panelOpen = false;
        InGame game = InGame.instance;
        RectTransform rect = game.uiRect;

        ability.EditTower(tower);
    }

    public static void UpgradeSandboxSelected(UpgradedAbilityTemplate ability, Tower tower)
    {
        mod.panelOpen = false;
        InGame game = InGame.instance;
        RectTransform rect = game.uiRect;

        ability.EditTower(tower);
    }
}