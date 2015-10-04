using System;
using Server;
using Server.Items;

/*
Detect Hidden, teleports targets to itself, receives half damage from the summons and pets. Taints your mana, causing any mana damaging ability to do damage to you relative to how much mana the ability cost.

4 Crystal of Shame, Undying Flesh, Chaga Mushroom, Faery Dust


*/


namespace Server.Mobiles
{
 [CorpseName( "a chaos vortex corpse" )]
 public class ChaosVortex : BaseCreature
 {
  [Constructable]
  public ChaosVortex () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
  {
   Name = "a chaos vortex";
   Body = 131;
   BaseSoundID = 768;

   SetStr( 400, 450 );
   SetDex( 180, 220 );
   SetInt( 90, 110 );

   SetHits( 26800, 27200 );

   SetDamage( 21, 23 );

   SetDamageType( ResistanceType.Physical, 20 );
   SetDamageType( ResistanceType.Fire, 20 );
   SetDamageType( ResistanceType.Energy, 20 );
   SetDamageType( ResistanceType.Poison, 20 );
   SetDamageType( ResistanceType.Cold, 20 );

 

   SetResistance( ResistanceType.Physical, 65, 75 );
   SetResistance( ResistanceType.Fire, 65, 75 );
   SetResistance( ResistanceType.Poison, 65, 75 );
   SetResistance( ResistanceType.Energy, 65, 75 );
   SetResistance( ResistanceType.Cold, 65, 75 );

   //SetSkill( SkillName.EvalInt, 60.1, 75.0 );
   //SetSkill( SkillName.Magery, 60.1, 75.0 );
   SetSkill( SkillName.MagicResist, 100.0, 110.0 );
   SetSkill( SkillName.Tactics, 110.0, 125.0 );
   SetSkill( SkillName.Wrestling, 125.0, 133.0 );

   Fame = 10000;
   Karma = -10000;

   VirtualArmor = 56;
  }

  public override void GenerateLoot()
  {
   AddLoot( LootPack.Rich );
   AddLoot( LootPack.Average );
   AddLoot( LootPack.Gems );
   //shame crystal
  }

  public override int TreasureMapLevel{ get{ return Core.AOS ? 4 : 5; } }

  public ChaosVortex ( Serial serial ) : base( serial )
  {
  }

  public override void Serialize( GenericWriter writer )
  {
   base.Serialize( writer );
   writer.Write( (int) 0 );
  }

  public override void Deserialize( GenericReader reader )
  {
   base.Deserialize( reader );
   int version = reader.ReadInt();
  }
 }
}