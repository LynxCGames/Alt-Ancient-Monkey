using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using System.Linq;

namespace WeaponPacks;

// #### Common ####

public class BladeMaelstrom : AbilityTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 1;
    public override Rarity AbilityRarity => Rarity.Common;
    public override string AbilityName => "Blade Maelstrom";
    public override string CodeName => "BladeMaelstrom";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BladeMaelstromUpgradeIconAA);
    public override int upgradeCost => 9000;
    public override string upgradeName => "SuperMaelstrom";
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("TackShooter-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("TackShooter-050").GetAbility().Duplicate();
        ab.name = "AbilityEpicSuperMaelstrom";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class SnowStorm : AbilityTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 1;
    public override Rarity AbilityRarity => Rarity.Common;
    public override string AbilityName => "Snowstorm";
    public override string CodeName => "SnowStorm";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SnowstormUpgradeIcon);
    public override int upgradeCost => 10000;
    public override string upgradeName => "AbsoluteZero";
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("IceMonkey-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("IceMonkey-050").GetAbility().Duplicate();
        ab.name = "AbilityEpicAbsoluteZero";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class GlueStrike : AbilityTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 2;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override string AbilityName => "Glue Strike";
    public override string CodeName => "GlueStrike";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GlueStrikeUpgradeIcon);
    public override int upgradeCost => 8000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("GlueGunner-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("GlueGunner-050").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedGlueStorm";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class TakeAim : AbilityTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 2;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override string AbilityName => "Take Aim";
    public override string CodeName => "TakeAimT3";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TakeAimAAIcon);
    public override int upgradeCost => 2000;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Desperado-030").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("Desperado-050").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedTakeAimT4";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class MoabEliminatorAA : AbilityTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Moab Eliminator";
    public override string CodeName => "MoabEliminatorAA";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MoabEliminatorUpgradeIcon);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("BombShooter-050").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class SuperMaelstrom : AbilityTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Super Maelstrom";
    public override string CodeName => "SuperMaelstrom";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SuperMaelstromUpgradeIconAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("TackShooter-050").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class AbsoluteZero : AbilityTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Absolute Zero";
    public override string CodeName => "AbsoluteZero";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.AbsoluteZeroUpgradeIcon);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("IceMonkey-050").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}

// #### Legendary ####

// #### Upgraded ####

public class GlueStorm : UpgradedAbilityTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override string AbilityName => "Glue Storm";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GlueStormUpgradeIcon);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("GlueGunner-050").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedGlueStorm";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}
public class TakeAimT4 : UpgradedAbilityTemplate
{
    public override string WeaponPack => "PrimaryPack";
    public override string AbilityName => "Take Aim T4";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TakeAimAATier4Icon);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("Desperado-050").GetAbility().Duplicate();
        ab.name = "AbilityUpgradedTakeAimT4";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}