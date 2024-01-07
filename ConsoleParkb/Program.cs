using Microsoft.Identity.Client;
using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer;
using ParkDataLayer.Migrations;
using ParkDataLayer.Repositories;
using System.ComponentModel.DataAnnotations;

namespace ConsoleParkb
{
    internal class Program
    {
        public static DatabaseContext ctx = new DatabaseContext();
        public static IContractenRepository contractenRepo = new ContractenRepositoryEF(ctx);
        public static BeheerContracten beheerContracten = new BeheerContracten(contractenRepo);

        public static IHuurderRepository huurderRepo = new HuurderRepositoryEF(ctx);
        public static BeheerHuurders beheerHuurders = new BeheerHuurders(huurderRepo);

        public static IHuizenRepository huizenRepo = new HuizenRepositoryEF(ctx);
        public static BeheerHuizen beheerHuizen = new BeheerHuizen(huizenRepo);
        static void Main(string[] args)
        {


            while (true)
            {
                KeuzeMenu();

                int keuze = Convert.ToInt32(Console.ReadLine());

                switch (keuze)
                {
                    case 1:
                        VoegNieuweHuurderToe();
                        break;
                    case 2:
                        UpdateHuurder();
                        break;
                    case 3:
                        GeefHuurder();
                        break;
                    case 4:
                        GeefHuurders();
                        break;
                    case 5:
                        VoegNieuwHuisToe();
                        break;
                    case 6:
                        UpdateHuis();
                        break;
                    case 7:
                        ArchiveerHuis();
                        break;
                    case 8:
                        GeefHuis();
                        break;
                    case 9:
                        MaakContractAan();
                        break;
                    case 10:
                        AnnuleerContract();
                        break;
                    case 11:
                        UpdateContract();
                        break;
                    case 12:
                        GeefContract();
                        break;
                    case 13:
                        GeefContracten();
                        break;
                    case 14:
                        return;
                    default: break;

                }
            }
        }



        private static void VoegNieuweHuurderToe()
        {
            Console.WriteLine("Geef een naam : ");
            string naam = Console.ReadLine();
            Console.WriteLine("Geef een email : ");
            string email = Console.ReadLine();
            Console.WriteLine("Geef een tel : ");
            string tel = Console.ReadLine();
            Console.WriteLine("Geef een adres : ");
            string adres = Console.ReadLine();

            beheerHuurders.VoegNieuweHuurderToe(naam, new Contactgegevens(email, tel, adres));
            Console.WriteLine("Huurder is toegevoegd");
        }
        private static void UpdateHuurder()
        {
            Console.WriteLine("Geef het id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een naam : ");
            string naam = Console.ReadLine();
            Console.WriteLine("Geef een email : ");
            string email = Console.ReadLine();
            Console.WriteLine("Geef een tel : ");
            string tel = Console.ReadLine();
            Console.WriteLine("Geef een adres : ");
            string adres = Console.ReadLine();

            beheerHuurders.UpdateHuurder(new Huurder(id, naam, new Contactgegevens(email, tel, adres)));
        }
        private static void GeefHuurder()
        {
            Console.WriteLine("Geef het Id van de huurder dat je wenst : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Huurder huurder = beheerHuurders.GeefHuurder(id);
            Console.WriteLine(huurder.ToString());
        }
        private static void GeefHuurders()
        {
            Console.WriteLine("geef de naam van de huurders");
            string naam = Console.ReadLine();

            List<Huurder> huurders = beheerHuurders.GeefHuurders(naam);
            huurders.ForEach(h => Console.WriteLine(h.ToString()));
        }
        public static void VoegNieuwHuisToe()
        {
            Console.WriteLine("Geef een straatnaam");
            string straatNaam = Console.ReadLine();
            Console.WriteLine("Geef een nummer");
            int nummer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een parkid");
            string parkId = Console.ReadLine();
            Console.WriteLine("Geef een parkNaam");
            string parkNaam = Console.ReadLine();
            Console.WriteLine("Geef een locatie");
            string locatie = Console.ReadLine();

            Park park = new Park(parkId, parkNaam, locatie);

            beheerHuizen.VoegNieuwHuisToe(straatNaam, nummer, park);

        }
        public static void UpdateHuis()
        {
            Console.WriteLine("Geef het id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een straatnaam");
            string straatNaam = Console.ReadLine();
            Console.WriteLine("Geef een nummer");
            int nummer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een status");
            bool status = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Geef een parkid");
            string parkId = Console.ReadLine();
            Console.WriteLine("Geef een parkNaam");
            string parkNaam = Console.ReadLine();
            Console.WriteLine("Geef een locatie");
            string locatie = Console.ReadLine();

            Park park = new Park(parkId, parkNaam, locatie);

            beheerHuizen.UpdateHuis(new Huis(id, straatNaam, nummer, status, park));
        }
        private static void ArchiveerHuis()
        {
            Console.WriteLine("Geef het id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een straatnaam");
            string straatNaam = Console.ReadLine();
            Console.WriteLine("Geef een nummer");
            int nummer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een status");
            bool status = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Geef een parkid");
            string parkId = Console.ReadLine();
            Console.WriteLine("Geef een parkNaam");
            string parkNaam = Console.ReadLine();
            Console.WriteLine("Geef een locatie");
            string locatie = Console.ReadLine();
            Park park = new Park(parkId, parkNaam, locatie);
            Huis huis = new Huis(id, straatNaam, nummer, status, park);
            beheerHuizen.ArchiveerHuis(huis);
        }
        private static void GeefHuis()
        {
            Console.WriteLine("Geef het id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Huis huis = beheerHuizen.GeefHuis(id);
            Console.WriteLine(huis.ToString());
        }
        public static void MaakContractAan()
        {
            Console.WriteLine("Geef een HuurContractId (string)");
            string huurcontractId = Console.ReadLine();
            Console.WriteLine("Geef een Startdatum (yyyy-MM-dd)");
            DateOnly startDatum = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Geef een aantalDagen");
            int aantalDagen = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een HuisId");
            int huisId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een HuurderId");
            int huurderId = Convert.ToInt32(Console.ReadLine());

            Huis huis = beheerHuizen.GeefHuis(huisId);
            Huurder huurder = beheerHuurders.GeefHuurder(huurderId);

            beheerContracten.MaakContract(huurcontractId,
               new Huurperiode(startDatum.ToDateTime(TimeOnly.MinValue), aantalDagen), huurder, huis); ;
            Console.WriteLine("Contract is aangemakaakt");
        }
        public static void AnnuleerContract()
        {
            Console.WriteLine("Geef een HuurContractId (string)");
            string huurcontractId = Console.ReadLine();
            Console.WriteLine("Geef een Startdatum (yyyy-MM-dd)");
            DateOnly startDatum = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Geef een aantalDagen");
            int aantalDagen = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een HuisId");
            int huisId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een HuurderId");
            int huurderId = Convert.ToInt32(Console.ReadLine());

            Huis huis = beheerHuizen.GeefHuis(huisId);
            Huurder huurder = beheerHuurders.GeefHuurder(huurderId);

            Huurcontract huurcontract = new Huurcontract(huurcontractId,
               new Huurperiode(startDatum.ToDateTime(TimeOnly.MinValue), aantalDagen), huurder, huis); ;
            beheerContracten.AnnuleerContract(huurcontract);
            Console.WriteLine("Contract is verwijderd");
        }
        public static void UpdateContract()
        {
            Console.WriteLine("Geef een HuurContractId (string)");
            string huurcontractId = Console.ReadLine();
            Console.WriteLine("Geef een Startdatum (yyyy-MM-dd)");
            DateOnly startDatum = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Geef een aantalDagen");
            int aantalDagen = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een HuisId");
            int huisId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Geef een HuurderId");
            int huurderId = Convert.ToInt32(Console.ReadLine());

            Huis huis = beheerHuizen.GeefHuis(huisId);
            Huurder huurder = beheerHuurders.GeefHuurder(huurderId);

            Huurcontract huurcontract = new Huurcontract(huurcontractId,
               new Huurperiode(startDatum.ToDateTime(TimeOnly.MinValue), aantalDagen), huurder, huis); ;
            beheerContracten.UpdateContract(huurcontract);

            Console.WriteLine("Contract werd geupdate");
        }
        public static void GeefContract()
        {
            Console.WriteLine("Geef een HuurContractId (string)");
            string huurcontractId = Console.ReadLine();

            Huurcontract huurcontract = beheerContracten.GeefContract(huurcontractId);
            Console.WriteLine(huurcontract.ToString());
        }
        public static void GeefContracten()
        {

            Console.WriteLine("Geef een Startdatum (yyyy-MM-dd)");
            DateOnly startDatum = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Geef een Einddatum (yyyy-MM-dd), optioneel");
            string input = Console.ReadLine();
            DateTime? eindDatum = GetNullableDateTime(input);
            //Dubbelchecken of dat einddatum null kan zijn;
            List<Huurcontract> huurcontracten = beheerContracten.GeefContracten(startDatum.ToDateTime(TimeOnly.MinValue), eindDatum);
            foreach (Huurcontract huurcontract in huurcontracten)
            {
                Console.WriteLine(huurcontract.ToString());
            }
        }

        private static DateTime? GetNullableDateTime(string? input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            else
            {
               return DateTime.Parse(input);
            }
        }

        public static void KeuzeMenu()
        {
            Console.WriteLine("Maak een keuze : " +
                "\n 1)VoegNieuweHuurderToe (naam, email, tel, adres) " +
                "\n 2)UpdateHuurder (id, naam, email, tel, adres)" +
                "\n 3)GeefHuurder (id)" +
                "\n 4)GeefHuurders(naam)" +
                "\n 5)VoegNieuwHuisToe(straat,nummer,parkId,parknaam,locatie)" +
                "\n 6)UpdateHuis(id,straat,nummer)" +
                "\n 7)ArchvieerHuis(id,straat,nummer)" +
                "\n 8)GeefHuis(id) " +
                "\n 9)MaakContract(huurcontractId,aantalDagen,huisId,huurderId)" +
                "\n 10)AnnuleerContract(huurcontractId,aantalDagen,huisId,huurderId)" +
                "\n 11)UpdateContract((huurcontractId,aantalDagen,huisId,huurderId)" +
                "\n 12)GeefContract(id)" +
                "\n 13)GeefContracten(startDatum,Einddatum)" +
                "\n 14)Stop"


                );

        }
    }
}
