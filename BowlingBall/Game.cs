namespace BowlingBall
{
    public class Game
    {
        /// <summary>
        /// Rolls: Size of 21
        /// </summary>
        public int[] rolls = new int[21];

        /// <summary>
        /// CurretRole: intially set to 0
        /// </summary>
        public int currentRole = 0;

        #region[PUBLIC METHODS]
        /// <summary>
        /// This will add pins to rolls.
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            rolls[currentRole] = pins;
            currentRole++;
        }

        /// <summary>
        /// Returns the final score of the game.
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            int score = 0;
            int currentPinIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsSpareInFrame(currentPinIndex)) 
                {
                    //if its spare then next 1 pin will be added into score as a bonus.
                    score += rolls[currentPinIndex] + rolls[currentPinIndex + 1] + rolls[currentPinIndex + 2];
                    currentPinIndex += 2;
                }
                else if (IsStrikeInFrame(currentPinIndex))
                {
                    //if its strike then next 2 pins will be added into score as a bonus.
                    score += rolls[currentPinIndex] + rolls[currentPinIndex + 1] + rolls[currentPinIndex + 2];
                    currentPinIndex++;
                }
                else
                {
                    //current pin + next pin.
                    score += rolls[currentPinIndex] + rolls[currentPinIndex + 1];
                    currentPinIndex += 2;
                }
            }
            return score;
        }
        #endregion[PUBLIC METHODS]

        #region[PRIVATE METHODS]

       /// <summary>
       /// This will check whether it is spare in a frame or not. 
       /// e.g. 7,3 = 10. Hence it is spare.
       /// </summary>
       /// <param name="currentPinIndex"></param>
       /// <returns></returns>
        private bool IsSpareInFrame(int currentPinIndex)
        {
            return rolls[currentPinIndex] + rolls[currentPinIndex + 1] == 10 ? true: false;
        }

        /// <summary>
        /// This will check whether it is strike in a frame or not. 
        /// e.g. 10 in a first go itself. Hence it is strike.
        /// </summary>
        /// <param name="currentPinIndex"></param>
        /// <returns></returns>
        private bool IsStrikeInFrame(int currentPinIndex)
        {
            return rolls[currentPinIndex] == 10 ? true : false;
        }
        #endregion[PRIVATE METHODS]
    }
}
