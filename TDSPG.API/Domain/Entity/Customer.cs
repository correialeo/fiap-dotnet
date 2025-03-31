namespace TDSPG.API.Domain.Entity
{
    internal class Customer : Audit, IEntity
    {
        public Guid CustomerId { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public Customer(string name, string document, string email)
        {
            Name = name;
            Document = VerifyDocument(document);
            Email = email;
            UserCreated = "asda";
        }
        private string VerifyDocument(string document)
        {
            if (document.Length < 10) throw new Exception("Documento deverá ter mais do que 10 caracteres");
            return document;
        }
        public override string GetInfo()
        {
            return $"Cliente criado por {UserCreated} - {CreatedAt}";
        }

        public string GetInfo2()
        {
            return $"Cliente criado por {UserCreated} - {CreatedAt}";
        }
    }
}
