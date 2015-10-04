# My-Stuff
Various scripts for use with RunUo/ServUo/PlayUo

*AIO Vendor Stone*<br> 
  Needs a little work. It's one of my older works. 
  It's a stone that can be used to summon almost any Vendor from it. 
  Once the summoner walks away, the vendor self deletes.
  
*Crystal Portals
  Already included in the repos for Serv and Justuo ( I believe ) with edits to improve functionality
  
*Item Of Light
  A light source that's truely equipable and moves with you naturally.
  
*LivingStatue
  I edited the BaseDesItem script by Vorspire so the mobile attached to the item can move (but cannot be seen) and making it appear as though the item is walking.
  The Mobile corpse almost instantly self-deletes OnDeath and can drop loot on the ground.
  One downfall to this is that the static item won't turn to face the direct it's moving, so the fake animation can seem...pretty sloppy.
  
  You'll also notice that mobile bleeds, I have a commented out line to show how I handled it to prevent the mobile from bleeding.

//public override bool DoesNotBleed{ get{ return true;}} under IDamageableItem2 - the mobile

then in BaseWeapon find the AddBlood method and edit like below
public virtual void AddBlood(Mobile attacker, Mobile defender, int damage)
     {
       if (defender is BaseCreature) {
         if( ((BaseCreature)defender).DoesNotBleed ) {
           return;
         }
       }


*MobileStatues 
  An idea presented to my by Talow...
  This is kind of a twist to the LivingStatue code, the Mobile IS the statue, with "frozen" animation.
  It stands on a pedastal until you get too close to it, then it comes alive and starts to attack you until you kill it.
  Once animated, if there are no players within a certain range, it will go back to it's pedastal and "freeze" again.
  
*Monster In A Box - UNDER Development
  * * Currently under development * *
  This code, when completed, is intended to allow you to script custom mobiles in game ( within limitations )
  Allowing you to create custom Mobs for events without writing a full script and restarting.
  * Eventually intended to have a system to save and spawn mobiles via XML as well.
  * Also intended to eventually expand on to create items, weapons, armor, etc.
  
*Pause
  This allows players to "Pause" making them frozen, hidden, and invulnerable. 
  It also puts them in Peace Mode and auto stables pets to prevent afk hunting.
  Cannot be used near Champion areas, or while involved in a PVP match.
  * System has an option to allow Staff to change the settings of certain to stop them from using it if they are abusing it via the [getxmlatt and target the player and select the Pause attachment and then change the propert "CanPause"
  - Intended to allow players to go afk randomly when Real Life calls. 

*Shame Revamp - needs tweaking plus mobile abilities
  Various mobiles and items to be used for the Shame Dungeon revamp. 
  Probably needs some tweaking.
  
*Spellbar - needs edits to distro scripts
  A gump based hotbar to add spells and allows players to cast them via the hotbar with a single click.
  Player's must have the corresponding book with spell in their pack to cast them.
  - The hotbar can be locked to prevent movement/closing.
  - Can be minimized when you need more screen room
  - Can be flipped horizontally or vertically
  - Additional edits are needed to fully work with Ninjitsu/Bushido spells ( will post later )
  
*Carousel - incomplete but functional 
  Exactly what it sounds like. Needs some editing to add tiles around it OnCreate. *ToDoList

*Elevator
  Platform that raises and lowers on a timer. Players and step on it and it will carry them up with it.
  
*FreezeTile - incomplete
  Intended to be used with XML Waypoints ( with edits ) to make mobiles pause at a certain spot before carrying on down the waypoint path.
  
*Guardian Knight - needs works
  A Knight that certain parts of armor "fall Off" depending on how much damage has been taken.
  
*Moving Trap 
  A block that moves back and forth and will damage you if you're in it's path ( like those spiked blocks from Zelda )

*SBSellAll
  Intended to be used to allow Players to sell anything to any NPC Vendor
  Takes some of the tediousness out of selling loot.
  
*Smart Item - probably needs a little work
  Items with OnThink and OnCreate similar to Mobiles.
  Inherit from this to prevent needing to create timers all the time.
  
*Speaking Sign - a little tweaking to come
  Sign that speaks it's name when a player is nearby. 
  - To add use [add Speakingsign "This is the signs name in quotes"
  - Future work intended to prevent the sign from showing up in player's joural as " SpeakingSign says SpeakingSign "
  
*WayStone_DungeonVersion
  A spinoff from Talow's WayStone. 
  This is a Stone ( as often used for Stone Vendors, etc ) that sits on the ground instead of being in their pack.
  When doubleclicked, if the player is in a party, it sends a summons request to each member of the party.
  If the member accepts, they are teleported to the Summoner's position.
  If they decline, a message is sent to the summoner. 
  
  
