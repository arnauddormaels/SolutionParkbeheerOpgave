﻿namespace ParkBusinessLayer.Model
{
    public class Contactgegevens
    {
        public Contactgegevens(string email, string tel, string adres)
        {
            Email = email;
            Tel = tel;
            Adres = adres;
        }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Adres { get; set; }

        public override string ToString()
        {
            return $"ContactGegevens : {{ \n" +
                $"\tEmail : {Email}  \n" +
                $"\tTel : {Tel}  \n" +
                $"\tAdres : {Adres} \n" +
                $"}}\n";
        }
    }
}