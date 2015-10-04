using System;
using Server.Items;

namespace Server.Items
{
    public class ShieldOfLight : BaseShield_ItemOfLight
    {
        [Constructable]
        public ShieldOfLight() : base()
        {
			ItemID = 0x1B78;
			Layer = Layer.TwoHanded;
            Weight = 1.0;
		}
		
		public override int InitMinHits
        { get {  return 255; } }
		
        public override int InitMaxHits
        { get {  return 255; } }
		
        public ShieldOfLight(Serial serial) : base(serial)
        { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
		}
    }
}