using Sow.Automation.Agendamento.Abstracao;
using Sow.Automation.Agendamento.Servicos;
//using SOW.Automation.Interface.Dlx.Excel;
//using SOW.Automation.Interface.Dlx.Excel.Enums;
//using SOW.Automation.Interface.Dlx.Excel.Models;
//using SOW.Automation.Interface.Dlx.Models;
//using SOW.Automation.Interface.Dlx.Windows.TaskManagementDetailed;
//using SOW.Automation.Interface.DLx.Excel.Services;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Random rnd = new Random();
            //Random random = new Random();

            //List<RpaDadosStageInfo> stages = new List<RpaDadosStageInfo>();

            //for (int i = 0; i < 20; i++)
            //{

            //    int rdnv = rnd.Next(1, 80);
            //    int v = random.Next(0,7);
            //    Array values = Enum.GetValues(typeof(EStatusStageDlx));

            //    EStatusStageDlx randomBar = (EStatusStageDlx)values.GetValue(v);


            //    RpaDadosStageInfo stage = new RpaDadosStageInfo()
            //    {
            //        Ms = "222" + i,
            //        Sid = "TesteSID" + i,
            //        Status = EStatusStage.Ready,
            //        QtdPalets = rdnv,
            //        FamiliaDlx = randomBar
            //    };

            //    stages.Add(stage);
            //}

            //ExcelHandler handler = new ExcelHandler(@"C:\temp\", @"Planilha de Testes.xlsm", new JsonServices(),stages);
            //handler.AlocarObjeto();

            IExecutor age = new Agendamentos();
            age.InicializaAgendamentoLeituraAsyncrono();
            age.InicializaAgendamentoExecucoesAsyncrono();
            Console.ReadKey();
        }


      
    }
}
