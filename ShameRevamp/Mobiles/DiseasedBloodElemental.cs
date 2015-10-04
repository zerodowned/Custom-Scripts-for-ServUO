using System;
using Server;
using Server.Items;

/*
Bleed, Dispel
*/

namespace Server.Mobiles
{
 [CorpseName( "a diseased blood elemental corpse" )]
 public class DiseasedBloodElemental : BaseCreature
 {
  [Constructable]
  public DiseasedBloodElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
  {
   Name = "a diseased blood elemental";
   Body = 159;
   BaseSoundID = 278;

   SetStr( 660, 705 );
   SetDex( 70, 75 );
   SetInt( 300, 375 );

   SetHits( 2570, 2625 );

   SetDamage( 19, 27 );

   SetDamageType( ResistanceType.Physical, 0 );
   SetDamageType( ResistanceType.Poison, 50 );
   SetDamageType( ResistanceType.Energy, 50 );

   SetResistance( ResistanceType.Physical, 65, 75 );
   SetResistance( ResistanceType.Fire, 55, 65 );
   SetResistance( ResistanceType.Cold, 50, 60 );
   SetResistance( ResistanceType.Poison, 60, 70 );
   SetResistance( ResistanceType.Energy, 50, 60 );

   SetSkill( SkillName.EvalInt, 115.0, 130.0 );
   SetSkill( SkillName.Magery, 110.0, 120.0 );
   SetSkill( SkillName.Meditation, 130.0, 155.0 );
   SetSkill( SkillName.MagicResist, 115.0, 125.0 );
   SetSkill( SkillName.Tactics, 130.0, 140.0 );
   SetSkill( SkillName.Wrestling, 120.0, 140.0 );
   SetSkill( SkillName.Poisoning, 100.0 );

   Fame = 8500;
   Karma = -8500;

   VirtualArmor = 60;
  }

  public override void GenerateLoot()
  {
   AddLoot( LootPack.FilthyRich );
   AddLoot( LootPack.Rich );
   //shame crystal
  }

  public override int TreasureMapLevel{ get{ return 5; } }

  public DiseasedBloodElemental ( Serial serial ) : base( serial )
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