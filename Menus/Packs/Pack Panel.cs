using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppTMPro;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppNinjaKiwi.Common;
using WeaponPacks;
using Il2CppAssets.Scripts.Unity.UI_New.Settings;

namespace AncientMonkey.Menus;

public class PackPanel : ModGameMenu<HotkeysScreen>
{
    ModHelperPanel panel;
    ModHelperScrollPanel PackScrollPanel;
    ModHelperScrollPanel WeaponScrollPanel;
    public override bool OnMenuOpened(Il2CppSystem.Object data)
    {
        CommonForegroundScreen.instance.heading.SetActive(true);
        CommonForegroundHeader.SetText("Weapon Packs");
        var gameObject = GameMenu.gameObject;
        gameObject.DestroyAllChildren();
        GameMenu.saved = true;

        panel = gameObject.AddModHelperPanel(new Info("Panel", 0, 0));
        var MainPanel = panel.AddPanel(new Info("AncientPacksMenu", 3600, 1900));
        CreatePacksListPanel(MainPanel);

        return false;
    }
    private void CreatePacksListPanel(ModHelperPanel MainPanel)
    {
        PackScrollPanel = MainPanel.AddScrollPanel(new Info("PackScrollMenu", -575, 0, 1100, 2000), RectTransform.Axis.Vertical, VanillaSprites.MainBgPanel, 20, 50);
        WeaponScrollPanel = MainPanel.AddScrollPanel(new Info("WeaponScrollMenu", 575, 0, 1100, 2000), RectTransform.Axis.Vertical, VanillaSprites.MainBgPanel, 20, 50);
        LoadPacksPanels();
    }
    public void LoadPacksPanels()
    {
        PackScrollPanel.ScrollContent.transform.DestroyAllChildren();

        for (int i = 0; i < GetContent<PackTemplate>().Count; i++)
        {
            foreach (var pack in GetContent<PackTemplate>())
            {
                if (pack.Order == i)
                {
                    PackScrollPanel.AddScrollContent(CreatePack(pack));
                }
            }
        }
    }
    public ModHelperPanel CreatePack(PackTemplate pack)
    {
        var panel = ModHelperPanel.Create(new Info("PackPanel" + pack.PackName, 0, 0, 1050, 150), VanillaSprites.MainBGPanelBlue);
        panel.AddText(new Info("PackName", -150, 0, 700, 100), pack.PackName, 60, TextAlignmentOptions.MidlineLeft);
        //panel.AddImage(new Info("image", 400, 0, 125), pack.Icon);

        var settingButton = panel.AddButton(new Info("PackIcon", 287, 0, 125), VanillaSprites.SettingsBtn, new System.Action(() =>
        {
            WeaponScrollPanel.ScrollContent.transform.DestroyAllChildren();

            for (int i = 1; i < 100; i++)
            {
                foreach (var weapon in GetContent<WeaponTemplate>())
                {
                    if (weapon.SandboxIndex == i && weapon.WeaponPack == pack.WeaponPack)
                    {
                        WeaponScrollPanel.AddScrollContent(CreateWeapon(weapon));
                    }
                }
            }

            for (int i = 1; i < 100; i++)
            {
                foreach (var ability in GetContent<AbilityTemplate>())
                {
                    if (ability.SandboxIndex == i && ability.WeaponPack == pack.WeaponPack)
                    {
                        WeaponScrollPanel.AddScrollContent(CreateAbility(ability));
                    }
                }
            }

            foreach (var ability in GetContent<UpgradedAbilityTemplate>())
            {
                if (ability.WeaponPack == pack.WeaponPack)
                {
                    WeaponScrollPanel.AddScrollContent(CreateAbilityUpgrade(ability));
                }
            }
        }));

        if (pack.isSelected == true)
        {
            var button = panel.AddButton(new Info("PackIcon", 437, 0, 125), VanillaSprites.ContinueBtn, new System.Action(() =>
            {
                pack.Edit();

                pack.isSelected = false;
                LoadPacksPanels();
            }));
        }
        else
        {
            var button = panel.AddButton(new Info("PackIcon", 437, 0, 125), VanillaSprites.CloseBtn, new System.Action(() => 
            {
                pack.Edit();

                pack.isSelected = true;
                LoadPacksPanels();
            }));
        }

        return panel;
    }
    public ModHelperPanel CreateWeapon(WeaponTemplate weapon)
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

        var panel = ModHelperPanel.Create(new Info("WeaponPanel", 0, 0, 1050, 150), sprites[weapon.SandboxIndex]);
        panel.AddText(new Info("Name", 75, 0, 850, 100), weapon.WeaponName, 60, TextAlignmentOptions.MidlineLeft);
        ModHelperImage image = panel.AddImage(new Info("Image", -438, 0, 125), weapon.CustomIcon);
        image.Image.LoadSprite(weapon.Icon);

        return panel;
    }
    public ModHelperPanel CreateAbility(AbilityTemplate ability)
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

        var panel = ModHelperPanel.Create(new Info("AbilityPanel", 0, 0, 1050, 150), sprites[ability.SandboxIndex]);
        panel.AddText(new Info("Name", 75, 0, 850, 100), ability.AbilityName, 60, TextAlignmentOptions.MidlineLeft);
        ModHelperImage image = panel.AddImage(new Info("Image", -438, 0, 125), ability.CustomIcon);
        image.Image.LoadSprite(ability.Icon);

        return panel;
    }
    public ModHelperPanel CreateAbilityUpgrade(UpgradedAbilityTemplate ability)
    {
        var panel = ModHelperPanel.Create(new Info("AbilityPanel", 0, 0, 1050, 150), VanillaSprites.MainBgPanelJukebox);
        panel.AddText(new Info("Name", 75, 0, 850, 100), ability.AbilityName, 60, TextAlignmentOptions.MidlineLeft);
        panel.AddText(new Info("Name", 250, 50, 500, 50), "Upgrade", 40, TextAlignmentOptions.TopRight);
        ModHelperImage image = panel.AddImage(new Info("Image", -438, 0, 125), ability.CustomIcon);
        image.Image.LoadSprite(ability.Icon);

        return panel;
    }
}
