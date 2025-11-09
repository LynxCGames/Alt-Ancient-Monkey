using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using System.Collections.Generic;
using UnityEngine;

namespace WeaponPacks;

public abstract class WeaponTemplate : ModContent 
{
    public override void Register() { }
    public abstract string WeaponPack { get; }
    public abstract int SandboxIndex { get; }
    public abstract Rarity WeaponRarity { get; }
    public abstract string WeaponName { get; }
    public abstract string CodeName { get; }
    public virtual Sprite CustomIcon { get; set; }
    public abstract SpriteReference Icon { get; }
    public virtual bool IsCamo { get; }
    public virtual bool IsLead { get; }
    public virtual string? Notes { get; }
    public virtual string[]? GildedEffects { get; }
    public abstract void EditTower(Tower tower, bool gilded, string gildedEffect, int degree);
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
    public virtual bool CreateTower { get; }
    public virtual bool MoneyMaker { get; }
}

public abstract class WeaponRarityTemplate : ModContent
{
    public override void Register() { }
    public abstract float RarityIncreaser { get; }
    public abstract float TrueMinimumValue { get; }
    public abstract Rarity WeaponRarity { get; }
    public abstract int Level { get; }
    public abstract int Order { get; }
    public abstract void WeaponList(List<WeaponTemplate> weaponList);
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

public abstract class GildedTemplate : ModContent
{
    public override void Register() { }
    public abstract string EffectName { get; }
    public abstract string Description { get; }
    public abstract string Icon { get; }
    public abstract void Gild(AttackModel weapon);
}

/*
["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "Shiny", "Fertilizer", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Stronger Compound", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
*/