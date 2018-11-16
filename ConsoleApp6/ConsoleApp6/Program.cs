using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        /* Суть игры следующая: вы — боец, вышедший на ринг. За один ход игрок может совершить одно действие: 
 удар левой рукой, правой, ногой или поставить блок. После этого ход переходит противнику.

 Далее генерируется случайное число от 2 до 12. Если выпадает меньше 5 — удар не достигает цели, 
 5−8 — только рукой, 9−11 — засчитывается любой, 12 — критическое попадание. Удар левой рукой оценивается в 
 1 пункт, правой — 2, ногой 3, критическое попадание прибавляет единицу. Блок нивелирует любые попадания, 
 кроме критического, но по номинальной «цене».
 Научитесь записывать и считывать данные из файла — станет еще интереснее.*/

        public enum Action
        {
            LeftJab, RightJab, Kick, Block
        }

        public enum AccuracyValue
        {
            Miss, Jab, Any, Crit
        }

       public  enum DamageValue
        {
            LeftJab, RightJab, Kick, Crit, Blocked
        }

        public static Action PlayerAction(string input)
        {
            switch (input)
            {
                case ("1"):
                {
                        return Action.LeftJab;
                }
                case ("2"):
                {
                        return Action.RightJab;
                }
                case ("3"):
                {
                        return Action.Kick;
                }
                case ("4"):
                {
                        return Action.Block;
                }
                default:
                {
                    break;
                }
            }

            return Action.Block;
        }

        public static AccuracyValue AccuracyTest(int diceValue)
        {
            if(diceValue < 5)
            {
                return AccuracyValue.Miss;
            }
            else if(diceValue >= 5 && diceValue <= 8)
            {
                return AccuracyValue.Jab;
            }
            else if(diceValue >= 9 && diceValue <= 11)
            {
                return AccuracyValue.Any;
            }
            else if(diceValue == 12)
            {
                return AccuracyValue.Crit;
            }

            return AccuracyValue.Miss;
        }

        public static int DamageTest(Action action, AccuracyValue accValue, bool isBlocked)
        {
            int damage = 0;

            if (accValue == AccuracyValue.Jab && !isBlocked)
            {
                if (action == Action.LeftJab)
                {
                    damage = 1;
                }
                else if (action == Action.RightJab)
                {
                    damage = 2;
                }
            }
            else if (accValue == AccuracyValue.Any && !isBlocked)
            {
                if (action == Action.LeftJab)
                {
                    damage = 1;
                }
                else if (action == Action.RightJab)
                {
                    damage = 2;
                }
                else if (action == Action.Kick)
                {
                    damage = 3;
                }
            }
            else if (accValue == AccuracyValue.Crit)
            {
                if (isBlocked)
                {
                    if (action == Action.LeftJab)
                    {
                        damage = 1;
                    }
                    else if (action == Action.RightJab)
                    {
                        damage = 2;
                    }
                    else if (action == Action.Kick)
                    {
                        damage = 3;
                    }
                }
                else
                {
                    if (action == Action.LeftJab)
                    {
                        damage = 2;
                    }
                    else if (action == Action.RightJab)
                    {
                        damage = 3;
                    }
                    else if (action == Action.Kick)
                    {
                        damage = 4;
                    }
                }
            }

            return damage;
        }

        static void Main(string[] args)
        {
            var action = PlayerAction(Console.ReadLine());

            var rand = new Random();
            var accuracyTest = rand.Next(2, 13);

            Console.WriteLine(DamageTest(action,AccuracyTest(accuracyTest), false));

            action = PlayerAction(Console.ReadLine());
            accuracyTest = rand.Next(2, 13);

            Console.WriteLine(DamageTest(action, AccuracyTest(accuracyTest), false));
            Console.ReadKey();
            
        }
    }
}
