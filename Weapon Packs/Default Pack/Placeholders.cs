using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using static AncientMonkey.AncientMonkey;
using BTD_Mod_Helper.Api.Components;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using AncientMonkey;
using UnityEngine;

namespace WeaponPacks;

// #### Placeholder ####

public class CommonPlaceholder : WeaponTemplate
{
    public override string WeaponPack => "PlaceholderPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Placeholder";
    public override string CodeName => "Common Weapons";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UpgradeContainerGrey);
    public override string? Notes => "Notes: Just a placeholder. Will return cash spent and won't increase the new weapon cost.";
    public override string[] GildedEffects => [""];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        InGame game = InGame.instance;
        var mod = AncientMonkey.AncientMonkey.mod;

        if (mod.upgradeActive)
        {
            mod.weaponCostIncreaser /= 1.2f;
            mod.weaponCost = MathF.Round(mod.weaponCost - mod.weaponCostIncreaser);
            tower.worth -= MathF.Round(mod.weaponCost / 0.7f);
            game.AddCash(mod.weaponCost);
            MenuUi.weaponCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.weaponCost));
        }
    }
}
public class RarePlaceholder : WeaponTemplate
{
    public override string WeaponPack => "PlaceholderPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Placeholder";
    public override string CodeName => "Rare Weapons";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UpgradeContainerGrey);
    public override string? Notes => "Notes: Just a placeholder. Will return cash spent and won't increase the new weapon cost.";
    public override string[] GildedEffects => [""];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        InGame game = InGame.instance;
        var mod = AncientMonkey.AncientMonkey.mod;

        if (mod.upgradeActive)
        {
            mod.weaponCostIncreaser /= 1.2f;
            mod.weaponCost = MathF.Round(mod.weaponCost - mod.weaponCostIncreaser);
            tower.worth -= MathF.Round(mod.weaponCost / 0.7f);
            game.AddCash(mod.weaponCost);
            MenuUi.weaponCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.weaponCost));
        }
    }
}
public class EpicPlaceholder : WeaponTemplate
{
    public override string WeaponPack => "PlaceholderPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Placeholder";
    public override string CodeName => "Epic Weapons";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UpgradeContainerGrey);
    public override string? Notes => "Notes: Just a placeholder. Will return cash spent and won't increase the new weapon cost.";
    public override string[] GildedEffects => [""];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        InGame game = InGame.instance;
        var mod = AncientMonkey.AncientMonkey.mod;

        if (mod.upgradeActive)
        {
            mod.weaponCostIncreaser /= 1.2f;
            mod.weaponCost = MathF.Round(mod.weaponCost - mod.weaponCostIncreaser);
            tower.worth -= MathF.Round(mod.weaponCost / 0.7f);
            game.AddCash(mod.weaponCost);
            MenuUi.weaponCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.weaponCost));
        }
    }
}
public class LegendaryPlaceholder : WeaponTemplate
{
    public override string WeaponPack => "PlaceholderPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Placeholder";
    public override string CodeName => "Legendary Weapons";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UpgradeContainerGrey);
    public override string? Notes => "Notes: Just a placeholder. Will return cash spent and won't increase the new weapon cost.";
    public override string[] GildedEffects => [""];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        InGame game = InGame.instance;
        var mod = AncientMonkey.AncientMonkey.mod;

        if (mod.upgradeActive)
        {
            mod.weaponCostIncreaser /= 1.2f;
            mod.weaponCost = MathF.Round(mod.weaponCost - mod.weaponCostIncreaser);
            tower.worth -= MathF.Round(mod.weaponCost / 0.7f);
            game.AddCash(mod.weaponCost);
            MenuUi.weaponCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.weaponCost));
        }
    }
}
public class MythicPlaceholder : WeaponTemplate
{
    public override string WeaponPack => "PlaceholderPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Placeholder";
    public override string CodeName => "Mythic Weapons";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UpgradeContainerGrey);
    public override string? Notes => "Notes: Just a placeholder. Will return cash spent and won't increase the new weapon cost.";
    public override string[] GildedEffects => [""];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        InGame game = InGame.instance;
        var mod = AncientMonkey.AncientMonkey.mod;

        if (mod.upgradeActive)
        {
            mod.weaponCostIncreaser /= 1.2f;
            mod.weaponCost = MathF.Round(mod.weaponCost - mod.weaponCostIncreaser);
            tower.worth -= MathF.Round(mod.weaponCost / 0.7f);
            game.AddCash(mod.weaponCost);
            MenuUi.weaponCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.weaponCost));
        }
    }
}

public class CommonPlaceholderAb : AbilityTemplate
{
    public override string WeaponPack => "PlaceholderPack";
    public override int SandboxIndex => 1;
    public override Rarity AbilityRarity => Rarity.Common;
    public override string AbilityName => "Placeholder";
    public override string CodeName => "Common Abilities";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UpgradeContainerGrey);
    public override void EditTower(Tower tower)
    {
        InGame game = InGame.instance;
        var mod = AncientMonkey.AncientMonkey.mod;

        mod.abilityCostIncreaser /= 1.2f;
        mod.abilityCost = MathF.Round(mod.abilityCost - mod.abilityCostIncreaser);
        tower.worth -= MathF.Round(mod.abilityCost / 0.7f);
        game.AddCash(mod.abilityCost);
        MenuUi.abilityCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.abilityCost));
    }
    public override void Upgrade(Tower tower) { }
}
public class RarePlaceholderAb : AbilityTemplate
{
    public override string WeaponPack => "PlaceholderPack";
    public override int SandboxIndex => 2;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override string AbilityName => "Placeholder";
    public override string CodeName => "Rare Abilities";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UpgradeContainerGrey);
    public override void EditTower(Tower tower)
    {
        InGame game = InGame.instance;
        var mod = AncientMonkey.AncientMonkey.mod;

        mod.abilityCostIncreaser /= 1.2f;
        mod.abilityCost = MathF.Round(mod.abilityCost - mod.abilityCostIncreaser);
        tower.worth -= MathF.Round(mod.abilityCost / 0.7f);
        game.AddCash(mod.abilityCost);
        MenuUi.abilityCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.abilityCost));
    }
    public override void Upgrade(Tower tower) { }
}
public class EpicPlaceholderAb : AbilityTemplate
{
    public override string WeaponPack => "PlaceholderPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Placeholder";
    public override string CodeName => "Epic Abilities";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UpgradeContainerGrey);
    public override void EditTower(Tower tower)
    {
        InGame game = InGame.instance;
        var mod = AncientMonkey.AncientMonkey.mod;

        mod.abilityCostIncreaser /= 1.2f;
        mod.abilityCost = MathF.Round(mod.abilityCost - mod.abilityCostIncreaser);
        tower.worth -= MathF.Round(mod.abilityCost / 0.7f);
        game.AddCash(mod.abilityCost);
        MenuUi.abilityCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.abilityCost));
    }
    public override void Upgrade(Tower tower) { }
}
public class LegendaryPlaceholderAb : AbilityTemplate
{
    public override string WeaponPack => "PlaceholderPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "Placeholder";
    public override string CodeName => "Legendary Abilities";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UpgradeContainerGrey);
    public override void EditTower(Tower tower)
    {
        InGame game = InGame.instance;
        var mod = AncientMonkey.AncientMonkey.mod;

        mod.abilityCostIncreaser /= 1.2f;
        mod.abilityCost = MathF.Round(mod.abilityCost - mod.abilityCostIncreaser);
        tower.worth -= MathF.Round(mod.abilityCost / 0.7f);
        game.AddCash(mod.abilityCost);
        MenuUi.abilityCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)Mathf.Round(mod.abilityCost));
    }
    public override void Upgrade(Tower tower) { }
}