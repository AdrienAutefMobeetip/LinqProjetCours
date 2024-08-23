namespace LinqProject.Models
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty; 
        public string Prenom { get; set; } = string.Empty; 
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty; 
    }
}
