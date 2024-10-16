namespace ArelAkademi.Models
{
    public static class Repository
    {
        //Gelen kurs başvurularının In Memory olarak tutalacağı Generic Liste
        private static List<Candidate> applications = new();

        //Kayıt ekleyen metot
        public static void Add(Candidate candidate)
        {
            applications.Add(candidate);
        }

        //Tüm kayıtları veren metot
        public static IEnumerable<Candidate> GetAllApplications => applications;

    }
}