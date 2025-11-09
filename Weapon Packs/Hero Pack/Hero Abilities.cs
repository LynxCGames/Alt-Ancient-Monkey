using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using UnityEngine;
using System.Linq;

namespace WeaponPacks;

// #### Common ####

public class CocktailOfFire : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 1;
    public override Rarity AbilityRarity => Rarity.Common;
    public override string AbilityName => "Cocktail of Fire";
    public override string CodeName => "CocktailOfFireLvl3";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CocktailOfFireAA);
    public override int upgradeCost => 32000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Gwendolin 3").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("Gwendolin 20").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedCocktailOfFireLvl20";
        ab.displayName = "Cocktail Of Fire Lvl 20";
        ab.icon = GetSpriteReference("CocktailOfFireLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class ConcussiveShell : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 1;
    public override Rarity AbilityRarity => Rarity.Common;
    public override string AbilityName => "Concusive Shell";
    public override string CodeName => "ConcussiveShellLvl3";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ConcussiveShellAA);
    public override int upgradeCost => 18000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("StrikerJones 3").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("StrikerJones 20").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedConcussiveShellLvl20";
        ab.displayName = "Concussive Shell Lvl 20";
        ab.icon = GetSpriteReference("ConcussiveShellLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class Brambles : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 1;
    public override Rarity AbilityRarity => Rarity.Common;
    public override string AbilityName => "Brambles";
    public override string CodeName => "BramblesLvl3";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BramblesAA);
    public override int upgradeCost => 14000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("ObynGreenfoot 3").GetAbility().Duplicate();
        var target = Game.instance.model.GetTowerFromId("Gwendolin 3").GetAbility().GetDescendant<TargetSelectedPointModel>().Duplicate();
        target.useTerrainHeight = false;
        ab.GetDescendant<ActivateAttackModel>().attacks[0].AddBehavior(target);
        ab.GetDescendant<ActivateAttackModel>().attacks[0].targetProvider = target;
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("ObynGreenfoot 20").GetAbility().Duplicate();
        var target = Game.instance.model.GetTowerFromId("Gwendolin 3").GetAbility().GetDescendant<TargetSelectedPointModel>().Duplicate();
        target.useTerrainHeight = false;
        ab.GetDescendant<ActivateAttackModel>().attacks[0].AddBehavior(target);
        ab.GetDescendant<ActivateAttackModel>().attacks[0].targetProvider = target;
        ab.name = "AbilityUpgradedBramblesLvl20";
        ab.displayName = "Brambles Lvl 20";
        ab.icon = GetSpriteReference("BramblesLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class StormOfArrows : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override string AbilityName => "Storm of Arrows";
    public override string CodeName => "StormOfArrowsLvl10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.StormOfArrowsAA);
    public override int upgradeCost => 20000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Quincy 10").GetAbility(1).Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("Quincy 20").GetAbility(1).Duplicate();
        ab.name = "AbilityUpgradedStormOfArrowsLvl20";
        ab.displayName = "Storm Of Arrows Lvl 20";
        ab.icon = GetSpriteReference("StormOfArrowsLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class Firestorm : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override string AbilityName => "Firestorm";
    public override string CodeName => "FirestormLvl10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.FirestormAA);
    public override int upgradeCost => 38000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Gwendolin 10").GetAbility(1).Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("Gwendolin 20").GetAbility(1).Duplicate();
        ab.name = "AbilityUpgradedFirestormLvl20";
        ab.displayName = "Firestorm Lvl 20";
        ab.icon = GetSpriteReference("FirestormLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class MOABBarrage : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override string AbilityName => "MOAB Barrage";
    public override string CodeName => "MOABBarrageLvl10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MOABBarrageAA);
    public override int upgradeCost => 22000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("CaptainChurchill 10").GetAbility(1).Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("CaptainChurchill 10").GetAbility(1).Duplicate();
        ab.name = "AbilityUpgradedMOABBarrageLvl20";
        ab.displayName = "MOAB Barrage Lvl 20";
        ab.icon = GetSpriteReference("MOABBarrageLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class BenjaminEndOfRoundCash : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Ben End Round Cash";
    public override string CodeName => "BenEndOfRoundCash";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BenjaminIcon);
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Benjamin 20").GetBehavior<PerRoundCashBonusTowerModel>().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class KineticCharge : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Kinetic Charge";
    public override string CodeName => "KineticCharge";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.KineticChargeAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Rosalia 10").GetAbility(2).Duplicate();
        ab.GetBehavior<ActivateAttackModel>().attacks[0].weapons[0].RemoveBehavior<AnimateAirUnitOnFireModel>();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class SoulHarvest : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Soul Harvest";
    public override string CodeName => "SoulHarvest";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SoulHarvestAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Corvus 3").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}

// #### Legendary ####

public class BallOfLight : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "Ball Of Light";
    public override string CodeName => "BallOfLight";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BallofLightAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Adora 20").GetAbility(2).Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class MOABHex : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "MOAB Hex";
    public override string CodeName => "MOABHex";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MoabHexAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Ezili 20").GetAbility(2).Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class PermaUCAV : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "Perma UCAV";
    public override string CodeName => "PermaUCAV";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.UcavAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        phoenix.towerModel = Game.instance.model.GetTowerFromId("UCAVPerma").Duplicate();
        phoenix.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class PsionicScream : AbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "Psionic Scream";
    public override string CodeName => "PsionicScream";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PsionicScreamAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Psi 20").GetAbility(1).Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}

// #### Upgraded ####

public class BramblesLvl20 : UpgradedAbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override string AbilityName => "Brambles Lvl 20";
    public override Sprite CustomIcon => GetSprite("BramblesLvl20");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("ObynGreenfoot 20").GetAbility().Duplicate();
        var target = Game.instance.model.GetTowerFromId("Gwendolin 3").GetAbility().GetDescendant<TargetSelectedPointModel>().Duplicate();
        target.useTerrainHeight = false;
        ab.GetDescendant<ActivateAttackModel>().attacks[0].AddBehavior(target);
        ab.GetDescendant<ActivateAttackModel>().attacks[0].targetProvider = target;
        ab.name = "AbilityUpgradedBramblesLvl20";
        ab.displayName = "Brambles Lvl 20";
        ab.icon = GetSpriteReference("BramblesLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class CocktailOfFireLvl20 : UpgradedAbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override string AbilityName => "Cocktail of Fire Lvl 20";
    public override Sprite CustomIcon => GetSprite("CocktailOfFireLvl20");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Gwendolin 20").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedCocktailOfFireLvl20";
        ab.displayName = "Cocktail Of Fire Lvl 20";
        ab.icon = GetSpriteReference("CocktailOfFireLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class ConcussiveShellLvl20 : UpgradedAbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override string AbilityName => "Concussive Shell Lvl 20";
    public override Sprite CustomIcon => GetSprite("ConcussiveShellLvl20");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("StrikerJones 20").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedConcussiveShellLvl20";
        ab.displayName = "Concussive Shell Lvl 20";
        ab.icon = GetSpriteReference("ConcussiveShellLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class FirestormLvl20 : UpgradedAbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override string AbilityName => "Firestorm Lvl 20";
    public override Sprite CustomIcon => GetSprite("FirestormLvl20");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Gwendolin 20").GetAbility(1).Duplicate();
        ab.name = "AbilityUpgradedFirestormLvl20";
        ab.displayName = "Firestorm Lvl 20";
        ab.icon = GetSpriteReference("FirestormLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class MOABBarrageLvl20 : UpgradedAbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override string AbilityName => "MOAB Barrage Lvl 20";
    public override Sprite CustomIcon => GetSprite("MOABBarrageLvl20");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("CaptainChurchill 10").GetAbility(1).Duplicate();
        ab.name = "AbilityUpgradedMOABBarrageLvl20";
        ab.displayName = "MOAB Barrage Lvl 20";
        ab.icon = GetSpriteReference("MOABBarrageLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class StormOfArrowsLvl20 : UpgradedAbilityTemplate
{
    public override string WeaponPack => "HeroPack";
    public override string AbilityName => "Storm of Arrows Lvl 20";
    public override Sprite CustomIcon => GetSprite("StormOfArrowsLvl20");
    public override SpriteReference Icon => CreateSpriteReference("");
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Quincy 20").GetAbility(1).Duplicate();
        ab.name = "AbilityUpgradedStormOfArrowsLvl20";
        ab.displayName = "Storm Of Arrows Lvl 20";
        ab.icon = GetSpriteReference("StormOfArrowsLvl20");
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}