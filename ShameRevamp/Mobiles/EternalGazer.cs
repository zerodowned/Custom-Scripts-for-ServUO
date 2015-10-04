using System;
using Server;
using Server.Items;

/*to do
	Receives half damage from summons and pets. 
*/

namespace Server.Mobiles
{
	[CorpseName( "an eternal gazer corpse" )]
	public class EternalGazer : BaseCreature
	{
		[Constructable]
		public EternalGazer () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.3, 0.6 )
		{
			Name = "an eternal gazer";
			Body = 22;
			BaseSoundID = 377;

			SetStr( 500, 515 );
			SetDex( 130, 140 );
			SetInt( 405, 460 );

			SetHits( 7421, 7483 );

			SetDamage( 18, 21 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Energy, 50 );

			SetResistance( ResistanceType.Physical, 65, 75 );
			SetResistance( ResistanceType.Fire, 60, 70 );
			SetResistance( ResistanceType.Cold, 70, 75 );
			SetResistance( ResistanceType.Poison, 65, 75 );
			SetResistance( ResistanceType.Energy, 65, 75 );

			SetSkill( SkillName.EvalInt, 120.0, 130.0 );
			SetSkill( SkillName.Magery, 120.0, 130.0 );
			SetSkill( SkillName.MagicResist, 125.0, 140.0 );
			SetSkill( SkillName.Tactics, 115.0, 127.0 );
			SetSkill( SkillName.Wrestling, 110.0, 126.0 );
			SetSkill( SkillName.Anatomy, 75.0, 90.0 );

			Fame = 12500;
			Karma = -12500;

			VirtualArmor = 36;

			PackItem( new Nightshade( 4 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
		}

		public override int TreasureMapLevel{ get{ return 1; } }
		public override int Meat{ get{ return 1; } }

		public EternalGazer ( Serial serial ) : base( serial )
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