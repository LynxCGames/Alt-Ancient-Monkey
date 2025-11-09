using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;

namespace WeaponPacks;

// #### Godly ####

public class MeteorImpact : AbilityTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity AbilityRarity => Rarity.Godly;
    public override string AbilityName => "Meteor Impact";
    public override string CodeName => "MeteorImpact";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TackShooterParagonMeteorAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("TackShooter-Paragon").GetAbility(1).Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class ISABMissile : AbilityTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity AbilityRarity => Rarity.Godly;
    public override string AbilityName => "I.S.A.B.M.";
    public override string CodeName => "ISABMissile";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BombParagonOblivionMissileSiloAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("BombShooter-Paragon").GetAbility(1).Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class BadHarpoon : AbilityTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity AbilityRarity => Rarity.Godly;
    public override string AbilityName => "BAD Harpoon";
    public override string CodeName => "BadHarpoon";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.NavarchOfTheSeasAAIcon);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-Paragon").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class FinalStrike : AbilityTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity AbilityRarity => Rarity.Godly;
    public override string AbilityName => "Final Strike";
    public override string CodeName => "FinalStrike";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.FinalStrikeIconAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("MonkeySub-Paragon").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}/*
public class CarpetBomb : AbilityTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity AbilityRarity => Rarity.Godly;
    public override string AbilityName => "Carpet Bomb";
    public override string CodeName => "";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CarpetBombIconAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("MonkeyAce-Paragon").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}*/
public class PermaDarkPhoenix : AbilityTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity AbilityRarity => Rarity.Godly;
    public override string AbilityName => "Dark Phoenix";
    public override string CodeName => "PermaDarkPhoenix";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PhoenixRebirthIconAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var phoenixTower = Game.instance.model.GetTowerFromId("DarkPhoenixV1").Duplicate();
        phoenixTower.GetAttackModel().weapons[0].RemoveBehavior<MagusPerfectusGraveyardModel>();
        phoenix.towerModel = phoenixTower;
        phoenix.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class Spikeageddon : AbilityTemplate
{
    public override string WeaponPack => "DefaultPack";
    public override int SandboxIndex => 6;
    public override Rarity AbilityRarity => Rarity.Godly;
    public override string AbilityName => "Spikeageddon";
    public override string CodeName => "Spikeageddon";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SpikeFactoryParagonSpikeageddonAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("SpikeFactory-Paragon").GetAbility(1).Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}/*
public class ParagonOverclock : AbilityTemplate
{
    public override string WeaponPack => "";
    public override int SandboxIndex => 6;
    public override Rarity AbilityRarity => Rarity.Godly;
    public override string AbilityName => "Paragon Overclock";
    public override string CodeName => "";
    public override SpriteReference Icon => CreateSpriteReference("b94f106b8f9694aff9498c611a126ac2");
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("EngineerMonkey-Paragon").GetAbility(1).Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}*/