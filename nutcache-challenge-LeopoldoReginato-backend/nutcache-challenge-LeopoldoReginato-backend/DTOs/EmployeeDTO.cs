namespace nutcache_challenge_LeopoldoReginato_backend.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public int IdGender { get; set; }
        public string? genderName { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string StartDate { get; set; }
        public int? IdTeam { get; set; }
        public string? teamName { get; set; }
    }
}
