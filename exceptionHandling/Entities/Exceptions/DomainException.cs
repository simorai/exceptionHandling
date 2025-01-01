namespace exceptionHandling.Entities.Exceptions
{
    /// <summary>
    /// Representa uma exceção de domínio personalizada.
    /// Esta classe herda de ApplicationException.
    /// </summary>
    internal class DomainException : ApplicationException
    {
        /// <summary>
        /// Inicializa uma nova instância da classe DomainException.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        public DomainException(string message) : base(message) { }
    }
}
