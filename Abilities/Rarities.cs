using System.Collections.Generic;
using WeaponPacks;

namespace AncientMonkey.Ability.Rarities;

public class Common : AbilityRarityTemplate
{
    public override float RarityIncreaser => 0;
    public override float TrueMinimumValue => 0;
    public override Rarity AbilityRarity => Rarity.Common;
    public override int Level => 1;
    public override int Order => 0;
    public override void AbilityList(List<AbilityTemplate> abilityList)
    {
        foreach (var ability in GetContent<AbilityTemplate>())
        {
            if (ability.enabled && ability.AbilityRarity == AbilityTemplate.Rarity.Common)
            {
                abilityList.Add(ability);
            }
        }
    }
}
public class Rare : AbilityRarityTemplate
{
    public override float RarityIncreaser => 5f;
    public override float TrueMinimumValue => 1;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override int Level => 1;
    public override int Order => 1;
    public override void AbilityList(List<AbilityTemplate> abilityList)
    {
        foreach (var ability in GetContent<AbilityTemplate>())
        {
            if (ability.enabled && ability.AbilityRarity == AbilityTemplate.Rarity.Rare)
            {
                abilityList.Add(ability);
            }
        }
    }
}
public class Epic : AbilityRarityTemplate
{
    public override float RarityIncreaser => 2f;
    public override float TrueMinimumValue => 30;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override int Level => 1;
    public override int Order => 2;
    public override void AbilityList(List<AbilityTemplate> abilityList)
    {
        foreach (var ability in GetContent<AbilityTemplate>())
        {
            if (ability.enabled && ability.AbilityRarity == AbilityTemplate.Rarity.Epic)
            {
                abilityList.Add(ability);
            }
        }
    }
}
public class Legendary : AbilityRarityTemplate
{
    public override float RarityIncreaser => 1;
    public override float TrueMinimumValue => 60;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override int Level => 1;
    public override int Order => 3;
    public override void AbilityList(List<AbilityTemplate> abilityList)
    {
        foreach (var ability in GetContent<AbilityTemplate>())
        {
            if (ability.enabled && ability.AbilityRarity == AbilityTemplate.Rarity.Legendary)
            {
                abilityList.Add(ability);
            }
        }
    }
}
public class Godly : AbilityRarityTemplate
{
    public override float RarityIncreaser => 0.3f;
    public override float TrueMinimumValue => 90;
    public override Rarity AbilityRarity => Rarity.Godly;
    public override int Level => 2;
    public override int Order => 4;
    public override void AbilityList(List<AbilityTemplate> abilityList)
    {
        foreach (var ability in GetContent<AbilityTemplate>())
        {
            if (ability.enabled && ability.AbilityRarity == AbilityTemplate.Rarity.Godly)
            {
                abilityList.Add(ability);
            }
        }
    }
}