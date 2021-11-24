namespace AdvancedDelEveLamLINQ
{
    public class ChessPlayer
    {
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public int Rating { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Full Name: {FirstName + " " + LastName}, Rating = {Rating}, from {Country}, born in {BirthYear}";
        }

        public static ChessPlayer ParseFileCsv(string line)
        {
            string[] parts = line.Split(';');
            return new ChessPlayer()
            {
                Id = int.Parse(parts[0]),
                FirstName = parts[1].Trim(),
                LastName = parts[2].Trim(),
                Country = parts[4],
                Rating = int.Parse(parts[5]),
                BirthYear = int.Parse(parts[7])
            };
        }

    }
}
