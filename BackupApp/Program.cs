using Microsoft.Extensions.Configuration;



// подлюкчаем файл 
var builder = new ConfigurationBuilder(); 
builder.SetBasePath(Directory.GetCurrentDirectory()); // установка пути к текущему каталогу
builder.AddJsonFile("appsettings.json"); // получаем конфигурацию из файла appsettings.json
var config = builder.Build(); // создаем конфигурацию
string startConnectionString = config.GetConnectionString("StartConnection"); // получаем строку подключения исходной папки
string finishConnectionString = config.GetConnectionString("FinishConnection"); // получаем строку подключения целевой папки



try
{
    string[] files = Directory.GetFiles(startConnectionString); //получаем список файлов в исходной папке


    foreach (string temp in files) //перебираем список файлов исходной папки
    {
        string fileName = temp.Substring(startConnectionString.Length + 1); //вырезаем из пути к файлу только название файла


        File.Copy(Path.Combine(startConnectionString, fileName), Path.Combine(finishConnectionString, fileName), true); // копируем файл в целевую папку 

    }

}


catch (DirectoryNotFoundException dirNotFound) // обрабытваем ситуацию с невозможностью доступка к файлам в исходной папке
{
    Console.WriteLine(dirNotFound.Message);
}