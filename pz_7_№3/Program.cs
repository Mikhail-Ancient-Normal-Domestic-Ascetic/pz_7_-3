using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_7__3
{
    class Program
    {
        enum UserStatus { Amateur, Rookie, VIP }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите дату (в формате дд.мм.гггг):");
            DateTime date = DateTime.Parse(Console.ReadLine());

            TimeSpan week = TimeSpan.FromDays(7);
            DateTime nextWeek = date + week;

            var isWomenDay = (nextWeek.Month == 3 & nextWeek.Day == 8);
            var isChildrenDay = (nextWeek.Month == 4 & nextWeek.Day == 4);
            var isVictoryDay = (nextWeek.Month == 5 & nextWeek.Day == 9);
            var isSpringHoliday1 = (nextWeek.Month == 3 & nextWeek.Day == 20);
            var isSpringHoliday2 = (nextWeek.Month == 3 & nextWeek.Day == 30);

            UserStatus[] vipUsers = { UserStatus.VIP };
            UserStatus[] rookieUsers = { UserStatus.Rookie, UserStatus.VIP };
            UserStatus[] amateurUsers = { UserStatus.Amateur, UserStatus.Rookie, UserStatus.VIP };

            if (isWomenDay || isChildrenDay || isVictoryDay)// оповещение для VIP-пользователей
            {
                Console.WriteLine("Следующая неделя включает один из праздников: Международный женский день (8 марта) или День программиста (4 апреля) или День Победы (9 мая).");
                NotifyUsers(vipUsers);
            }
            else if (isSpringHoliday1 || isSpringHoliday2)// оповещение для Rookie-пользователей
            {
                Console.WriteLine("Следующая неделя включает весенние праздники.");
                NotifyUsers(rookieUsers);
            }
            else if (nextWeek.Month == 3 || nextWeek.Month == 4 || nextWeek.Month == 5)// оповещение для Amateur-пользователей
            {
                Console.WriteLine("Приобретите VIP-статус для получения оповещений о праздниках.");
                NotifyUsers(amateurUsers);
            }
            else
            {
                Console.WriteLine("Это не весна.");
            }
            Console.ReadLine();
        }

        static void NotifyUsers(UserStatus[] users)
        {
            foreach (UserStatus user in users)
            {
                Console.WriteLine($"Пользователь со статусом {user} получил оповещение.");
            }
        }
    }
}