using ConsoleAdventureGame.model.creatures;
using ConsoleAdventureGame.model.items.weapon;

namespace ConsoleAdventureGame.model.items
{
    /**
     * Author: Levi Schanding
     * <summary>
     *    The InfWieldable interface describes everything an object would need in order for it to be wielded.
     * </summary>
     */
    public interface InfWieldable{
        DamageType DamageType();

        DamageRoll DamageRoll();

        void Wield(AbstractCreature creature);

    }
}