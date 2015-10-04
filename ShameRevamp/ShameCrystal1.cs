using System;
using Server;

namespace Server.Items
{
	public class ShameCrystal : Item
	{
		[Constructable]
        public ShameCrystal() : this( 1 ) {}
		
		[Constructable]
        public ShameCrystal(int amount) : this( amount, 0x0F89 ) {}
		
		[Constructable]
		public ShameCrystal( int amount, int itemID ) : base( 0x0F89 )
		{
			Name = "Crystal fragments of Shame";
			Weight = 1;
			Hue = 1278;
			Stackable = true;
			ItemID = itemID;
			Amount = amount;
		}

		public ShameCrystal( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			
			int version = reader.ReadInt();
		}
	}
}

