using System;
using Server;
using Server.Mobiles;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Server.Items
{
	public class LivingStatue : DamageableItem2
	{
		[Constructable]
		public LivingStatue( )
			: base( 4825, 4825 )
		{
			Name = "Living Statue";

			Level = ItemLevel.Easy;
            Movable = false;
		}
		
		
	/*	
		//http://www.runuo.com/community/threads/items-drop-oin-death.78203/
		//public override void OnDeath( )
		public bool Destroy( )
		{
			//base.OnDeath( c );
			
				Item MegatonRock = new MegatonRock();
				MegatonRock.MoveToWorld( new Point3D( this.X + Utility.RandomMinMax( -1, 1 ), this.Y + Utility.RandomMinMax( -1, 1 ), this.Z ), this.Map );
			return true;
		}
	*/
		public LivingStatue( Serial serial )
			: base( serial )
		{
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( ( int )0 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt( );
		}
	}
}