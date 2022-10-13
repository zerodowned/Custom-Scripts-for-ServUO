using Server.Engines.Craft;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Items
{   
    [Flipable(0x1297, 0x1298, 0x1299, 0x129a, 0x129b, 0x129c, 0x129d, 0x129e)]
    public class StealableSign : BaseStealableSign
    {
        [Constructable]
        public StealableSign() : base(Utility.RandomList(0x1297, 0x1298, 0x1299, 0x129a, 0x129b, 0x129c, 0x129d, 0x129e))
        {
            Name = "to MuMu's Soul";
            Hue = 0;
            Weight = 0;
        }

        public StealableSign(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}