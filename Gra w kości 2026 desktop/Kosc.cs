namespace Gra_w_kości_2026_desktop
{
    public class Kosc
    {
        // Licznik wszystkich utworzonych kości
        public static int LiczbaKosci = 0;
        private static readonly Random Losowanie = new();

        public string[] ZdjecieKosci = ["kosc0.png", "kosc1.png", "kosc2.png", "kosc3.png", "kosc4.png", "kosc5.png", "kosc6.png"];
        public int LiczbaOczek;
        public int ZdjecieId;
        public bool CzyDostepna;

        public Kosc()
        {
            int randomNum = Losowanie.Next(1, 7);

            LiczbaOczek = randomNum;
            ZdjecieId = randomNum;
            CzyDostepna = true;
            LiczbaKosci++;
        }

        public Kosc(int wartoscWyrzucona)
        {
            if (wartoscWyrzucona < 1 || wartoscWyrzucona > 6)
                wartoscWyrzucona = 0;

            LiczbaOczek = wartoscWyrzucona;
            ZdjecieId = wartoscWyrzucona;
            CzyDostepna = true;
            LiczbaKosci++;
        }

        public void RzucKostka()
        {
            // Zablokowana kość nie bierze udziału w rzucie
            if (!CzyDostepna)
                return;

            int randomNum = Losowanie.Next(1, 7);
            LiczbaOczek = randomNum;
            ZdjecieId = randomNum;
        }

        public void ZablokujKosc()
        {
            CzyDostepna = false;
        }

        public string LiczbaOczekToString()
        {
            // Zamiana liczby oczek na zapis słowny
            return LiczbaOczek switch
            {
                1 => "jeden",
                2 => "dwa",
                3 => "trzy",
                4 => "cztery",
                5 => "pięć",
                6 => "sześć",
                _ => ""
            };
        }
    }
}