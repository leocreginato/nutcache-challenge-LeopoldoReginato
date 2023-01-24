namespace nutcache_challenge_LeopoldoReginato_backend.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int IdGender { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public DateTime StartDate { get; set; }
        public int? IdTeam { get; set; }

        public virtual Gender? IdGenderNavigation { get; set; }
        public virtual Team? IdTeamNavigation { get; set; }
    }
}
