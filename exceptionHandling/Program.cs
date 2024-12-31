using exceptionHandling.Entities;

namespace exceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Room Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Check-in date (dd/MM/yyyy): ");
            DateTime checkIn = DateTime.Parse(Console.ReadLine());
            Console.Write("Check-out date (dd/MM/yyyy): ");
            DateTime checkOut = DateTime.Parse(Console.ReadLine());

            Reservation reservation = new Reservation(number, checkIn, checkOut);
        }
    }
}
