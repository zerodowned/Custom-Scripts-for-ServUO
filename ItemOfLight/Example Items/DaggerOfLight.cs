using System;

namespace Server.Items
{
	public class DaggerOfLight : BaseWeapon_ItemOfLight
    {
        [Constructable]
        public DaggerOfLight() : base()
        {
			ItemID = 0xF52;
			Layer = Layer.FirstValid;
			Weight = 1.0;
        }

        public DaggerOfLight(Serial serial) : base(serial)
        {
        }

		public override int InitMinHits
        { get { return 31; } }
		
        public override int InitMaxHits
        { get { return 40; } }
       
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}