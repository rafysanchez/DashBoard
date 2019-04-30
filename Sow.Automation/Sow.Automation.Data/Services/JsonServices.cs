using Newtonsoft.Json;
using Sow.Automation.Data.Entidades.Manipuladores;
using Sow.Automation.Data.Entidades.Manipuladores.Interfaces;
using Sow.Automation.Data.Entidades.NotificacoesContexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sow.Automation.Data.Services
{
   public  class JsonServices : CommandHandler
    {
        string path;

        public JsonServices(IDomainNotificationHandler notifications) : base(notifications)
        {
            path = ConfigurationManager.AppSettings["JSONSERVICES"];
        }

        public void SerializarNewtonsoft<T>(List<T> dados, string nmSaida)
        {

            DirectoryInfo info1 = new DirectoryInfo(path);

            if (!info1.Exists)
                info1.CreateSubdirectory(path);

            using (var streamWriter = File.CreateText(path + nmSaida))
            {
                var json = JsonConvert.SerializeObject(dados, Formatting.Indented);
                streamWriter.Write(json);
            }
        }

        public void SerializarUniqueNewtonsoft<T>(T dados, string nmSaida)
        {
            DirectoryInfo info1 = new DirectoryInfo(path);

            if (!info1.Exists)
                info1.CreateSubdirectory(path);



            using (var streamWriter = File.CreateText(path + nmSaida))
            {
                var json = JsonConvert.SerializeObject(dados, Formatting.Indented);
                streamWriter.Write(json);
            }
        }

        public T DeserializarUniqueNewtonsoft<T>(string nmArquivo)
        {
            FileInfo info = new FileInfo(path + nmArquivo);

            if (info.Exists)
            {

                var json = File.ReadAllText(path + nmArquivo);
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }

        public List<T> DeserializarNewtonsoft<T>(string nmArquivo)
        {
            string file = path + nmArquivo;
            if (File.Exists(file))
            {

                try
                {
                    var json = File.ReadAllText(path + nmArquivo);
                    return JsonConvert.DeserializeObject<List<T>>(json);
                }
                catch { return new List<T>(); }
            }
            else
            {
                return new List<T>();
            }
        }

        public void Adicionar<T>(string json, T valor)
        {
            try
            {
                var lista = DeserializarNewtonsoft<T>(json);
                lista.Add(valor);
                SerializarNewtonsoft<T>(lista, json);
                _notifications.AddNotification(new DomainNotification("", "Dado Adicionado Com Sucesso!"));
            }
            catch (Exception ex)
            {
                _notifications.AddNotification(new DomainNotification("", ex.Message));
            }
        }

        public void Remover<T>(string json, T valor)
        {
            try
            {
                var lista = DeserializarNewtonsoft<T>(json);
                lista.Remove(valor);
                SerializarNewtonsoft<T>(lista, json);
                _notifications.AddNotification(new DomainNotification("", "Dado Removido Com Sucesso!"));

            }
            catch (Exception ex)
            {
                _notifications.AddNotification(new DomainNotification("", ex.Message));
            }
        }
    }
}
