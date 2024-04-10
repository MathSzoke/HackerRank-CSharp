/*
 * Write a class called User that is used to calculate the amount that a user will progress through a ranking system similar to the one Codewars uses.
 *
 * Business Rules:
 * A user starts at rank -8 and can progress all the way to 8.
 * There is no 0 (zero) rank. The next rank after -1 is 1.
 * Users will complete activities. These activities also have ranks.
 * Each time the user completes a ranked activity the users rank progress is updated based off of the activity's rank
 * The progress earned from the completed activity is relative to what the user's current rank is compared to the rank of the activity
 * A user's rank progress starts off at zero, each time the progress reaches 100 the user's rank is upgraded to the next level
 * Any remaining progress earned while in the previous rank will be applied towards the next rank's progress (we don't throw any progress away). The exception is if there is no other rank left to progress towards (Once you reach rank 8 there is no more progression).
 * A user cannot progress beyond rank 8.
 * 
 * The only acceptable range of rank values is -8,-7,-6,-5,-4,-3,-2,-1,1,2,3,4,5,6,7,8. Any other value should raise an error.
 * 
 * The progress is scored like so: 
 * Completing an activity that is ranked the same as that of the user's will be worth 3 points
 * Completing an activity that is ranked one ranking lower than the user's will be worth 1 point
 * Any activities completed that are ranking 2 levels or more lower than the user's ranking will be ignored
 * Completing an activity ranked higher than the current user's rank will accelerate the rank progression. The greater the difference between rankings the more the progression will be increased.
 * The formula is 10 * d * d where d equals the difference in ranking between the activity and the user.
 * 
 * Logic Examples:
 * If a user ranked -8 completes an activity ranked -7 they will receive 10 progress
 * If a user ranked -8 completes an activity ranked -6 they will receive 40 progress
 * If a user ranked -8 completes an activity ranked -5 they will receive 90 progress
 * If a user ranked -8 completes an activity ranked -4 they will receive 160 progress, resulting in the user being upgraded to rank -7 and having earned 60 progress towards their next rank
 * If a user ranked -1 completes an activity ranked 1 they will receive 10 progress (remember, zero rank is ignored)
 * 
 * Code Usage Examples:
 * User user = new User();
 * user.rank; // => -8
 * user.progress; // => 0
 * user.incProgress(-7);
 * user.progress; // => 10
 * user.incProgress(-5); // will add 90 progress
 * user.progress; // => 0 // progress is now zero
 * user.rank; // => -7 // rank was upgraded to -7
 * Note: In C# some methods may throw an ArgumentException.
 * 
 * Note: Codewars no longer uses this algorithm for its own ranking system. It uses a pure Math based solution that gives consistent results no matter what order a set of ranked activities are completed at.
 */

namespace TestConsole;

public class User
{
    public static void Main(string[] args)
    {
        User u = new();
        u.incProgress(1);
    }

    public int rank = -8;
    public int progress = 0;
    readonly int[] ranks = { -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8 }; // Array de niveis de rank disponivel no sistema.

    public void incProgress(int actRank)
    {
        int up = 0;
        this.progress += this.CalcProgress(actRank);

        /*
         * Enquanto o progresso for maior que 100, irá evoluir o nivel do rank do usuário para + 1.
         * Se o rank for 0, atualiza para 1, pois o rank 0 não existe neste sistema de progesso.
         * Se o rank do usuário for o ultimo rank disponivel no momento, atualiza o progresso para 0.
         */
        if (this.progress >= 100)
        {
            while (this.progress >= 100)
            {
                this.progress -= 100;
                up += 1;
            }
        }

        // Se houver upgrade disponivel, atualiza o rank do usuário.
        if (up is not 0)
        {
            if (this.rank + up >= this.ranks.Last()) // Se o upgrade for maior que o ultimo rank disponivel.
            {
                this.rank = this.ranks.Last(); // Seta o valor de rank do usuário para o ultimo rank disponivel
                this.progress = 0; // Seta o progresso para 0 pois o usuário pertence ao ultimo nivel disponivel.
            }
            else
            {
                if (this.rank < 0 && this.rank + up >= 0) // Se o rank do usuário for menor que 0 e o rank calculado com upgrade é maior que 0
                {
                    up += 1;
                }
                this.rank += up;
            }
        }
        // Se houver upgrade disponivel, atualiza o rank do usuário para o ultimo nivel disponivel.
        else
        {
            if (this.rank >= this.ranks.Last()) // Se o rank do usuário for maior que o ultimo disponivel.
            {
                this.rank = this.ranks.Last(); // Seta o valor de rank do usuário para o ultimo rank disponivel
                this.progress = 0; // Seta o progresso para 0 pois o usuário pertence ao ultimo nivel disponivel.
            }
        }
    }

    /// <summary>
    /// Este método calcula o progresso de upgrade do rank do usuário.
    /// </summary>
    /// <param name="r">Rank da atividade exercida pelo usuário.</param>
    /// <returns>Pontos de progresso do usuário.</returns>
    /// <exception cref="ArgumentException">Invalid rank or progress</exception>
    public int CalcProgress(int r)
    {
        int d = Math.Abs(this.rank - r);

        // Se o rank do usuário e o rank da atividade não existe no contexto de ranks disponiveis no sistema, retorna erro.
        if (!this.ranks.Contains(r) || !this.ranks.Contains(this.rank)) throw new ArgumentException("Invalid rank or progress");

        // Se o rank da atividade for o mesmo do usuário, recebe 3 pontos de progresso.
        if (r.Equals(this.rank)) return 3;

        // Se o rank da atividade for menor que 0
        if (r < 0)
        {
            // Se o rank do usuário for menor que 0
            if (this.rank < 0)
            {
                if (d is 1 && this.rank > r) return 1;

                if (d >= 2 && this.rank > r) return 0;
                // Se não, o usuário recebe o valor calculado de 10 vezes a sobra da divisão de d por 2
                else return 10 * (int)Math.Pow(d, 2); // Método que calcula a potência de "d" elevado a 2
            }
            // Se o rank do usuário não for menor que 0
            else
            {
                // Se a diferença de rank do usuário e da atividade - 1 for o número 1 e o rank do usuário for maior que o rank da atividade, recebe 1 ponto de progresso.
                if ((d - 1) is 1 && this.rank > r) return 1;

                // Se a diferença de rank do usuário e da atividade - 1 for igual ou maior que o número 2 e o rank do usuário for maior que o rank da atividade, recebe 0 ponto de progresso.
                if ((d - 1) >= 2 && this.rank > r) return 0;
            }
        }
        // Se o rank da atividade não for menor que 0
        else
        {
            // Se o rank do usuário for menor que 0
            if (this.rank < 0)
            {
                // Se a diferença de rank do usuário - o da atividade + 1 for igual a 1 número e o rank do usuário for maior que o rank da atividade, recebe 1 ponto de progresso.
                if (Math.Abs(this.rank - r + 1) is 1 && this.rank > r) return 1;

                // Se a diferença de rank do usuário - o da atividade + 1 for igual ou maior que o número 2 e o rank do usuário for maior que o rank da atividade, recebe 0 ponto de progresso.
                if (Math.Abs(this.rank - r + 1) >= 2 && this.rank > r) return 0;
                else return 10 * (int)Math.Pow(Math.Abs(this.rank - r + 1), 2);
            }
            // Se o rank do usuário não for menor que 0
            else
            {
                // Se a diferença de números entre o rank da atividade e do usuário for de 1 número e o rank do usuário for maior que o da atividade, recebe 1 ponto de progresso
                if (d is 1 && this.rank > r) return 1;

                // Se a diferença de números entre o rank da atividade e do usuário for de 2 número e o rank do usuário for maior que o da atividade, recebe 0 ponto de progresso
                if (d >= 2 && this.rank > r) return 0;
                // Se não, o usuário recebe o valor calculado de 10 vezes a sobra da divisão de d por 2
                else return 10 * (int)Math.Pow(d, 2); // Método que calcula a potência de "d" elevado a 2
            }
        }

        // Em qualquer caso que não se encaixe nas condições acima, retorne erro.
        throw new ArgumentException("Invalid rank or progress");
    }
}