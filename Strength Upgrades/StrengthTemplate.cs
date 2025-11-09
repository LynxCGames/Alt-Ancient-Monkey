using BTD_Mod_Helper.Api;
using System.Collections.Generic;
using Il2CppAssets.Scripts.Simulation.Towers;

namespace AncientMonkey;

public abstract class StrengthTemplate : ModContent 
{
    public override void Register() { }
    public abstract int Index { get; }
    public abstract Rarity StrengthRarity { get; }
    public abstract string StrengthName { get; }
    public abstract string Description { get; }
    public abstract void EditTower(Tower tower);
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
    public int damageBonus = 0;
    public int pierceBonus = 0;
    public float rangeBonus = 1f;
    public float attackSpeedBonus = 1f;
    public float moneyBonus = 1f;
    public float projectileSpeed = 1;
    public float debuffDuration = 1;
    public float abilityCooldown = 1;
}

public abstract class StrengthRarityTemplate : ModContent
{
    public override void Register() { }
    public abstract float RarityIncreaser {  get; }
    public abstract float TrueMinimumValue { get; }
    public abstract Rarity StrengthRarity { get; }
    public abstract int Level { get; }
    public abstract int Order { get; }
    public abstract void StrengthList(List<StrengthTemplate> strengthList);
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