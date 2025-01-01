using exceptionHandling.Entities.Exceptions;

namespace exceptionHandling.Entities
{
    /// <summary>
    /// Representa uma reserva de quarto em um hotel
    /// </summary>
    internal class Reservation
    {
        /// <summary>
        /// Número do quarto reservado
        /// </summary>
        public int RoomNumber { get; set; }
        /// <summary>
        /// Data de check-in da reserva
        /// </summary>
        public DateTime CheckIn { get; set; }
        /// <summary>
        /// Data de check-out da reserva
        /// </summary>
        public DateTime CheckOut { get; set; }

        /// <summary>
        /// Construtor padrão para criação de uma reserva
        /// </summary>
        public Reservation() { }

        /// <summary>
        /// Construtor para criar uma nova reserva com validação de datas
        /// </summary>
        /// <param name="roomNumber">Número do quarto</param>
        /// <param name="checkIn">Data de check-in</param>
        /// <param name="checkOut">Data de check-out</param>
        /// <exception cref="DomainException">Lançada quando as datas são inválidas</exception>
        public Reservation(int roomNumber, DateTime checkIn, DateTime checkOut)
        {
            // Verifica se a data de check-out é posterior à de check-in
            if (checkOut <= CheckIn)
            {
                throw new DomainException("check-out date must be after check-in date");
            }
            RoomNumber = roomNumber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        /// <summary>
        /// Calcula a duração da estadia em dias
        /// </summary>
        /// <returns>Número total de dias da reserva</returns>
        public int Duration()
        {
            TimeSpan duration = CheckOut.Subtract(CheckIn);
            return (int)duration.TotalDays;
        }

        /// <summary>
        /// Atualiza as datas da reserva com validações
        /// </summary>
        /// <param name="checkIn">Nova data de check-in</param>
        /// <param name="checkOut">Nova data de check-out</param>
        /// <exception cref="DomainException">Lançada quando as novas datas são inválidas</exception>
        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {
            DateTime now = DateTime.Now;
            // Verifica se as novas datas são futuras
            if (checkIn < now || checkOut < now)
            {
                throw new DomainException("Reservation dates for update must be future dates");
            }
            // Verifica se a nova data de check-out é posterior à de check-in
            if (checkOut <= CheckIn)
            {
                throw new DomainException("check-out date must be after check-in date");
            }
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        /// <summary>
        /// Retorna uma representação em string da reserva
        /// </summary>
        /// <returns>Detalhes da reserva formatados</returns>
        public override string ToString()
        {
            return "Room "
            + RoomNumber
            + ", check-in: "
            + CheckIn.ToString("dd/MM/yyyy")
            + ", check-out: "
            + CheckOut.ToString("dd/MM/yyyy")
            + ", "
            + Duration()
            + " nights";
        }
    }
}
