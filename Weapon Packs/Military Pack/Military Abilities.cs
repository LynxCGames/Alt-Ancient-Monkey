using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using System.Linq;

namespace WeaponPacks;

// #### Common ####

// #### Rare ####

public class SupplyDrop : AbilityTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 2;
    public override Rarity AbilityRarity => Rarity.Rare;
    public override string AbilityName => "Supply Drop";
    public override string CodeName => "SupplyDrop";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CashDropUpgradeIcon);
    public override int upgradeCost => 12000;
    public override string upgradeName => "EliteSniper";
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("SniperMonkey-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        towerModel.RemoveBehavior(towerModel.GetAbilities().First(model => model.name.Contains(CodeName)));

        var ab = Game.instance.model.GetTowerFromId("SniperMonkey-050").GetAbility().Duplicate();
        ab.name = "AbilityEpicEliteSniper";
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class EliteSniper : AbilityTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Elite Sniper";
    public override string CodeName => "EliteSniper";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.EliteSniperUpgradeIcon);
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("SniperMonkey-050").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class FirstStrikeCapability : AbilityTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "First Strike Capability";
    public override string CodeName => "FirstStrikeCapability";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.FirstStrikeCapabilityUpgradeIconAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("MonkeySub-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class RocketStorm : AbilityTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity AbilityRarity => Rarity.Epic;
    public override string AbilityName => "Rocket Storm";
    public override string CodeName => "RocketStorm";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RocketStormUpgradeIconAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("DartlingGunner-040").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}

// #### Legendary ####

public class PirateLord : AbilityTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "Pirate Lord";
    public override string CodeName => "PirateLord";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PirateLordUpgradeIconAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-050").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}
public class PopAndAwe : AbilityTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity AbilityRarity => Rarity.Legendary;
    public override string AbilityName => "Pop and Awe";
    public override string CodeName => "PopAndAwe";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PopandAweUpgradeIconAA);
    public override void EditTower(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var ab = Game.instance.model.GetTowerFromId("MortarMonkey-050").GetAbility().Duplicate();
        ab.name = "Ability" + AbilityRarity + CodeName;
        towerModel.AddBehavior(ab);
        tower.UpdateRootModel(towerModel);
    }
    public override void Upgrade(Tower tower) { }
}