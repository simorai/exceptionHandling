using exceptionHandling.Entities;
using exceptionHandling.Entities.Exceptions;

namespace exceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Solicita e lê os dados da reserva
                Console.Write("Room Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Check-in date (dd/MM/yyyy): ");
                DateTime checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                DateTime checkOut = DateTime.Parse(Console.ReadLine());

                // Cria uma nova reserva e exibe os detalhes
                Reservation reservation = new Reservation(number, checkIn, checkOut);
                Console.WriteLine("Reservation: " + reservation);
                Console.WriteLine();
                // Solicita e lê os dados para atualização da reserva
                Console.WriteLine("Enter data to update the reservation: ");
                Console.Write("Check-in date (dd/MM/yyyy): ");
                checkIn = DateTime.Parse(Console.ReadLine());
                Console.Write("Check-out date (dd/MM/yyyy): ");
                checkOut = DateTime.Parse(Console.ReadLine());
                // Atualiza a reserva e exibe os novos detalhes
                reservation.UpdateDates(checkIn, checkOut);
                Console.WriteLine("Reservation: " + reservation);
            }
            catch (DomainException e)
            {
                // Captura e exibe erros específicos do domínio
                Console.WriteLine("Error in reservation: " + e.Message);
            }

            catch (FormatException e)
            {
                // Captura e exibe erros de formato na entrada de dados
                Console.WriteLine("Format error: " + e.Message);
            }

            catch (Exception e)
            {
                // Captura e exibe quaisquer outros erros inesperados
                Console.WriteLine("Unexpected error: " + e.Message);
            }
        }
    }
}
