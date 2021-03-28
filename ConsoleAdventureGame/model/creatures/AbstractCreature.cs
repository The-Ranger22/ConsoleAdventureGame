using AdventureGame.model.rooms;

namespace AdventureGame.model.creatures
{
    public abstract class AbstractCreature
    {
        //a comment
        protected int health { get; set; }
        private int action_points { get; set; }
        private int level { get; set; }
        private int experience { get; set; }
        private AbstractRoom location { get; set; }
        public CreatureState state { get; } = CreatureState.IDLE;

        protected class stats
        {
            
        }
    }
}