using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponPacks;

public abstract class AbilityTemplate : ModContent
{
    public override void Register() { }
    public abstract string WeaponPack { get; }
    public abstract int SandboxIndex { get; }
    public abstract Rarity AbilityRarity { get; }
    public abstract string AbilityName { get; }
    public abstract string CodeName { get; }
    public virtual Sprite CustomIcon { get; set; }
    public abstract SpriteReference Icon { get; }
    public abstract void EditTower(Tower tower);
    public abstract void Upgrade(Tower tower);
    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Mythic,
        Godly,
        Omega,
        Glitched,
    }
    public float stackIndex = 0;
    public bool enabled = false;
    public virtual bool MoneyMaker { get; }
    public virtual int upgradeCost { get; }
    public virtual string upgradeName { get; }
}

public abstract class UpgradedAbilityTemplate : ModContent
{
    public override void Register() { }
    public abstract string WeaponPack { get; }
    public abstract string AbilityName { get; }
    public virtual Sprite CustomIcon { get; set; }
    public abstract SpriteReference Icon { get; }
    public abstract void EditTower(Tower tower);
    public float stackIndex = 0;
    public bool enabled = false;
}

public abstract class AbilityRarityTemplate : ModContent
{
    public override void Register() { }
    public abstract float RarityIncreaser { get; }
    public abstract float TrueMinimumValue { get; }
    public abstract Rarity AbilityRarity { get; }
    public abstract int Level { get; }
    public abstract int Order { get; }
    public abstract void AbilityList(List<AbilityTemplate> abilityList);
    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Mythic,
        Godly,
        Omega,
        Glitched,
    }
    public float minValue = 100;
    public float maxValue = 100;
    public float trueMinimum = 0;
}
