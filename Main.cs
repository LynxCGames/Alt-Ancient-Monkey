using MelonLoader;
using BTD_Mod_Helper;
using AncientMonkey;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using BTD_Mod_Helper.Api;
using System.Linq;
using Il2CppAssets.Scripts.Simulation.Objects;
using Il2CppSystem.Linq;
using System;
using BTD_Mod_Helper.Api.ModOptions;
using AncientMonkey.Menus;
using WeaponPacks;
using Microsoft.VisualBasic.FileIO;
using Il2CppAssets.Scripts.Data.Behaviors.Pets;

//using AncientMonkey.Challenge;
//using AncientMonkey.Quest;

[assembly: MelonInfo(typeof(AncientMonkey.AncientMonkey), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace AncientMonkey;

public class AncientMonkey : BloonsTD6Mod
{
    internal static readonly ModSettingBool SandboxMode = new(false)
    {
        icon = VanillaSprites.SandboxBtn,
        description = "Enable Sandbox Mode"
    };

    public static AncientMonkey mod;

    // Costs
    public float weaponCost;
    public float abilityCost;
    public float strengthCost;
    public float weaponCostIncreaser;
    public float abilityCostIncreaser;
    public float strengthCostIncreaser;
    public float weaponSlotCost;
    public float abilitySlotCost;
    public float strengthSlotCost;
    public float luckCost;
    public float gildedCost;
    public float moneyCost;
    public float upgradeCost;
    public float gildEffectCost;

    // Strength Values
    public int damageBonus;
    public int pierceBonus;
    public float rangeBonus;
    public float attackSpeedBonus;
    public float moneyBonus;

    // Menus
    public bool upgradeActive;
    public bool weaponActive;
    public bool abilityActive;
    public bool abUpgradeActive;
    public bool strengthActive;
    public bool extrasActive;
    public bool isSelected;
    public bool panelOpen;
    public int level;
    public int weaponSlots;
    public int abilitySlots;
    public int strengthSlots;
    public bool isGilded;

    // Settings
    public float gildedChance;
    public float gildedMax;
    public float luck;
    public float moneyLevel;
    public float moneyGenerate;
    public float upgradeMultiplier = 1;
    public float extrasMultiplier = 1;
    public float gildEffectRoll;

    // Challenges
    public bool superWeapons;
    public bool blingedOut;
    public bool abilityMayhem;
    public bool oneSlot;
    public bool foolsGold;
    public bool errorCode;
    public bool moneyStarved;
    public bool powerCreep;
    public bool mastery;

    // Weapon Packs
    /*packUpgrades = [commonWpn, rareWpn, epicWpn, legendaryWpn, mythicWpn, commonAb, rareAb, epicAb, legendaryAb];*/
    public int[]? packUpgrades = [5, 5, 5, 5, 5, 3, 5, 5, 4];
    public string[]? packUpgradeNames = 
        ["Common Weapons", "Rare Weapons", "Epic Weapons", "Legendary Weapons", "Mythic Weapons", 
        "Common Abilities", "Rare Abilities", "Epic Abilities", "Legendary Abilities"];


    public override void OnApplicationStart()
    {
        mod = this;
    }
    public override void OnGameModelLoaded(GameModel model)
    {
        Reseter.Reset();

        foreach (var challenge in ModContent.GetContent<ChallengeTemplate>())
        {
            if (challenge.ChallengeName == "Classic")
            { challenge.isSelected = true; }
            else { challenge.isSelected = false; }
        }

        foreach (var pack in ModContent.GetContent<PackTemplate>())
        {
            if (pack.WeaponPack == "DefaultPack" | pack.WeaponPack == "PrimaryPack" | pack.WeaponPack == "MilitaryPack" | pack.WeaponPack == "MagicPack" | pack.WeaponPack == "SupportPack" | pack.WeaponPack == "HeroPack")
            { pack.isSelected = true; }
            else { pack.isSelected = false; }
        }

        foreach (var pack in ModContent.GetContent<WeaponTemplate>())
        {
            if (pack.WeaponPack == "DefaultPack" | pack.WeaponPack == "PrimaryPack" | pack.WeaponPack == "MilitaryPack" | pack.WeaponPack == "MagicPack" | pack.WeaponPack == "SupportPack" | pack.WeaponPack == "HeroPack")
            { pack.enabled = true; }
            else { pack.enabled = false; }
            /*
            if (pack.WeaponPack == "DefaultPack" | pack.WeaponPack == "HuborPack")
            { pack.enabled = true; }
            else { pack.enabled = false; }*/
        }

        foreach (var pack in ModContent.GetContent<AbilityTemplate>())
        {
            if (pack.WeaponPack == "DefaultPack" | pack.WeaponPack == "PrimaryPack" | pack.WeaponPack == "MilitaryPack" | pack.WeaponPack == "MagicPack" | pack.WeaponPack == "SupportPack" | pack.WeaponPack == "HeroPack")
            { pack.enabled = true; }
            else { pack.enabled = false; }
        }

        foreach (var pack in ModContent.GetContent<UpgradedAbilityTemplate>())
        {
            if (pack.WeaponPack == "DefaultPack" | pack.WeaponPack == "PrimaryPack" | pack.WeaponPack == "MilitaryPack" | pack.WeaponPack == "MagicPack" | pack.WeaponPack == "SupportPack" | pack.WeaponPack == "HeroPack")
            { pack.enabled = true; }
            else { pack.enabled = false; }
        }
    }
    public override void OnTowerSold(Tower tower, float amount)
    {
        if (tower.towerModel.name.Contains("AncientMonkey-AncientMonkey"))
        {
            Reseter.Reset();
        }
    }
    public override void OnRestart()
    {
        if (isSelected == true && panelOpen == false)
        {
            MenuUi.upgradeMenu.Hide();
        }
    }
    public override void OnTowerCreated(Tower tower, Entity target, Model modelToUse)
    {
        if (tower.towerModel.name.Contains("AncientMonkey-AncientMonkey"))
        {
            Reseter.Reset();

            if (!SandboxMode)
            {
                InGame game = InGame.instance;
                RectTransform rect = game.uiRect;

                for (var i = 0; i < mod.packUpgrades.Count(); i++)
                {
                    if (mod.packUpgrades[i] <= 0)
                    {
                        CreateWarning(rect, tower);
                        return;
                    }
                }

                mod.weaponSlots = 5;
                WeaponStart.NewWeaponStart(rect, tower);
            }
        }
    }
    public static void CreateWarning(RectTransform rect, Tower tower)
    {
        ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 0, 0, 1500, 1200), VanillaSprites.BrownInsertPanel);
        panel.AddText(new Info("Warning", 0, 600, 1000, 100), "Warning", 80);
        string text = "Based on your weapon pack selection, you don't have any\n";
        for (var i = 0; i < mod.packUpgrades.Count(); i++)
        {
            if (mod.packUpgrades[i] <= 0)
            {
                text += $"{mod.packUpgradeNames[i]}\n";
            }
        }
        text += "enabled. This may cause problems for the mod. Would you like to add placeholders for the missing upgrades?";
        ModHelperText warning = panel.AddText(new Info("WarningText", 0, 0, 1400, 1000), text, 60);
        ModHelperButton cancelButton = panel.AddButton(new Info("NoButton", -500, -600, 500, 200), VanillaSprites.RedBtnLong, new Action(() => {
            panel.DeleteObject();
            mod.weaponSlots = 5;
            WeaponStart.NewWeaponStart(rect, tower);
        }));
        cancelButton.AddText(new Info("NoText", 0, 0, 400, 150), "Cancel", 80);
        ModHelperButton acceptButton = panel.AddButton(new Info("YesButton", 500, -600, 500, 200), VanillaSprites.GreenBtnLong, new Action(() => {
            for (var i = 0; i < mod.packUpgrades.Count(); i++)
            {
                if (mod.packUpgrades[i] <= 0)
                {
                    foreach (var weapon in ModContent.GetContent<WeaponTemplate>())
                    {
                        if (weapon.CodeName == mod.packUpgradeNames[i])
                        {
                            weapon.enabled = true;
                        }
                    }
                    foreach (var ability in ModContent.GetContent<AbilityTemplate>())
                    {
                        if (ability.CodeName == mod.packUpgradeNames[i])
                        {
                            ability.enabled = true;
                        }
                    }
                }
            }

            panel.DeleteObject();
            mod.weaponSlots = 5;
            WeaponStart.NewWeaponStart(rect, tower);
        }));
        acceptButton.AddText(new Info("YesText", 0, 0, 400, 150), "Add Placeholders", 55);
    }
    public override void OnNewGameModel(GameModel result)
    {
        foreach (var tower in result.towerSet.ToList())
        {
            if (mod.abilityMayhem == true | mod.oneSlot == true | mod.foolsGold == true | mod.errorCode == true | mod.moneyStarved == true | mod.powerCreep == true | mod.mastery == true)
            {
                if (tower.name.Contains("AncientMonkey-AncientMonkey"))
                {
                    tower.GetShopTowerDetails().towerCount = 1;
                }
                else
                {
                    tower.GetShopTowerDetails().towerCount = 0;
                }
            }
            else
            {
                if (tower.name.Contains("AncientMonkey-AncientMonkey"))
                {
                    tower.GetShopTowerDetails().towerCount = 1;
                }
            }
        }
    }
    public override void OnTowerSelected(Tower tower)
    {
        if (tower.towerModel.name.Contains("AncientMonkey-AncientMonkey"))
        {
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            MenuUi.CreateUpgradeMenu(rect, tower);
            isSelected = true;
        }
    }
    public override void OnTowerDeselected(Tower tower)
    {
        if (tower.towerModel.name.Contains("AncientMonkey-AncientMonkey"))
        {
            InGame game = InGame.instance;
            RectTransform rect = game.uiRect;
            isSelected = false;
            if (MenuUi.upgradeMenu)
            {
                MenuUi.upgradeMenu.Hide();
            }

        }
    }
    public override void OnRoundEnd()
    {
        if (mod.foolsGold == true)
        {
            ChallengeModes.FoolsGold();
        }

        if (mod.errorCode == true)
        {
            ChallengeModes.ErrorCode();
        }
    }
    [RegisterTypeInIl2Cpp(false)]
    public class MenuUi : MonoBehaviour
    {
        // Menus
        public static MenuUi? upgradeMenu;
        public static MenuUi? weaponMenu;
        public static MenuUi? abilityMenu;
        public static MenuUi? strengthMenu;
        public static MenuUi? extrasMenu;
        public static MenuUi? weaponSandboxMenu;
        public static MenuUi? abilitySandboxMenu;
        public static MenuUi? strengthSandboxMenu;

        // Panels
        public static MenuUi[]? panelSprites;
        public static MenuUi? weaponSelectBtn;
        public static MenuUi[]? weaponPanels;
        public static MenuUi? weaponNotePanel;
        public static MenuUi[]? abilityPanels;
        public static MenuUi? abilityNotePanel;
        public static MenuUi[]? strengthPanels;
        public static MenuUi? strengthNotePanel;
        public static MenuUi? abUpgradeMenu;

        // Text
        public static MenuUi? weaponCostText;
        public static MenuUi? abilityCostText;
        public static MenuUi? strengthCostText;
        public static MenuUi? weaponSlotText;
        public static MenuUi? abilitySlotText;
        public static MenuUi? strengthSlotText;
        public static MenuUi? luckValueText;
        public static MenuUi? luckCostText;
        public static MenuUi? gildedChanceText;
        public static MenuUi? gildedCostText;
        public static MenuUi? moneyBonusText;
        public static MenuUi? moneyCostText;
        public static MenuUi? weaponNotesName;
        public static MenuUi? weaponNotesText;

        public ModHelperInputField? input;

        public static void CreateUpgradeMenu(RectTransform rect, Tower tower)
        {
            if (mod.panelOpen == true) { return; }


            if (mod.upgradeActive == false)
            {
                mod.upgradeActive = true;

                ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 2200, 275, 3333, 550, new Vector2()), VanillaSprites.BrownInsertPanel);
                upgradeMenu = panel.AddComponent<MenuUi>();

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
                    //VanillaSprites.MainBGPanelHighlightTab,
                ];

                MenuUi[] panelSpritesArray = new MenuUi[sprites.Count()];
                for (int i = 0; i < sprites.Count(); i++)
                {
                    ModHelperPanel spritePanel = panel.AddPanel(new Info("sprite", 0, 0, 0), sprites[i]);

                    panelSpritesArray[i] = spritePanel.AddComponent<MenuUi>();
                }
                panelSprites = panelSpritesArray;


                // New Weapons
                ModHelperPanel newWeaponBox = panel.AddPanel(new Info("newWeaponBox", 1250, 275, 0, new Vector2()), VanillaSprites.BrownInsertPanel);

                ModHelperText newWeaponText = newWeaponBox.AddText(new Info("newWeaponText", 0, 205, 1000, 100), "New Weapon", 75);
                newWeaponText.Text.color = new Color(0, 1, 0);
                newWeaponText.Text.outlineColor = new Color(0.2f, 0.64f, 0.1f);

                ModHelperPanel newWeaponCostBox = newWeaponBox.AddPanel(new Info("newWeaponCostBox", 0, 85, 500, 100), VanillaSprites.BrownInsertPanel);
                ModHelperText newWeaponCostText = newWeaponCostBox.AddText(new Info("newWeaponCost", 0, 0, 500, 100), "", 65);
                newWeaponCostText.Text.color = new Color(1, 0.85f, 0);
                newWeaponCostText.Text.outlineColor = new Color(0.86f, 0.5f, 0f);
                newWeaponCostText.Text.outlineWidth *= 1.5f;
                weaponCostText = newWeaponCostText.AddComponent<MenuUi>();

                if (SandboxMode) { weaponCostText.GetComponent<ModHelperText>().Text.text = "FREE"; }
                else if (mod.abilityMayhem == true) { weaponCostText.GetComponent<ModHelperText>().Text.text = "Disabled"; }
                else { weaponCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.weaponCost)); }

                ModHelperButton newWeaponButton = newWeaponBox.AddButton(new Info("newWeaponButton", 0, -60, 500, 150), VanillaSprites.GreenBtnLong, new Action(() =>
                {
                    InGame game = InGame.instance;

                    if (SandboxMode)
                    {
                        RectTransform rect = game.uiRect;
                        WeaponSandbox.WpnSandboxPanel(rect, tower);
                        upgradeMenu.Hide();
                        return;
                    }

                    if (game.GetCash() >= mod.weaponCost && mod.abilityMayhem == false)
                    {
                        game.AddCash(-mod.weaponCost);
                        RectTransform rect = game.uiRect;
                        tower.worth += MathF.Round(mod.weaponCost * 0.7f);
                        mod.weaponCost = MathF.Round(mod.weaponCost + mod.weaponCostIncreaser);
                        mod.weaponCostIncreaser *= 1.2f;
                        weaponCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.weaponCost));
                        WeaponPanels.NewWeaponPanel(rect, tower);
                        upgradeMenu.Hide();
                    }
                }));
                newWeaponButton.AddText(new Info("newWeaponBuy", 0, 0, 500, 150), "Buy", 80);

                newWeaponBox.AddText(new Info("newWeaponDesc", 0, -205, 750, 100), "Adds a new weapon", 50);


                // New Abilities
                ModHelperPanel newAbilityBox = panel.AddPanel(new Info("newAbilitynBox", 2083, 275, 0, new Vector2()), VanillaSprites.BrownInsertPanel);

                ModHelperText newAbilityText = newAbilityBox.AddText(new Info("newAbilityText", 0, 205, 1000, 100), "New Ability", 75);
                newAbilityText.Text.color = new Color(0, 1, 0);
                newAbilityText.Text.outlineColor = new Color(0.2f, 0.64f, 0.1f);

                ModHelperPanel newAbilityCostBox = newAbilityBox.AddPanel(new Info("newAbilityCostBox", 0, 85, 500, 100), VanillaSprites.BrownInsertPanel);
                ModHelperText newAbilityCostText = newAbilityCostBox.AddText(new Info("newAbilityCost", 0, 0, 500, 100), "", 65);
                newAbilityCostText.Text.color = new Color(1, 0.85f, 0);
                newAbilityCostText.Text.outlineColor = new Color(0.86f, 0.5f, 0f);
                newAbilityCostText.Text.outlineWidth *= 1.5f;
                abilityCostText = newAbilityCostText.AddComponent<MenuUi>();

                if (SandboxMode) { abilityCostText.GetComponent<ModHelperText>().Text.text = "FREE"; }
                else { abilityCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.abilityCost)); }

                ModHelperButton newAbilityButton = newAbilityBox.AddButton(new Info("newAbilityButton", 0, -60, 500, 150), VanillaSprites.GreenBtnLong, new Action(() =>
                {
                    InGame game = InGame.instance;

                    if (SandboxMode)
                    {
                        RectTransform rect = game.uiRect;
                        AbilitySandbox.AbilitySandboxPanel(rect, tower);
                        upgradeMenu.Hide();
                        return;
                    }

                    if (game.GetCash() >= mod.abilityCost)
                    {
                        game.AddCash(-mod.abilityCost);
                        RectTransform rect = game.uiRect;
                        tower.worth += MathF.Round(mod.abilityCost * 0.7f);
                        mod.abilityCost = MathF.Round(mod.abilityCost + mod.abilityCostIncreaser);
                        mod.abilityCostIncreaser *= 1.2f;
                        abilityCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.abilityCost));
                        AbilityPanels.NewAbilityPanel(rect, tower);
                        upgradeMenu.Hide();
                    }
                }));
                newAbilityButton.AddText(new Info("newAbilityBuy", 0, 0, 500, 150), "Buy", 80);

                newAbilityBox.AddText(new Info("newAbilityDesc", 0, -205, 750, 100), "Adds a new ability", 50);

                newAbilityBox.AddButton(new Info("upgradeAbilityButton", 325, -60, 100), VanillaSprites.SettingsBtn, new Action(() =>
                {
                    if (!SandboxMode)
                    {
                        UpgradeAbilities.UpgradeAbilityPanel(rect, tower);
                        upgradeMenu.Hide();
                    }
                }));


                // Stronger Weapons
                ModHelperPanel newStrengthBox = panel.AddPanel(new Info("newStrengthBox", 417, 275, 0, new Vector2()), VanillaSprites.BrownInsertPanel);

                ModHelperText newStrengthText = newStrengthBox.AddText(new Info("newStrengthText", 0, 205, 1000, 100), "New Strength", 75);
                newStrengthText.Text.color = new Color(0, 1, 0);
                newStrengthText.Text.outlineColor = new Color(0.2f, 0.64f, 0.1f);

                ModHelperPanel newStrengthCostBox = newStrengthBox.AddPanel(new Info("newStrengthCostBox", 0, 85, 500, 100), VanillaSprites.BrownInsertPanel);
                ModHelperText newStrengthCostText = newStrengthCostBox.AddText(new Info("newStrengthCost", 0, 0, 500, 100), "", 65);
                newStrengthCostText.Text.color = new Color(1, 0.85f, 0);
                newStrengthCostText.Text.outlineColor = new Color(0.86f, 0.5f, 0f);
                newStrengthCostText.Text.outlineWidth *= 1.5f;
                strengthCostText = newStrengthCostText.AddComponent<MenuUi>();

                if (SandboxMode) { strengthCostText.GetComponent<ModHelperText>().Text.text = "FREE"; }
                else if (mod.abilityMayhem == true) { strengthCostText.GetComponent<ModHelperText>().Text.text = "Disabled"; }
                else { strengthCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.strengthCost)); }

                ModHelperButton newStrengthButton = newStrengthBox.AddButton(new Info("newStrengthButton", 0, -60, 500, 150), VanillaSprites.GreenBtnLong, new Action(() =>
                {
                    InGame game = InGame.instance;

                    if (SandboxMode)
                    {
                        RectTransform rect = game.uiRect;
                        StrengthSandbox.StrengthSandboxPanel(rect, tower);
                        upgradeMenu.Hide();
                        return;
                    }

                    if (game.GetCash() >= mod.strengthCost && mod.abilityMayhem == false)
                    {
                        game.AddCash(-mod.strengthCost);
                        RectTransform rect = game.uiRect;
                        tower.worth += MathF.Round(mod.strengthCost * 0.7f);
                        mod.strengthCost = MathF.Round(mod.strengthCost + mod.strengthCostIncreaser);
                        mod.strengthCostIncreaser *= 1.2f;
                        strengthCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.strengthCost));
                        StrengthPanels.NewStrengthPanel(rect, tower);
                        upgradeMenu.Hide();
                    }
                }));
                newStrengthButton.AddText(new Info("newStrengthBuy", 0, 0, 500, 150), "Buy", 80);

                newStrengthBox.AddText(new Info("newStrengthDesc", 0, -205, 750, 100), "Makes weapons stronger", 50);


                // Extras Menu
                ModHelperPanel extraBox = panel.AddPanel(new Info("extraBox", 2916, 275, 0, new Vector2()), VanillaSprites.BrownInsertPanel);

                ModHelperText extraText = extraBox.AddText(new Info("extraText", 0, 145, 1000, 100, new Vector2()), "Extras Panel", 70);
                extraText.Text.color = new Color(0, 1, 0);
                extraText.Text.outlineColor = new Color(0.2f, 0.64f, 0.1f);

                ModHelperButton extraBtn = extraBox.AddButton(new Info("extraBtn", 0, 0, 500, 150, new Vector2()), VanillaSprites.GreenBtnLong, new System.Action(() =>
                {
                    if (mod.mastery == false)
                    {
                        ExtrasPanels.ExtrasPanel(rect, tower);
                        upgradeMenu.Hide();
                    }
                }));
                ModHelperText extraOpen = extraBtn.AddText(new Info("extraOpen", 0, 0, 500, 150), "", 70);

                extraBox.AddText(new Info("extraDesc", 0, -145, 750, 100), "Contains additional upgrades", 50);

                if (mod.mastery == true) { extraOpen.Text.text = "Disabled"; }
                else { extraOpen.Text.text = "Open"; }
            }
            else
            {
                upgradeMenu.Show();
            }
        }
    }
}