using System.Text.RegularExpressions;
using System.Globalization;

namespace Progetto_BE_S1_L5.Models
{
    public class Contribuente
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string DataNascita { get; set; }
        public string CodiceFiscale { get; set; }

        public string Sesso { get; set; }
        public string ComuneResidenza { get; set; }
        public decimal RedditoAnnuale { get; set; }

        private decimal TotaleDovuto { get; set; }



        public Contribuente(string nome, string cognome, string data, string cF, string sesso, string comuneRes, decimal ral)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = data;
            CodiceFiscale = cF;
            Sesso = sesso;
            ComuneResidenza = comuneRes;
            RedditoAnnuale = ral;
        }




        public void CalcoloImposta()
        {
            int aliquota;
            decimal imposta = 0;
            if (RedditoAnnuale > 0 && RedditoAnnuale <= 15000)
            {
                aliquota = 23;

            }
            else if (RedditoAnnuale <= 28000)
            {
                aliquota = 27;
                imposta = 3450;

            }
            else if (RedditoAnnuale <= 55000)
            {
                aliquota = 38;
                imposta = 6960;

            }
            else if (RedditoAnnuale <= 75000)
            {
                aliquota = 41;
                imposta = 17220;


            }
            else
            {
                aliquota = 43;
                imposta = 25420;

            }

            switch (aliquota)
            {

                case 23:
                    TotaleDovuto = imposta + ((RedditoAnnuale / 100) * 23);
                    break;
                case 27:
                    TotaleDovuto = imposta + (((RedditoAnnuale - 15000) / 100) * 23);
                    break;
                case 38:
                    TotaleDovuto = imposta + (((RedditoAnnuale - 28000) / 100) * 23);
                    break;
                case 41:
                    TotaleDovuto = imposta + (((RedditoAnnuale - 55000) / 100) * 23);
                    break;
                case 43:
                    TotaleDovuto = imposta + (((RedditoAnnuale - 75000) / 100) * 23);
                    break;

                default:
                    break;
            }
            Console.WriteLine($"==================================================");
            Console.WriteLine();
            Console.WriteLine($"CALCOLO DELL'IMPOSTA DA VERSARE:");
            Console.WriteLine();
            Console.WriteLine($"Contribuente: {Nome} {Cognome}");
            Console.WriteLine();
            Console.WriteLine($"nato il: {DataNascita} ({Sesso})");
            Console.WriteLine();
            Console.WriteLine($"residente in: {ComuneResidenza}");
            Console.WriteLine();
            Console.WriteLine($"codice fiscale: {CodiceFiscale}");
            Console.WriteLine();
            Console.WriteLine($"Reddito dichiarato: ${RedditoAnnuale}");
            Console.WriteLine();
            Console.WriteLine($"IMPOSTA DA VERSARE: ${TotaleDovuto :N2}");





        }

        public static bool CheckNome(string nome)
        {
            string regex = @"([A-ZÀ-ÿ][a-zà-ÿ'’\-]*|\s[A-ZÀ-ÿ][a-zà-ÿ'’\-]*)*$|^[A-ZÀ-ÿ]+(\s[A-ZÀ-ÿ]+)*$";
            Regex regexNomi = new Regex(regex);
            if (regexNomi.IsMatch(nome))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Inserisci un nome valido");
                Console.WriteLine();
                return false;
            }
        }
        public static bool CheckCognome(string cognome)
        {
            string regex = @"([A-ZÀ-ÿ][a-zà-ÿ'’\-]*|\s[A-ZÀ-ÿ][a-zà-ÿ'’\-]*)*$|^[A-ZÀ-ÿ]+(\s[A-ZÀ-ÿ]+)*$"; ;
            Regex regexCognomi = new Regex(regex);
            if (regexCognomi.IsMatch(cognome))
            {  
                return true;
            }
            else
            {
                Console.WriteLine("Inserisci un Cognome valido");
                Console.WriteLine();
                return false;
            }
        }
        public static bool CheckData(string data)
        {
            string[] formats = { "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "dd/MM/yyyy" };
            bool result = DateTime.TryParseExact(data, formats, null, DateTimeStyles.None, out DateTime dataNascita);
            DateTime today = DateTime.Today;
            //Console.WriteLine(today);
            if (result && today>=dataNascita)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Inserisci un data di nascita valida");
                Console.WriteLine();
                return false;
            }
        }
        public static string CheckGender(string gender)
        {
            switch (gender)
            {
                case "M":
                    return gender.Trim();

                case "F":
                    return gender.Trim();

                default:
                    return "N/D";
            }
        }
        public static bool CheckComune(string comune) 
        {
            string regex = @"^[A-Za-zÀ-ÿ][a-zà-ÿ'’\-]*([ ]?[A-Za-zÀ-ÿ][a-zà-ÿ'’\-]*)*$";
            Regex regexCitta = new Regex(regex);
            if (regexCitta.IsMatch(comune))
            {
                
                return true;
            }
            else
            {
                Console.WriteLine("Inserisci un comune di residenza valido");
                Console.WriteLine();
                return false;
            }
        }
        public static bool CheckCF(string cf)
        {
            string regex = @"^[A-Z]{6}\d{2}[A-EHLMPRST]{1}\d{2}[A-Z]{1}\d{3}[A-Z]{1}$";
            Regex regexCF = new Regex(regex);
            if (regexCF.IsMatch(cf))
            { 
                return true; 
            }
            else
            {
                Console.WriteLine("Devi inserire un codice Fiscale Valido");
                Console.WriteLine();
                return false;
            }

        }
        public static bool CheckRal(string ral)
        {
            bool res = decimal.TryParse(ral,out decimal result);
            if (res) 
            {
                return true;
            }
            else
            {
                Console.WriteLine("Devi inserire un Reddito Valido per continuare");
                Console.WriteLine();
                return false;
            }
        }

    }
}
