using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        CovidConfig cvdConfig = new CovidConfig();

        string configPath = "covid_config_1302223041.json";
        
        cvdConfig.ReadAndWriteConfigFile(configPath);

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {cvdConfig.satuan_suhu}: ");

        double suhuBadan = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariTerakhirDemam = int.Parse(Console.ReadLine());

        if (cvdConfig.kondisiSuhu(suhuBadan) && cvdConfig.kondisiHariDemam(hariTerakhirDemam))
        {
            Console.WriteLine(cvdConfig.pesan_diterima);
        }
        else
        {
            Console.WriteLine(cvdConfig.pesan_ditolak);
        }

        cvdConfig.UbahSatuan();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {cvdConfig.satuan_suhu}: ");

        double suhuBadan1 = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariTerakhirDemam1 = int.Parse(Console.ReadLine());

        if (cvdConfig.kondisiSuhu(suhuBadan1) && cvdConfig.kondisiHariDemam(hariTerakhirDemam1))
        {
            Console.WriteLine(cvdConfig.pesan_diterima);
        }
        else
        {
            Console.WriteLine(cvdConfig.pesan_ditolak);
        }

        string newJsonText = JsonSerializer.Serialize(cvdConfig);
        File.WriteAllText(configPath, newJsonText);
    }
}